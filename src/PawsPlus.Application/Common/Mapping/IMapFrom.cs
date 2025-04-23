using AutoMapper;

namespace PawsPlus.Application.Common.Mapping;

public interface IMapFrom<T>
{
    void Mapping(Profile mapper) => mapper.CreateMap(typeof(T), this.GetType());
}   