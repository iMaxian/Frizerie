namespace Frizerie.Models
{
    public class ServiciuCategory
    {
        public int ID { get; set; }
        public int ServiciuID { get; set; }
        public Serviciu Serviciu { get; set; }
        public int CategoryID { get; set; }
        public Category Category { get; set; }
    }
}
