using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace NextCard.Models
{
    public class Ticket
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Please enter a description.")]
        [StringLength(75, ErrorMessage ="Description must not exceed 75 characters.")]
        public string Description { get; set; }

        [Required(ErrorMessage = "Please enter points.")]
        [Range(1, 13, ErrorMessage = "Points must be between 1 and 13.")]
        public int PointValue { get; set; }

        [Required(ErrorMessage = "Please select a status.")]
        public int StatusId { get; set; }

        public Status Status { get; set; }
        
        [Required(ErrorMessage = "Please select a sprint.")]
        public int SprintId { get; set; }
        public Sprint Sprint { get; set; }

    }
}
