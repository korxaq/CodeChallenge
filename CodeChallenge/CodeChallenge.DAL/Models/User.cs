using System.ComponentModel.DataAnnotations;

namespace CodeChallenge.DAL.Models
{
    public class User : BaseEntity<int>
    {
        [Required] [MaxLength(50)] public string FirstName { get; set; }

        [Required] [MaxLength(50)] public string LastName { get; set; }
    }
}
