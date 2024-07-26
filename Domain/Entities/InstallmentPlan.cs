using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities
{
    public class InstallmentPlan
    {
        public int Id { get; set; }

        public required string PlanName { get; set; }

    }
}
