using Application.common.Interfaces;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.UserPaymentUnits.Command
{
    public record CreatePaymentCommand : IRequest<int>
    {
        public required double Price { get; set; }

        public required DateTime InstallmentStartDate { get; set; }

        public required int YearsCount { get; set; }

        public required int UserId { get; set; }

        public required int UnitId { get; set; }

        public required int InstallmentPlanId { get; set; }


    }
    public class CreatePaymentCommandHandler : IRequestHandler<CreatePaymentCommand, int>
    {
        private readonly IApplicationDbContext context;
        public CreatePaymentCommandHandler(IApplicationDbContext _context)
        {
            context = _context;
        }
        public async Task<int> Handle(CreatePaymentCommand request, CancellationToken cancellationToken)
        {
           
            // make unit not avalible
            var unit = context.Units.FirstOrDefault(t => t.Id == request.UnitId );
            if (unit == null) { return -1; }
            unit.AvailabilityStatus = false;

            // Add new one
            var payment = new Domain.Entities.UserPaymentUnit
            {
                Price = request.Price,
                InstallmentStartDate = request.InstallmentStartDate,
                YearsCount = request.YearsCount,
                InstallmentPlanId = request.InstallmentPlanId,
                UnitId = request.UnitId,
                UserId = request.UserId
            };

            context.UserPaymentUnits.Add(payment);
            await context.SaveChangesAsync(cancellationToken);

            return payment.Id;




        }

    }

}
