using AutoMapper;
using MediatR;
using System.Threading;
using System.Threading.Tasks;
using EmployeeManagementAPI.Data;
using EmployeeManagementAPI.Models;
using EmployeeManagementAPI.Commands;
using EmployeeManagementAPI.Exception;

public class DeleteEmployeeCommandHandler : IRequestHandler<DeleteEmployeeCommand>
{
    private readonly EmployeeContext _context;

    public DeleteEmployeeCommandHandler(EmployeeContext context)
    {
        _context = context;
    }

    public async Task<Unit> Handle(DeleteEmployeeCommand request, CancellationToken cancellationToken)
    {
        var employee = await _context.Employees.FindAsync(request.Id);

        if (employee == null)
        {
            throw new NotFoundException(nameof(Employee), request.Id);
        }

        _context.Employees.Remove(employee);
        await _context.SaveChangesAsync();

        return Unit.Value;
    }
}
