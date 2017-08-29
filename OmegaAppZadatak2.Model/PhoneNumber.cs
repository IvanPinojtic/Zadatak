using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel;

namespace OmegaAppZadatak2.Models
{
    public class PhoneNumber
    {
        [Key]
        public int Id { get; set; }

        [RegularExpression(@"^\d+$", ErrorMessage = "Numbers only.")]
        [Required]
        [DisplayName("Broj")]
        public string Number { get; set; }

        [DisplayName("Vrsta")]
        public NumberType Type { get; set; }

        [DisplayName("Opis")]
        public string Description { get; set; }

        public int ContactId { get; set; }

        [ForeignKey("ContactId")]
        public virtual Contact Contact { get; set; }

    }

    public enum NumberType
    {

        Mobile,

        Home,

        Work

    }
}