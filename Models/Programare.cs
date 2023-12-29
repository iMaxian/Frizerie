using System.ComponentModel.DataAnnotations;
using System.Diagnostics.Metrics;

namespace Frizerie.Models
{
    public class Programare
    {
        public int ID { get; set; }

        public int? ClientID { get; set; }
        public Client? Client { get; set; }
        public int? BarberID {  get; set; }
        public Barber? Barber { get; set; }
        public int? ServiciuID { get; set; }
        public Serviciu? Serviciu {  get; set; }

        [DataType(DataType.Date)]
        [Display(Name = "Data programare")]
        public DateTime DataProgramarii { get; set; }
        public int? BarberShopID { get; set; }
        public BarberShop? BarberShop { get; set; }
        public string Locatia { get; set; }
    }
}
