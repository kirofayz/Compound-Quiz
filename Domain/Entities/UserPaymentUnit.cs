using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities
{
    public class UserPaymentUnit
    {
        public int Id { get; set; }

        public required double Price { get; set; }

        public required DateTime InstallmentStartDate { get; set; }

        public required int YearsCount { get; set; }

        public int UserId { get; set; }

        [ForeignKey(nameof(UserId))]
        public User? User { get; set; }


        public int UnitId { get; set; }

        [ForeignKey(nameof(UnitId))]
        public Unit? Unit { get; set; }


        public int InstallmentPlanId { get; set; }

        [ForeignKey(nameof(InstallmentPlanId))]
        public InstallmentPlan? InstallmentPlan { get; set; }   



    }
}
