﻿using EmployeeManagementAPI.Data;
using EmployeeManagementAPI.Models;
using EmployeeManagementAPI.Queries;
using MediatR;
using Microsoft.EntityFrameworkCore;


namespace EmployeeManagementAPI.Handlers
{
    public class GetAllEmployeesQueryHandler : IRequestHandler<GetAllEmployeesQuery, List<Employee>>
    {
        private readonly EmployeeContext _context;

        public GetAllEmployeesQueryHandler(EmployeeContext context)
        {
            _context = context;
        }

        public async Task<List<Employee>> Handle(GetAllEmployeesQuery request, CancellationToken cancellationToken)
        {
            return await _context.Employees.ToListAsync(cancellationToken);
        }
    }
}
