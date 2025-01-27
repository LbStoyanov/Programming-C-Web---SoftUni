﻿using System.ComponentModel.DataAnnotations;
using static TaskBoardApp.Data.DataConstants.Task;

namespace TaskBoardApp.Data.Entities
{
    public class Task
    {
        public int Id { get; set; }

        [Required]
        [MaxLength(MaxTaskTitle)]
        public string Title { get; set; } = null!;

        [Required]
        [MaxLength(MaxTaskDescription)]
        public string Description { get; set; } = null!;

        public DateTime CreatedOn { get; set; }

        public int BoardId { get; set;}

        public Board Board { get; set; } = null!;

        [Required]
        public int OwnerId { get; set; } 

        public User Owner { get; init; } = null!;

    }
}
