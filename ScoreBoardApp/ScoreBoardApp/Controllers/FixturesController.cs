using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ScoreBoardApp.Models;

namespace ScoreBoardApp.Controllers
{
    public class FixturesController : Controller
    {
        ScoreBoardDBEntities DbContext = new ScoreBoardDBEntities();
        // GET: Fixtures
        [Authorize]
        public ActionResult FixturesIndex()
        {
            return View(DbContext.Fixtures.ToList());
        }
        [Authorize]
        public ActionResult CreateFixture()
        {
            List<SelectListItem> ddlTeam = new List<SelectListItem>();
            foreach (var data in DbContext.Teams.ToList())
            {
                ddlTeam.Add(new SelectListItem { Value = data.teamName, Text = data.teamName });
            }
            ViewBag.teamsList = ddlTeam;

            List<SelectListItem> ddlPlayers = new List<SelectListItem>();
            foreach (var data in DbContext.Players.ToList())
            {
                ddlPlayers.Add(new SelectListItem { Value = data.playerName, Text = data.playerName });
            }
            ViewBag.playersList = ddlPlayers;
            return View();
        }
        [Authorize]
        [HttpPost]
        public ActionResult CreateFixture(Fixture fixture)
        {
            if (ModelState.IsValid)
            {
                Fixture newFixture = new Fixture();
                newFixture.gameType = fixture.gameType;
                newFixture.gameName = fixture.gameName;
                newFixture.team1 = fixture.team1; newFixture.tm1pl1 = fixture.tm1pl1; newFixture.tm1pl2 = fixture.tm1pl2;
                newFixture.team2 = fixture.team2; newFixture.tm2pl1 = fixture.tm2pl1; newFixture.tm2pl2 = fixture.tm2pl2;
                newFixture.date = fixture.date; newFixture.time = fixture.time; newFixture.venue = fixture.venue;
                newFixture.winner = "TBD";
                DbContext.Fixtures.Add(newFixture);
                DbContext.SaveChanges();
                return RedirectToAction("FixturesIndex");

            }

            else
            {
                return View(fixture);
            }
        }
        [Authorize]

