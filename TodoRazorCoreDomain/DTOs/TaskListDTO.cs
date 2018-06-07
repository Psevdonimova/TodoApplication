using System;
using System.Collections.Generic;
using System.Text;

namespace TodoRazorCoreDomain.DTOs
{
    public class TaskListDTO
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string StartDate { get; set; }
        public string EndDate { get; set; }
    }
}
