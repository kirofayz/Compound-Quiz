using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities
{
    public class UserPaymentUnitInstallment
    {
        public int Id { get; set; }

        public required DateTime InstallmentDate { get; set; }

        public required double InstallmentAmount { get; set; }

        public required int InstallmentNumber { get; set; }

        public int InstallmentPaymentUnitId { get; set; }

        [ForeignKey(nameof(InstallmentPaymentUnitId))]
        public UserPaymentUnit? UserPaymentUnit { get; set; }





    }
}
