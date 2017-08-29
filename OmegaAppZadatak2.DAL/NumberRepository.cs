using System;
using OmegaAppZadatak2.Models;
using System.Linq;
using System.Data.Entity;
using System.Collections.Generic;

namespace OmegaAppZadatak2.DAL
{
    public class NumberRepository
    {
        private ContactsContext context;

        public NumberRepository(ContactsContext context)
        {
            this.context = context;
        }

        public List<PhoneNumber> GetAll(int id)
        {
            return this.context.PhoneNumbers.Where(p => p.ContactId == id).ToList();
        }

        public PhoneNumber Find(int id)
        {
            return this.context.PhoneNumbers.FirstOrDefault(p => p.Id == id);
        }

        public void Add(PhoneNumber model)
        {
            this.context.PhoneNumbers.Add(model);
            this.context.SaveChanges();
        }

        public void Delete(int id)
        {
            var model = this.context.PhoneNumbers.FirstOrDefault(c => c.Id == id);

            this.context.Entry(model).State = EntityState.Deleted;
            this.context.SaveChanges();
        }

        public void DeleteAll(List<PhoneNumber> numbers)
        {
            foreach(var model in numbers)
                this.context.Entry(model).State = EntityState.Deleted;

            this.context.SaveChanges();
        }
    }
}