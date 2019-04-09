using Htec_task.Models;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json.Linq;
using Soccer.Api.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Htec_task.Services
{
    public interface ISoccerRepository
    {

        void SetScore(RequestModel x);

        JObject GetLeague(string group, string leagueTitle);

        JArray GetLeagueAll();

        JArray GetScoresFiltered(string dateFrom = null, string dateTo = null, string group = null, string team = null);

        void UpdateScore(RequestModel x);

        void CountScores(Team x, string goalsAgainst, string goals);


    }
}
