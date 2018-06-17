using System;
using System.Collections.Generic;
using System.Text;
using TodoRazorCoreDomain.DTOs;
using TodoRazorCoreDomain.Models;

namespace TodoRazorCoreDomain.Helpers
{
    public class AutoMapper : IAutoMapper
    {
        public TaskDTO MapToDTO(Task task)
        {
            return new TaskDTO()
            {
                Id = task.Id,
                Title = task.Title,
                Description = task.Description,
                StartDate = task.StartDate.Value.ToString("g"),
                EndDate = task.EndDate.Value.ToString("g"),
                TaskPriority = task.TaskPriority.Value,
                TaskStatus = task.TaskStatus
        };
        }

        public TaskListDTO MapToListDTO(Task task)
        {
            return new TaskListDTO()
            {
                Id = task.Id,
                Title = task.Title,
                StartDate = task.StartDate.Value.ToString("g"),
                EndDate = task.EndDate.Value.ToString("g"),
                TaskPriority = task.TaskPriority.Value,
                TaskStatus = task.TaskStatus
            };
        }
    }
}
