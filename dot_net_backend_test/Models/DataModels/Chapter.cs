﻿using System.ComponentModel.DataAnnotations;

namespace dot_net_backend_test.Models.DataModels
{
    public class Chapter: BaseEntity
    {
        public int CourseId { get; set; }
        public virtual Course Course { get; set; } = new Course();

        [Required]
        public string Chapters = string.Empty;
    }
}