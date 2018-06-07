using System;
using System.Collections.Generic;
using System.Text;
using TodoRazorCoreDomain.DTOs;
using TodoRazorCoreDomain.Models;

namespace TodoRazorCoreDomain.Helpers
{
    public interface IAutoMapper
    {
        TaskDTO MapToDTO(Task task);
        TaskListDTO MapToListDTO(Task task);
    }
}
