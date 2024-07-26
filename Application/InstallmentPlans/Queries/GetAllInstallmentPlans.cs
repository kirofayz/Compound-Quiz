using Application.common.Interfaces;
using Application.InstallmentPlans.Dto;
using AutoMapper;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.InstallmentPlans.Queries
{
    public record GetAllInstallmentPlansQuery : IRequest<List<InstallmentPlansDto>>
    {
    }

    public class GetAllInstallmentPlansQueryHandler : IRequestHandler<GetAllInstallmentPlansQuery , List<InstallmentPlansDto>>
    {
        private readonly IApplicationDbContext context;
        private readonly IMapper mapper;
        public GetAllInstallmentPlansQueryHandler(IApplicationDbContext _context, IMapper _mapper)
        {
            context = _context;
            mapper = _mapper;
        }

        async Task<List<InstallmentPlansDto>> IRequestHandler<GetAllInstallmentPlansQuery, List<InstallmentPlansDto>>.Handle(GetAllInstallmentPlansQuery request, System.Threading.CancellationToken cancellationToken)
        {
            var plansList = await context.InstallmentPlans.ToListAsync();
            var plansListDto = mapper.Map<List<InstallmentPlansDto>>(plansList);
            return plansListDto;
        }
    }
}
