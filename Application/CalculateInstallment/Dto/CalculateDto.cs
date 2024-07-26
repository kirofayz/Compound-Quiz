using Compound.Application.Common.Mappings;
using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.CalculateInstallment.Dto
{
    public class CalculateDto : IMapFrom<UserPaymentUnitInstallment>
    {
        public required DateTime InstallmentDate { get; set; }

        public required double InstallmentAmount { get; set; }

        public required int InstallmentNumber { get; set; }
    }
}