        public ActionResult DeleteFixture(int gameID)
        {
            Fixture selectFixture = DbContext.Fixtures.SingleOrDefault(x => x.gameID == gameID);
            DbContext.Fixtures.Remove(selectFixture);
            DbContext.SaveChanges();
            return RedirectToAction("FixturesIndex");
        }
        public ActionResult EditFixture(int gameID)
        {
            List<SelectListItem> ddlTeam = new List<SelectListItem>();
           
            foreach (var data in DbContext.Teams.ToList())
            {
                ddlTeam.Add(new SelectListItem { Value = data.teamName, Text = data.teamName });
            }
            ViewBag.teamsList = ddlTeam;

            List<SelectListItem> ddlPlayers = new List<SelectListItem>();
            foreach (var data in DbContext.Players.ToList())
            {
                ddlPlayers.Add(new SelectListItem { Value = data.playerName, Text = data.playerName });
            }
            ViewBag.playersList = ddlPlayers;

            List<SelectListItem> ddlTeams2 = new List<SelectListItem>();
            ddlTeams2 = ddlTeam;
            ddlTeams2.Add(new SelectListItem { Value = "TBD", Text = "TBD" });
            ViewBag.teamsList2 = ddlTeams2;
            Fixture fixtureToEdit = DbContext.Fixtures.SingleOrDefault(x => x.gameID == gameID);
            TempData["DW"] = fixtureToEdit.winner;
            return View(fixtureToEdit);
        }
        [Authorize]
        [HttpPost]
        public ActionResult EditFixture(Fixture fixture)
        {
            if (ModelState.IsValid)
            {
                Fixture newFixture = DbContext.Fixtures.SingleOrDefault(x => x.gameID == fixture.gameID);
                string DefaulWinner = TempData["DW"].ToString();
                newFixture.gameType = fixture.gameType;
                newFixture.gameName = fixture.gameName;
                newFixture.team1 = fixture.team1; newFixture.tm1pl1 = fixture.tm1pl1; newFixture.tm1pl2 = fixture.tm1pl2;
                newFixture.team2 = fixture.team2; newFixture.tm2pl1 = fixture.tm2pl1; newFixture.tm2pl2 = fixture.tm2pl2;
                newFixture.date = fixture.date; newFixture.time = fixture.time; newFixture.venue = fixture.venue;
                newFixture.team1Score = fixture.team1Score;
                newFixture.team2Score = fixture.team2Score;
                newFixture.winner = fixture.winner;
                
                DbContext.SaveChanges();

                Fixture FixtureAfterSave = DbContext.Fixtures.SingleOrDefault(x => x.gameID == fixture.gameID);
                string AfterSaveWinner = FixtureAfterSave.winner;
           
                if (DefaulWinner == "TBD" && AfterSaveWinner != "TBD")
                {
                    Fixture Fixture1 = DbContext.Fixtures.SingleOrDefault(x => x.gameID == fixture.gameID);
                    Team team1 = DbContext.Teams.SingleOrDefault(x => x.teamName == Fixture1.winner);
                    string gamename = Fixture1.gameName;
                
                    if (AfterSaveWinner == Fixture1.team1)
                    {
                        Player player1 = DbContext.Players.SingleOrDefault(x => x.playerName == Fixture1.tm1pl1);
                        Player player2 = DbContext.Players.SingleOrDefault(x => x.playerName == Fixture1.tm1pl2);
                        if (gamename == "Badminton") { team1.badmintonPoints += 10;player1.badmintonPoints += 10;player2.badmintonPoints += 10; }
                        if (gamename == "Chess") { team1.chessPoints += 10; player1.chessPoints += 10;player2.chessPoints += 10; }
                        if (gamename == "Carrom") { team1.caromPoints += 10;player1.caromPoints += 10;player2.caromPoints += 10; }
                        if (gamename == "TT") { team1.ttPoints += 10;player1.ttPoints += 10;player2.ttPoints += 10; }
                        team1.totalPoints = team1.badmintonPoints + team1.chessPoints + team1.caromPoints + team1.ttPoints;
                        player1.totalPoints = player1.badmintonPoints + player1.chessPoints + player1.caromPoints + player1.ttPoints;
                        player2.totalPoints = player2.badmintonPoints + player2.chessPoints + player2.caromPoints + player2.ttPoints;
                    }
                    if (AfterSaveWinner == Fixture1.team2)
                    {
                        Player player1 = DbContext.Players.SingleOrDefault(x => x.playerName == Fixture1.tm2pl1);
                        Player player2 = DbContext.Players.SingleOrDefault(x => x.playerName == Fixture1.tm2pl2);
                        if (gamename == "Badminton") { team1.badmintonPoints += 10; player1.badmintonPoints += 10; player2.badmintonPoints += 10; }
                        if (gamename == "Chess") { team1.chessPoints += 10; player1.chessPoints += 10; player2.chessPoints += 10; }
                        if (gamename == "Carrom") { team1.caromPoints += 10; player1.caromPoints += 10; player2.caromPoints += 10; }
                        if (gamename == "TT") { team1.ttPoints += 10; player1.ttPoints += 10; player2.ttPoints += 10; }
                        team1.totalPoints = team1.badmintonPoints + team1.chessPoints + team1.caromPoints + team1.ttPoints;
                        player1.totalPoints = player1.badmintonPoints + player1.chessPoints + player1.caromPoints + player1.ttPoints;
                        player2.totalPoints = player2.badmintonPoints + player2.chessPoints + player2.caromPoints + player2.ttPoints;
                    }

                }
                if (DefaulWinner != "TBD" && AfterSaveWinner == "TBD")
                {
                    Fixture Fixture1 = DbContext.Fixtures.SingleOrDefault(x => x.gameID == fixture.gameID);
                    Team team1 = DbContext.Teams.SingleOrDefault(x => x.teamName == DefaulWinner);
                    string gamename = Fixture1.gameName;

                    if (DefaulWinner == Fixture1.team1)
                    {
                        Player player1 = DbContext.Players.SingleOrDefault(x => x.playerName == Fixture1.tm1pl1);
                        Player player2 = DbContext.Players.SingleOrDefault(x => x.playerName == Fixture1.tm1pl2);
                        if (gamename == "Badminton") { team1.badmintonPoints -= 10; player1.badmintonPoints -= 10; player2.badmintonPoints -= 10; }
                        if (gamename == "Chess") { team1.chessPoints -= 10; player1.chessPoints -= 10; player2.chessPoints -= 10; }
                        if (gamename == "Carrom") { team1.caromPoints -= 10; player1.caromPoints -= 10; player2.caromPoints -= 10; }
                        if (gamename == "TT") { team1.ttPoints -= 10; player1.ttPoints -= 10; player2.ttPoints -= 10; }
                        team1.totalPoints = team1.badmintonPoints + team1.chessPoints + team1.caromPoints + team1.ttPoints;
                        player1.totalPoints = player1.badmintonPoints + player1.chessPoints + player1.caromPoints + player1.ttPoints;
                        player2.totalPoints = player2.badmintonPoints + player2.chessPoints + player2.caromPoints + player2.ttPoints;
                    }
                    if (DefaulWinner == Fixture1.team2)
                    {
                        Player player1 = DbContext.Players.SingleOrDefault(x => x.playerName == Fixture1.tm2pl1);
                        Player player2 = DbContext.Players.SingleOrDefault(x => x.playerName == Fixture1.tm2pl2);
                        if (gamename == "Badminton") { team1.badmintonPoints -= 10; player1.badmintonPoints -= 10; player2.badmintonPoints -= 10; }
                        if (gamename == "Chess") { team1.chessPoints -= 10; player1.chessPoints -= 10; player2.chessPoints -= 10; }
                        if (gamename == "Carrom") { team1.caromPoints -= 10; player1.caromPoints -= 10; player2.caromPoints -= 10; }
                        if (gamename == "TT") { team1.ttPoints -= 10; player1.ttPoints -= 10; player2.ttPoints -= 10; }
                        team1.totalPoints = team1.badmintonPoints + team1.chessPoints + team1.caromPoints + team1.ttPoints;
                        player1.totalPoints = player1.badmintonPoints + player1.chessPoints + player1.caromPoints + player1.ttPoints;
                        player2.totalPoints = player2.badmintonPoints + player2.chessPoints + player2.caromPoints + player2.ttPoints;
                    }

                }
                DbContext.SaveChanges();
                return RedirectToAction("FixturesIndex");
            }

            else
            {
                return View(fixture);
            }
        }
    }
}