using Compound.Application.Common.Mappings;
using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Units.Dto
{
    public class UnitDto : IMapFrom<Unit>
    {
        public int Id { get; set; }

        public required string UnitName { get; set; }

        public int RoomCount { get; set; }

        public int Floor { get; set; }

        public string? View { get; set; }

        public required bool AvailabilityStatus { get; set; }
    }
}
