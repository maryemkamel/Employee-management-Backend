using EmployeeManagementAPI.Models;
using MediatR;

namespace EmployeeManagementAPI.Queries
{
    public class GetEmployeeQuery : IRequest<Employee>
    {
        public Guid Id { get; set; }

      
    }
}
