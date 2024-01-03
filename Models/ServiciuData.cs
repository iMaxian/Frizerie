namespace Frizerie.Models
{
    public class ServiciuData
    {
        public IEnumerable<Serviciu> Servicii { get; set; }
        public IEnumerable<Category> Categories { get; set; }
        public IEnumerable<ServiciuCategory> ServiciuCategories { get; set; }
    }
}
