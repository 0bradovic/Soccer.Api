using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Htec_task.Models;
using Htec_task.Stores;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json.Linq;
using Soccer.Api.Models;

namespace Htec_task.Services
{
    public class SoccerRepository : ISoccerRepository
    {
        public JObject GetLeague(string group, string leagueTitle)
        {
            var League = LeagueDataStore.Current.Leagues.Where(l => l.leagueTitle == leagueTitle).FirstOrDefault();
            if (League == null)
            {
                return null;
            }

            var Group = League.Groups.Where(g => g.Name == group).FirstOrDefault();
            if (Group == null)
            {
                return null;
            }
            
            JArray array = new JArray();
            JObject o = new JObject();
            Array x = Group.Teams.ToArray();
            o["leagueTitle"] = League.leagueTitle;
            o["matchday"] = League.Matchday;
            o["group"] = Group.Name;

            foreach(var a in x)
            {
                array.Add(JObject.FromObject(a));
            }
            
            o["standing"] = array;
            
            return o;
        }

        public JArray GetLeagueAll()
        {
            var League = LeagueDataStore.Current.Leagues.FirstOrDefault();
            if (League == null)
            {
                return null;
            }

            JArray arrayX = new JArray();
            foreach (Group g in League.Groups)
            {
                arrayX.Add(this.GetLeague(g.Name, League.leagueTitle));
            }

            return arrayX;


        }

        public void SetScore(RequestModel x)
        {
            var League = LeagueDataStore.Current.Leagues.Where(l => l.leagueTitle == x.leagueTitle).FirstOrDefault();
            var Group = League.Groups.Where(l => l.Name == x.group).FirstOrDefault();
            var Matchday = Group.Matchdays.Where(k => k.Day == Convert.ToInt32(x.matchday)).FirstOrDefault();


            Matchday.Matches.Insert(Matchday.Matches.Count, new Match()
            {
                HomeTeam = Group.Teams.Where(k => k.Name == x.homeTeam).FirstOrDefault(),
                AwayTeam = Group.Teams.Where(k => k.Name == x.awayTeam).FirstOrDefault(),
                Score = new Score()
                {
                    HomeScore = Convert.ToInt32(x.score.Substring(0, x.score.IndexOf(":"))),
                    AwayScore = Convert.ToInt32(x.score.Substring(x.score.IndexOf(":") + 1))

                },
                KickOffAt = x.kickoffAt
            });

            Team aTeam = Group.Teams.Where(k => k.Name == x.homeTeam).FirstOrDefault();
            this.CountScores(aTeam, x.score.Substring(0, x.score.IndexOf(":")), x.score.Substring(x.score.IndexOf(":") + 1));
            Team hTeam = Group.Teams.Where(k => k.Name == x.awayTeam).FirstOrDefault();
            this.CountScores(hTeam, x.score.Substring(x.score.IndexOf(":") + 1), x.score.Substring(0, x.score.IndexOf(":")));
            

        }

        public JArray GetScoresFiltered(string dateFrom = null, string dateTo = null, string group = null, string team = null)
        {

            var League = LeagueDataStore.Current.Leagues.FirstOrDefault();
            if (League == null)
            {
                return null;
            }

            if (group != null)
            {
                JArray arrayX = new JArray();

                var Group = League.Groups.Where(g => g.Name == group).FirstOrDefault();

                JArray array = new JArray();
                JObject o = new JObject();
                Array x;
                if (team != null)
                {
                    x = Group.Teams.Where(t => t.Name == team).ToArray();
                }
                else
                {
                    x = Group.Teams.ToArray();
                }
                o["leagueTitle"] = League.leagueTitle;
                o["matchday"] = League.Matchday;
                o["group"] = Group.Name;

                foreach (var a in x)
                {
                    array.Add(JObject.FromObject(a));
                }

                o["standing"] = array;

                arrayX.Add(o);

                return arrayX;
            }
            else
            {

                List<Group> Groups = League.Groups;
                JArray arrayX = new JArray();
                foreach (Group g in Groups)
                {
                    JArray array = new JArray();
                    JObject o = new JObject();
                    Array x;
                    if (team != null)
                    {
                        x = g.Teams.Where(t => t.Name == team).ToArray();
                    }
                    else
                    {
                        x = g.Teams.ToArray();
                    }
                    o["leagueTitle"] = League.leagueTitle;
                    o["matchday"] = League.Matchday;
                    o["group"] = g.Name;

                    foreach (var a in x)
                    {
                        array.Add(JObject.FromObject(a));
                    }

                    o["standing"] = array;

                    arrayX.Add(o);
                }
                
                return arrayX;
                
            }

        }

        public void UpdateScore(RequestModel x)
        {
            var League = LeagueDataStore.Current.Leagues.Where(l => l.leagueTitle == x.leagueTitle).FirstOrDefault();
            var Group = League.Groups.Where(l => l.Name == x.group).FirstOrDefault();
            var Matchday = Group.Matchdays.Where(k => k.Day == Convert.ToInt32(x.matchday)).FirstOrDefault();

            foreach(Match m in Matchday.Matches)
            {
                if(m.HomeTeam.Name == x.homeTeam && m.AwayTeam.Name == x.awayTeam)
                {
                    int oldHome = m.Score.HomeScore;
                    int oldAway = m.Score.AwayScore;

                    m.Score.AwayScore = Convert.ToInt32(x.score.Substring(x.score.IndexOf(":") + 1));
                    m.Score.HomeScore = Convert.ToInt32(x.score.Substring(0, x.score.IndexOf(":")));
                    

                    Team aTeam = Group.Teams.Where(k => k.Name == x.homeTeam).FirstOrDefault();
                    this.CountScores(aTeam, (Convert.ToInt32(x.score.Substring(0, x.score.IndexOf(":")))-oldHome).ToString(), (Convert.ToInt32(x.score.Substring(x.score.IndexOf(":") + 1))-oldAway).ToString());
                    Team hTeam = Group.Teams.Where(k => k.Name == x.awayTeam).FirstOrDefault();
                    this.CountScores(hTeam, (Convert.ToInt32(x.score.Substring(x.score.IndexOf(":") + 1))-oldAway).ToString(), (Convert.ToInt32(x.score.Substring(0, x.score.IndexOf(":")))-oldHome).ToString());

                }
            }
            
        }

        public void CountScores(Team x, string goalsAgainst, string goals)
        {
            Team t = x;
            t.GoalAgainst += Convert.ToInt32(goalsAgainst);
            t.Goals += Convert.ToInt32(goals);
            if(t.Goals - t.GoalAgainst > 0) t.GoalDifference = t.Goals - t.GoalAgainst; else t.GoalDifference = t.GoalAgainst - t.Goals;
            if (Convert.ToInt32(goals) > Convert.ToInt32(goalsAgainst))
            {
                t.Points += 3;
            }
            else if(Convert.ToInt32(goals) < Convert.ToInt32(goalsAgainst))
            {
                t.Points = t.Points;
            }
            else
            {
                t.Points += 1;
            }
            
        }
    }
}