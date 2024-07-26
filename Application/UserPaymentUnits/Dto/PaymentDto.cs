using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.UserPaymentUnits.Dto
{
    public class PaymentDto
    {
        public required double Price { get; set; }

        public required DateTime InstallmentStartDate { get; set; }

        public required int YearsCount { get; set; }

        public required int UserId { get; set; }

        public required int UnitId { get; set; }

        public required int InstallmentPlanId { get; set; }
    }
}
