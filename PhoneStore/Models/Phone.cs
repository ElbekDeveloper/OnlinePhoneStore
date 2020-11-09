using PhoneStore.Models.References;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Data.Entity.Migrations.Model;
using System.Security.Permissions;

namespace PhoneStore.Models
{
    public class Phone
    {
        [Key]
        public int Id { get; set; }
        public Manufacturer Manufacturer { get; set; }
        public Material Materials { get; set; }
        public Model Model { get; set; }
        public OperatingSystem OperatingSystem { get; set; }
        public IList<Color> Colors { get; set; }
        public short RamInGb { get; set; }
        public short HddInGb { get; set; }
        public decimal Price { get; set; }
        public decimal Battery { get; set; }
        public int WeightInKg { get; set; }
        public int DimensionInInch { get; set; }
        public byte FrontCameraCount { get; set; }
        public byte MainCameraCount { get; set; }
        public short FrontCameraPrecisonInPx { get; set; }
        public short MainCameraPrecisonInPx { get; set; }
    }
}