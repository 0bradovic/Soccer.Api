using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace Htec_task.Models
{
    public class League
    {
        [Key]
        //[DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [Required]
        public string leagueTitle { get; set; }

        public int Matchday { get; set; }

        public List<Group> Groups { get; set; }


    }
}