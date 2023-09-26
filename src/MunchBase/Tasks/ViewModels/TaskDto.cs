﻿using System;

namespace MunchBase.Tasks.ViewModels
{
    public class TaskDto
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public bool Completed { get; set; }
        public DateTime? TargetDate { get; set; }
    }
}
