// Models/Task.cs
using System;
using System.ComponentModel.DataAnnotations;

namespace TaskApp.Models
{
    public class Task
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Title is required")]
        [StringLength(100, ErrorMessage = "Title cannot exceed 100 characters")]
        public string Title { get; set; }

        public string Description { get; set; }

        [Required(ErrorMessage = "Due date is required")]
        [DataType(DataType.Date)]
        public DateTime DueDate { get; set; }

        [Required]
        public string Status { get; set; } = "Not Started";
    }
}