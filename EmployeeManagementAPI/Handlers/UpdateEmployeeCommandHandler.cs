using AutoMapper;
using MediatR;
using Microsoft.EntityFrameworkCore;
using EmployeeManagementAPI.Data;
using EmployeeManagementAPI.Models;
using EmployeeManagementAPI.Exception;
using EmployeeManagementAPI.Commands;

public class UpdateEmployeeCommandHandler : IRequestHandler<UpdateEmployeeCommand>
{
    private readonly EmployeeContext _context;
    private readonly IMapper _mapper;

    public UpdateEmployeeCommandHandler(EmployeeContext context, IMapper mapper)
    {
        _context = context;
        _mapper = mapper;
    }

    public async Task<Unit> Handle(UpdateEmployeeCommand request, CancellationToken cancellationToken)
    {
        var employee = await _context.Employees.FindAsync(request.Id);

        if (employee == null)
        {
            throw new NotFoundException(nameof(Employee), request.Id);
        }

        _mapper.Map(request, employee);
        _context.Entry(employee).State = EntityState.Modified;

        await _context.SaveChangesAsync();

        return Unit.Value;
    }
}
