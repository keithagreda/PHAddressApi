using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace PHAddressWebApi.Entities
{
    public class City
    {
        [Key]
        public string CityCode { get; set; }
        public string CityName { get; set; }
        public string RegionDesc { get; set; }
        public string PsgcCode { get; set; }
        public string ProvinceCode { get; set; }

        [ForeignKey("ProvinceCode")]
        public Province ProvinceFK { get; set; }
        public ICollection<Barangay> Barangays { get; set; }
    }
}
