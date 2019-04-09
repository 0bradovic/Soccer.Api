using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Soccer.Api.Models
{
    public class RequestModel
    {

        public string leagueTitle { get; set; }
        public string matchday { get; set; }
        public string group { get; set; }
        public string homeTeam { get; set; }
        public string awayTeam { get; set; }
        public string kickoffAt { get; set; }
        public string score { get; set; }

        
    }
}
