using OmegaAppZadatak2.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OmegaAppZadatak2.DAL
{
    public class ContactRepository
    {
        private ContactsContext context;
        private NumberRepository numberRepository;
        public ContactRepository(ContactsContext context, NumberRepository numberRepository)
        {
            this.context = context;
            this.numberRepository = numberRepository;
        }

        public Contact Find(int id)
        {
            return this.context.Contacts.Include(c=>c.Numbers).FirstOrDefault(c => c.Id == id);
        }

        public List<Contact> GetAll()
        {
            return this.context.Contacts.ToList();
        }

        public void Add(Contact model)
        {
            this.context.Contacts.Add(model);
            context.SaveChanges();
        }

        public void Delete(int id)
        {
            var ids = this.numberRepository.GetAll(id);

            foreach(var num in ids)
            {
                this.numberRepository.Delete(num.Id);
            }

            var model = this.context.Contacts.FirstOrDefault(c => c.Id == id);

            context.Entry(model).State = EntityState.Deleted;
            context.SaveChanges();
        }

        public void Update(Contact model)
        {
            this.context.Entry(model).State = EntityState.Modified;
            context.SaveChanges();
        }

    }
}
