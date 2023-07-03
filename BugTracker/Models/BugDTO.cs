using BugTracker.Core.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace BugTracker.Api.Models
{
    public class BugDTO 
    {
        public static Bug.CriticalityType CriticalityType { get; internal set; }
        public int Id { get; set; }
        [Required]
        public string Title { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;

        [Required]
        [JsonIgnore]
        public virtual Category Category { get; set; }
        [Required]

        public Bug.CriticalityType Criticality { get; set; }
        [Required]
        public DateTime CreatedAt { get; set; }
        [JsonIgnore]
        public virtual User CreatedBy { get; set; }

       

    }
}
