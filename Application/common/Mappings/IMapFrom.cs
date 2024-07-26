using AutoMapper;
using AutoMapper.Configuration.Conventions;
using Domain.Entities;

namespace Compound.Application.Common.Mappings;

public interface IMapFrom<T>
{
    void Mapping(Profile profile) => profile.CreateMap(typeof(T), GetType());
}
