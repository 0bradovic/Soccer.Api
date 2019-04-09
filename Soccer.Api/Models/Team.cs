using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace Htec_task.Models
{
    public class Team
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [Required]
        public string Name { get; set; }

        public int Rank { get; set; }

        public int PlayedGames { get; set; }

        public int Points { get; set; }

        public int Goals { get; set; }

        public int GoalAgainst { get; set; }

        public int GoalDifference { get; set; }

        public int Win { get; set; }

        public int Draw { get; set; }
    }
}