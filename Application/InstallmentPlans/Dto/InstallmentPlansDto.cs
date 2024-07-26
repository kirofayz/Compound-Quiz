using Compound.Application.Common.Mappings;
using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.InstallmentPlans.Dto
{
    public class InstallmentPlansDto : IMapFrom<InstallmentPlan>
    {
        public int Id { get; set; }

        public required string PlanName { get; set; }
    }
}
