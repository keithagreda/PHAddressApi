namespace PHAddressWebApi.Entities
{
    public class Region
    {
        public string Id { get; set; }
        public string PsgcCode { get; set; }
        public string RegionName { get; set; }
        public string RegionCode { get; set; }
        public ICollection<Province> Provinces { get; set; }
    }
}
