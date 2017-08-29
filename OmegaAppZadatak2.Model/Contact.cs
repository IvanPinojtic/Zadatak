using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.IO;
using System.ComponentModel.DataAnnotations;

namespace OmegaAppZadatak2.Models
{
    public class Contact
    {
        [Key]
        public int Id { get; set; }

        public string Ime { get; set; }

        public string Prezime { get; set; }

        public string Grad { get; set; }

        public string Opis { get; set; }

        public string Slika { get; set; }

        public virtual ICollection<PhoneNumber> Numbers { get; set; }
                
    }
}