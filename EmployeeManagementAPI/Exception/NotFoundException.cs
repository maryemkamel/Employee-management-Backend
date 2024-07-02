namespace EmployeeManagementAPI.Exception;
using System;

public class NotFoundException : Exception
{
    public NotFoundException(string entityName, object entityId)
        : base($"Entity '{entityName}' with ID '{entityId}' not found.")
    {
    }
}

