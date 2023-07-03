using System;
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace BugTracker.Core.Entities
{
    public class Bug
    {
        public enum CriticalityType
        {
            Negligible = 1,
            Minor = 2,
            Moderate = 3,
            Significant = 4,
            Severe = 5
        }

        public int Id { get; set; }
        [Required]
        [StringLength(100)]
        public string Title { get; set; } = string.Empty;
        [StringLength(255)]
        public string Description { get; set; } = string.Empty;
        [Required]
        public int CategoryID { get; set; }

        [JsonIgnore]
        public virtual Category Category { get; set; }
        [Required]
        public CriticalityType Criticality { get; set; }
        [Required]
        public DateTime CreatedAt { get; set; }
        [Required]
        public int UserID { get; set; }

        [JsonIgnore]
        public virtual User? CreatedBy { get; set; }
   

    }
}
