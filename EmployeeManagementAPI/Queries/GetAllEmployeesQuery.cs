using EmployeeManagementAPI.Models;
using MediatR;

namespace EmployeeManagementAPI.Queries
{
    public class GetAllEmployeesQuery : IRequest<List<Employee>>
    {
    }
}
