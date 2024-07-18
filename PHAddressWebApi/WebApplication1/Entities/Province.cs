using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace PHAddressWebApi.Entities
{
    public class Province
    {
        [Key]
        public string ProvinceCode { get; set; }
        public string ProvinceName { get; set; }
        public string PsgcCode { get; set; }
        public string RegionCode { get; set; }

        [ForeignKey("RegionCode")]
        public Region RegionFk { get; set; }
        public ICollection<City> Cities { get; set; }
    }
}
