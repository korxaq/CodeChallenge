using System;
using System.ComponentModel.DataAnnotations;

namespace CodeChallenge.DAL.Models
{
    public class Project : BaseEntity<int>
    {
        [Required] public DateTime StartDate { get; set; }

        [Required] public DateTime EndDate { get; set; }

        [Required] public int Credits { get; set; }
    }
}
