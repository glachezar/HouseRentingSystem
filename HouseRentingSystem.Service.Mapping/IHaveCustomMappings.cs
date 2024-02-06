namespace HouseRentingSystem.Service.Mapping;

using AutoMapper;

public interface IHaveCustomMappings
{
    void CreateMappings(IProfileExpression configuration);
}
