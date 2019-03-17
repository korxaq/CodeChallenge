using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CodeChallenge.DAL.Models
{
    public class BaseEntity<T> where T : struct, IComparable, IFormattable, IComparable<T>, IEquatable<T>
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Key]
        public T Id { get; set; }
    }
}
