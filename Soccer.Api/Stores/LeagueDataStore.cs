using Htec_task.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Htec_task.Stores
{
    public class LeagueDataStore
    {

        public static LeagueDataStore Current { get; } = new LeagueDataStore();

        public List<League> Leagues { get; set; }

        public LeagueDataStore()
        {
            Leagues = new List<League>()
            {
                new League()
                {
                    Id = 1,
                    leagueTitle = "Champions league 2016/17",
                    Matchday = 3,
                    Groups = new List<Group>()
                    {
                        new Group()
                        {
                            Id = 1,
                            Name = "A",
                            Teams = new List<Team>()
                            {
                                new Team() { Id = 1, Name = "Arsenal", Rank = 0, PlayedGames = 0, Points = 0, Goals = 0, GoalAgainst = 0, GoalDifference = 0, Win = 0, Draw = 0 },
                                new Team() { Id = 2, Name = "PSG", Rank = 0, PlayedGames = 0, Points = 0, Goals = 0, GoalAgainst = 0, GoalDifference = 0, Win = 0, Draw = 0 },
                                new Team() { Id = 3, Name = "Ludogorets", Rank = 0, PlayedGames = 0, Points = 0, Goals = 0, GoalAgainst = 0, GoalDifference = 0, Win = 0, Draw = 0 },
                                new Team() { Id = 4, Name = "Basel", Rank = 0, PlayedGames = 0, Points = 0, Goals = 0, GoalAgainst = 0, GoalDifference = 0, Win = 0, Draw = 0 },
                            },
                            Matchdays = new List<Matchday> ()
                            {
                                new Matchday()
                                {
                                    Id = 1,
                                    Day = 1,
                                    Matches = new List<Match>()
                                    {
                                        new Match()
                                        {
                                            Id = 1,
                                            HomeTeam = new Team() { Id = 1, Name = "Arsenal", Rank = 0, PlayedGames = 0, Points = 0, Goals = 0, GoalAgainst = 0, GoalDifference = 0, Win = 0, Draw = 0 },
                                            AwayTeam = new Team() { Id = 2, Name = "PSG", Rank = 0, PlayedGames = 0, Points = 0, Goals = 0, GoalAgainst = 0, GoalDifference = 0, Win = 0, Draw = 0 },
                                            Score = new Score() {HomeScore = 1, AwayScore = 1}
                                        },

                                        new Match()
                                        {
                                            Id = 2,
                                            HomeTeam = new Team() { Id = 1, Name = "Arsenal", Rank = 0, PlayedGames = 0, Points = 0, Goals = 0, GoalAgainst = 0, GoalDifference = 0, Win = 0, Draw = 0 },
                                            AwayTeam = new Team() { Id = 3, Name = "Ludogorets", Rank = 0, PlayedGames = 0, Points = 0, Goals = 0, GoalAgainst = 0, GoalDifference = 0, Win = 0, Draw = 0 },
                                            Score = new Score() {HomeScore = 3, AwayScore = 2}
                                        },

                                        new Match()
                                        {
                                            Id = 3,
                                            HomeTeam = new Team() { Id = 2, Name = "PSG", Rank = 0, PlayedGames = 0, Points = 0, Goals = 0, GoalAgainst = 0, GoalDifference = 0, Win = 0, Draw = 0 },
                                            AwayTeam = new Team() { Id = 3, Name = "Ludogorets", Rank = 0, PlayedGames = 0, Points = 0, Goals = 0, GoalAgainst = 0, GoalDifference = 0, Win = 0, Draw = 0 },
                                            Score = new Score() {HomeScore = 2, AwayScore = 1}
                                        }

                                    },

                                },

                                new Matchday()
                                {
                                    Id = 2,
                                    Day = 2,
                                    Matches = new List<Match>()
                                    {
                                        new Match()
                                        {
                                            Id = 4,
                                            HomeTeam = new Team() { Id = 1, Name = "Arsenal", Rank = 0, PlayedGames = 0, Points = 0, Goals = 0, GoalAgainst = 0, GoalDifference = 0, Win = 0, Draw = 0 },
                                            AwayTeam = new Team() { Id = 2, Name = "PSG", Rank = 0, PlayedGames = 0, Points = 0, Goals = 0, GoalAgainst = 0, GoalDifference = 0, Win = 0, Draw = 0 },
                                            Score = new Score() {HomeScore = 2, AwayScore = 1}
                                        },

                                        new Match()
                                        {
                                            Id = 5,
                                            HomeTeam = new Team() { Id = 1, Name = "Arsenal", Rank = 0, PlayedGames = 0, Points = 0, Goals = 0, GoalAgainst = 0, GoalDifference = 0, Win = 0, Draw = 0 },
                                            AwayTeam = new Team() { Id = 3, Name = "Ludogorets", Rank = 0, PlayedGames = 0, Points = 0, Goals = 0, GoalAgainst = 0, GoalDifference = 0, Win = 0, Draw = 0 },
                                            Score = new Score() {HomeScore = 1, AwayScore = 3}
                                        },

                                        new Match()
                                        {
                                            Id = 6,
                                            HomeTeam = new Team() { Id = 2, Name = "PSG", Rank = 0, PlayedGames = 0, Points = 0, Goals = 0, GoalAgainst = 0, GoalDifference = 0, Win = 0, Draw = 0 },
                                            AwayTeam = new Team() { Id = 3, Name = "Ludogorets", Rank = 0, PlayedGames = 0, Points = 0, Goals = 0, GoalAgainst = 0, GoalDifference = 0, Win = 0, Draw = 0 },
                                            Score = new Score() {HomeScore = 0, AwayScore = 0}
                                        }

                                    },

                                },

                            }
                        },
                        new Group()
                        {
                            Id = 2,
                            Name = "B",
                            Teams = new List<Team>()
                            {
                                new Team() { Id = 5, Name = "Test1", Rank = 0, PlayedGames = 0, Points = 0, Goals = 0, GoalAgainst = 0, GoalDifference = 0, Win = 0, Draw = 0 },
                                new Team() { Id = 6, Name = "Test2", Rank = 0, PlayedGames = 0, Points = 0, Goals = 0, GoalAgainst = 0, GoalDifference = 0, Win = 0, Draw = 0 },
                                new Team() { Id = 7, Name = "Test3", Rank = 0, PlayedGames = 0, Points = 0, Goals = 0, GoalAgainst = 0, GoalDifference = 0, Win = 0, Draw = 0 },
                                new Team() { Id = 8, Name = "Test4", Rank = 0, PlayedGames = 0, Points = 0, Goals = 0, GoalAgainst = 0, GoalDifference = 0, Win = 0, Draw = 0 },
                            },
                            Matchdays = new List<Matchday> ()
                            {
                                new Matchday()
                                {
                                    Id = 3,
                                    Day = 5,
                                    Matches = new List<Match>()
                                    {
                                        new Match()
                                        {
                                            Id = 8,
                                            HomeTeam = new Team() { Id = 1, Name = "Test1", Rank = 0, PlayedGames = 0, Points = 0, Goals = 0, GoalAgainst = 0, GoalDifference = 0, Win = 0, Draw = 0 },
                                            AwayTeam = new Team() { Id = 2, Name = "Test2", Rank = 0, PlayedGames = 0, Points = 0, Goals = 0, GoalAgainst = 0, GoalDifference = 0, Win = 0, Draw = 0 },
                                            Score = new Score() {HomeScore = 1, AwayScore = 1},
                                        },

                                    },

                                },
                            }
                        },

                    }
                }
            };


        }


    }
}