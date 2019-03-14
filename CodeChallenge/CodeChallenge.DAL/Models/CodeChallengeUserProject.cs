﻿using System;
using System.ComponentModel.DataAnnotations;

namespace CodeChallenge.DAL.Models
{
    public class CodeChallengeUserProject : BaseEntity<int>
    {
        [Required] public bool IsActive { get; set; }

        [Required] public DateTime AssignedDate { get; set; }

        public CodeChallengeUser User { get; set; }

        public Project Project { get; set; }
    }
}
