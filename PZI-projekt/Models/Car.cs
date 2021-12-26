using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace PZI_projekt.Models
{
    public class Car
    {
        [Key]
        public int Id { get; set; }
        public string Model { get; set; }
        public int VIN { get; set; }
        public int Mileage { get; set; }
        public bool IsLocked { get; set; }
        public bool AreDoorsOpened { get; set; }
        public bool AreWindowsOpened { get; set; }
        public bool IsBonnetOpened { get; set; }
        public bool IsTrunkOpened { get; set; }
        public bool OilOK { get; set; }
    }
}
