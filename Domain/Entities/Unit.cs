using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities
{
    public class Unit
    {
        public int Id { get; set; }

        public required string UnitName { get; set; }

        public int RoomCount { get; set; }

        public int Floor { get; set; }

        public string? View { get; set; }

        public required bool AvailabilityStatus { get; set; }




    }
}
