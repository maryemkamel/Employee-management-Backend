using MediatR;
using System;

namespace EmployeeManagementAPI.Commands
{
    public class DeleteEmployeeCommand : IRequest
    {
        public Guid Id { get; set; }

      
    }
}
