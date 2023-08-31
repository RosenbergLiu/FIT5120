using System.ComponentModel.DataAnnotations;

namespace MainProject.Data
{
    public class UserDataRecord
    {
        [Key]
        public Guid RecordId { get; set; }
        public string? IpHash { get; set; }
        public DateTime RecordDate { get; set; }
        public double RecordGHG { get; set; }
        public double RecordWater { get; set; }
        public double RecordLand { get; set; }
        public double RecordEutrophying { get; set; }
    }
}
