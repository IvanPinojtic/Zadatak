using OmegaAppZadatak2.DAL;
using OmegaAppZadatak2.Models;
using PagedList;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace OmegaAppZadatak2.Controllers
{
    public class HomeController : Controller
    {
        public ContactRepository contactRepository;
        public NumberRepository numberRepository;
        static int pageNumber = 1;
        static int pageSize = 2;

        public HomeController()
        {
            var context = new ContactsContext();
            this.numberRepository = new NumberRepository(context);
            this.contactRepository = new ContactRepository(context, this.numberRepository);
        }
        
        public ActionResult Index(int? page)
        {
            pageNumber = (page ?? 1);
            var contacts = contactRepository.GetAll();
            return View(contacts.ToPagedList(pageNumber, pageSize));
        }

        public ActionResult Table(int? page)
        {
            pageNumber = (page ?? 1);
            var contacts = contactRepository.GetAll();
            return PartialView("_IndexTable", contacts.ToPagedList(pageNumber, pageSize));
        }

        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Create(Contact model)
        {
            if (ModelState.IsValid)
            {
                this.contactRepository.Add(model);
                return RedirectToAction("Index");
            }
            else
            {
                return View(model);
            }
        }

        public ActionResult CreateNumber(int id)
        {
            var model = new PhoneNumber
            {
                ContactId = id
            };
            return View(model);
        }

        [HttpPost]
        [ActionName("CreateNumber")]
        public ActionResult CreateNumber(PhoneNumber model)
        {
            var id = model.ContactId;
            if (ModelState.IsValid)
            {
                this.numberRepository.Add(model);

                return RedirectToAction("Details", new { id = id });
            }
            else
            {
                return View(model);
            }
        }

        public ActionResult Details(int id)
        {
                var model = this.contactRepository.Find(id);

                return View(model);
        }

        public JsonResult Delete(int id)
        {
            this.contactRepository.Delete(id);

            return new JsonResult() { Data = "OK", JsonRequestBehavior = JsonRequestBehavior.AllowGet };
        }

        public JsonResult DeleteNumber(int id)
        {
            this.numberRepository.Delete(id);

            return new JsonResult() { Data = "OK", JsonRequestBehavior = JsonRequestBehavior.AllowGet };
        }

        public ActionResult Edit(int id)
        {
            var model = this.contactRepository.Find(id);

            return View(model);
        }

        [HttpPost]
        [ActionName("Edit")]
        public ActionResult EditPost(int id, HttpPostedFileBase slika)
        {
            var model = this.contactRepository.Find(id);
            var old = model.Slika;
            if (ModelState.IsValid)
            {
                var didUpdateModelSucceed = this.TryUpdateModel(model);

                if (didUpdateModelSucceed)
                {
                    if (slika != null)
                    {
                        var path = Path.Combine(Server.MapPath("~/Content/Images/"));
                        var saveName = slika.FileName.Substring(slika.FileName.IndexOf('.'));

                        if (!Directory.Exists(path))
                            Directory.CreateDirectory(path);

                        slika.SaveAs(path + model.Ime + model.Prezime + saveName);

                        model.Slika = model.Ime + model.Prezime + saveName;
                    }
                    else
                        model.Slika = old;

                    this.contactRepository.Update(model);
                    return RedirectToAction("Index");
                }
            }
            return View(model);
        }

        [HttpPost]
        public ActionResult IndexAjax(ContactFilterModel model)
        {

            var contactsQuery = this.contactRepository.GetAll().AsQueryable().Include(p => p.Numbers);

            if (!string.IsNullOrWhiteSpace(model.Ime))
                contactsQuery = contactsQuery.Where(p => p.Ime.Contains(model.Ime));

            if (!string.IsNullOrWhiteSpace(model.Prezime))
                contactsQuery = contactsQuery.Where(p => p.Prezime.Contains(model.Prezime));

            if (!string.IsNullOrWhiteSpace(model.Grad))
                contactsQuery = contactsQuery.Where(p => p.Grad.Contains(model.Grad));

            if (!string.IsNullOrWhiteSpace(model.Opis))
                contactsQuery = contactsQuery.Where(p => p.Opis.Contains(model.Opis));

            if (!string.IsNullOrWhiteSpace(model.StringBrojeva))
                contactsQuery = contactsQuery.Where(c => c.Numbers.Any(p=>p.Number.Contains(model.StringBrojeva)));

            var data = contactsQuery.OrderBy(p => p.Id).ToList();

            return PartialView("_IndexTable", data.ToPagedList(pageNumber, pageSize));
        }
    }
}