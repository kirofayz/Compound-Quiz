using Application.CalculateInstallment.Dto;
using Application.common.Interfaces;
using AutoMapper;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.CalculateInstallment
{
    public record CalculatePaymentCommand : IRequest<List<CalculateDto>>
    {
        public required int InstallmentPlanId { get; set; }

        public required int YearsCount { get; set; }

        public required double Price { get; set;}

        public required int PaymentID { get; set;}

        public required DateTime StartDate { get; set;}
    }
    public class CalculatePaymentCommandHandler : IRequestHandler<CalculatePaymentCommand, List<CalculateDto>>
    {
        private readonly IApplicationDbContext context;
        private readonly IMapper mapper;
        public CalculatePaymentCommandHandler(IApplicationDbContext _context , IMapper _mapper)
        {
            context = _context;
            mapper = _mapper;
        }
        public async Task<List<CalculateDto>> Handle(CalculatePaymentCommand request , CancellationToken cancellationToken)
        {
            var installmentsDto = new List<CalculateDto>();


            int TotalInstallments = GetTotalInstallments(request.YearsCount, request.InstallmentPlanId);
            double Amount = request.Price / TotalInstallments;

            for(int i = 0; i< TotalInstallments; i++)
            {
                DateTime InstallmentDate = GetDates(request.StartDate, request.InstallmentPlanId, i);
                var installment = new Domain.Entities.UserPaymentUnitInstallment
                {
                    InstallmentAmount = Amount
                    ,
                    InstallmentDate = InstallmentDate,
                    InstallmentNumber = i + 1,
                    InstallmentPaymentUnitId = request.PaymentID
                };
                context.UserPaymentUnitInstallments.Add(installment);

                installmentsDto.Add(new CalculateDto { InstallmentAmount = Amount , InstallmentNumber = i+1 , InstallmentDate = InstallmentDate });
            }
            await context.SaveChangesAsync(cancellationToken);
            return installmentsDto;
        }

        private int GetTotalInstallments(int yearsCount , int planId)
        {
            switch (planId)
            {
                case 1: 
                    // Yearly
                    return yearsCount;

                case 2: 
                    // Quarterly
                    return yearsCount * 4;

                case 3: 
                    // Semi-Annual
                    return yearsCount * 2;

                case 4: 
                    // Monthly
                    return yearsCount * 12;

                default:
                  
                    throw new ArgumentException("Incorrect planId");
            }
        }


        private DateTime GetDates(DateTime StartDate, int planId , int index)
        {
            switch (planId)
            {
                case 1: 
                    // Yearly
                    return StartDate.AddYears(index);

                case 2: 
                    // Quarterly
                    return StartDate.AddMonths(index * 3);

                case 3: 
                    // Semi-Annual
                    return StartDate.AddMonths(index * 6);

                case 4:
                    // Monthly
                    return StartDate.AddMonths(index);

                default:
                    throw new ArgumentException("Incorrect planId");
            }
        }
    }
}
