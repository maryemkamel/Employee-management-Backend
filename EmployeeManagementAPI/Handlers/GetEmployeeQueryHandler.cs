using EmployeeManagementAPI.Data;
using EmployeeManagementAPI.Models;
using EmployeeManagementAPI.Queries;
using MediatR;


namespace EmployeeManagementAPI.Handlers
{
    public class GetEmployeeQueryHandler : IRequestHandler<GetEmployeeQuery, Employee>
    {
        private readonly EmployeeContext _context;

        public GetEmployeeQueryHandler(EmployeeContext context)
        {
            _context = context;
        }

        public async Task<Employee> Handle(GetEmployeeQuery request, CancellationToken cancellationToken)
        {
            return await _context.Employees.FindAsync(request.Id);
        }
    }
}
