using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace BugTracker.Core.Entities
{
    public class User
    {
        public enum RoleType
        {
            Admin,
            User
        }

        public int Id { get; set; }
        [Required]
     
        [StringLength(50)]
        [MinLength(4)]
        public string UserName { get; set; }
        [Required]
        [StringLength(100)]
        public string Name { get; set; }
        [Required]
        public string Email { get; set; }
        [Required]
        [StringLength (50)]
        [MinLength (8)]
        public string Password { get; set; }
        [Required]
        public bool isActive { get; set; }
        public RoleType Role { get; set; }

        public virtual List<Bug> Bugs { get; set; }

    }
}
