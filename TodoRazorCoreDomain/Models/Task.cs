using System;
using System.Collections.Generic;
using System.Text;
using System.ComponentModel.DataAnnotations;

namespace TodoRazorCoreDomain.Models
{
    public class Task
    {
        public int Id { get; set; }
        [Required(ErrorMessage = "Title is required.")]
        public string Title { get; set; }
        public string Description { get; set; }

        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        [Date(ErrorMessage = "Date of start must be current.")]
        [Required(ErrorMessage = "Date of start is required.")]
        public DateTime? StartDate { get; set; }

        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        [Date(ErrorMessage = "Date of end must be current.")]
        [Required(ErrorMessage = "Date of end is required.")]
        public DateTime? EndDate { get; set; }


        [Required(ErrorMessage = "Priority is required.")]
        public Priority? TaskPriority { get; set; }

        public Status TaskStatus { get; set; } = Status.Todo;
    }

    public class DateAttribute : RangeAttribute
    {
        public DateAttribute()
          : base(typeof(DateTime), DateTime.Now.ToShortDateString(), DateTime.MaxValue.ToShortDateString()) { }
    }
}
