using AutoMapper;
using EmployeeManagementAPI.Models;
using EmployeeManagementAPI.DTOs;
using EmployeeManagementAPI.Commands;

namespace EmployeeManagementAPI.Mappings
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<Employee, EmployeeDto>().ReverseMap();
            CreateMap<CreateEmployeeCommand, Employee>();
            CreateMap<UpdateEmployeeCommand, Employee>();
        }
    }
}
