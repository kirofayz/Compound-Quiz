using Application.common.Interfaces;
using Application.Units.Dto;
using AutoMapper;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Units.Queries
{
    public record GetAllUnitQuery : IRequest<List<UnitDto>>
    {
    }

    public class GetAllUnitQueryHandler : IRequestHandler<GetAllUnitQuery, List<UnitDto>>
    {
        private readonly IApplicationDbContext context;
        private readonly IMapper mapper;

        public GetAllUnitQueryHandler(IApplicationDbContext _context, IMapper _mapper)
        {
            context = _context;
            mapper = _mapper;
        }
        async Task<List<UnitDto>> IRequestHandler<GetAllUnitQuery, List<UnitDto>>.Handle(GetAllUnitQuery request, CancellationToken cancellationToken)
        {
            var unitList = await context.Units.ToListAsync();
            var unitListDto = mapper.Map<List<UnitDto>>(unitList);
            return unitListDto;
        }

    }
}
