﻿using MediatR;
using System;

namespace EmployeeManagementAPI.Commands
{
    public class UpdateEmployeeCommand : IRequest
    {
        public Guid Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string PhoneNumber { get; set; }
        public string Position { get; set; }
        public string Department { get; set; }
    }
}
