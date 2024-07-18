using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace PHAddressWebApi.Entities
{
    public class Barangay
    {
        [Key]
        public string BrgyCode { get; set; }
        public string BrgyName { get; set; }
        public string ProvinceCode { get; set; }
        public string RegionCode { get; set; }
        public string CityCode { get; set; }

        [ForeignKey("CityCode")]
        public City CityFK { get; set; }
    }
}
