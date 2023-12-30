﻿using System.Collections.Specialized;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Security.Policy;

namespace Frizerie.Models
{
    public class Serviciu
    {
        public int ID { get; set; }
        /*
        public string Tip { get; set; }
        public string Descriere { get; set; }
        public decimal Cost { get; set; }
        */
        [Display(Name = "Tip Serviciu")]
        [RegularExpression(@"^[A-Z]+[a-z\s]*$", ErrorMessage = "Trebuie să înceapă cu majusculă și să exprime serviciul dorit")]
        public string Tip_Serviciu { get; set; }

        public int? BarberID { get; set; }
        public Barber? Barber { get; set; }

        [Column(TypeName = "decimal(6, 2)")]
        [Range(10, 1000, ErrorMessage = "Introduceți o valoare între 10 și 1000 lei")]
        [Display(Name = "Cost")]
        public decimal Cost { get; set; }

        [Display(Name = "Data Programare")]
        [DataType(DataType.Date)]
        public DateTime Data_Programare { get; set; }

        public int? BarberShopID { get; set; }
        public BarberShop? BarberShop { get; set; }

        //public ICollection<CategorieServiciu> CategorieServicii { get; set; }

    }
}
