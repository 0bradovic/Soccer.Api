using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Htec_task.Services;
using Htec_task.Stores;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json.Linq;
using Soccer.Api.Models;

namespace Soccer.Api.Controllers
{
    [Produces("application/json")]
    [Route("api/Soccer")]
    public class SoccerController : Controller
    {
        private ISoccerRepository _soccerRepository;

        public SoccerController(ISoccerRepository repo)
        {
            _soccerRepository = repo;
        }

        [HttpGet()]
        [Route("leagues")]
        public IActionResult GetLeague(string group, string leagueTitle)
        {
            if (leagueTitle != null && group != null)
            {
                var league = _soccerRepository.GetLeague(group, leagueTitle);
                return Ok(league);

            }
            else
            {
                var league = _soccerRepository.GetLeagueAll();
                return Ok(league);
            }
        }


        [HttpPost()]
        [Route("scores")]
        public IActionResult SetScore([FromBody] List<RequestModel> x)
        {
            if(x.Count>1)
            foreach (RequestModel a in x)
            {
                _soccerRepository.SetScore(a);
            }
            else
                _soccerRepository.SetScore(x[0]);


            return Ok("Scores Set");
        }

        [HttpGet()]
        [Route("filtered")]
        public IActionResult GetFilteredScores(string dateFrom = null, string dateTo = null, string group = null, string team = null)
        {
            var Score = _soccerRepository.GetScoresFiltered(dateFrom, dateTo, group, team);
            return Ok(Score);

        }

        [HttpPost()]
        [Route("update")]
        public IActionResult UpdateScores([FromBody] List<RequestModel> x)
        {
            foreach (RequestModel a in x)
            {
                _soccerRepository.UpdateScore(a);
            }

            return Ok("Scores Updated");
        }
    }
}