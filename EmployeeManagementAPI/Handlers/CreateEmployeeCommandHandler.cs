using EmployeeManagementAPI.Commands;
using EmployeeManagementAPI.Data;
using EmployeeManagementAPI.Models;
using MediatR;

namespace EmployeeManagementAPI.Handlers
{
    public class CreateEmployeeCommandHandler : IRequestHandler<CreateEmployeeCommand, Employee>
    {
        private readonly EmployeeContext _context;

        public CreateEmployeeCommandHandler(EmployeeContext context)
        {
            _context = context ?? throw new ArgumentNullException(nameof(context));
        }

        public async Task<Employee> Handle(CreateEmployeeCommand request, CancellationToken cancellationToken)
        {
            var employee = new Employee
            {
                Id = Guid.NewGuid(),
                FirstName = request.FirstName,
                LastName = request.LastName,
                Email = request.Email,
                PhoneNumber = request.PhoneNumber,
                Position = request.Position,
                Department = request.Department
            };

            _context.Employees.Add(employee);
            await _context.SaveChangesAsync(cancellationToken);

            return employee;
        }
    }

}
