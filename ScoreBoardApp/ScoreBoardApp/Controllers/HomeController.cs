using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ScoreBoardApp.Models;
using System.Threading;

namespace ScoreBoardApp.Controllers
{
   
    public class HomeController : Controller
    {
        ScoreBoardDBEntities DbContext = new ScoreBoardDBEntities();
        public ActionResult Index()
        {
            List<TeamRankView> teamList = new List<TeamRankView>();
            teamList = DbContext.TeamRankViews.ToList();
            return View(teamList);
        }

        public PartialViewResult BadmintonFixtures()
        {
            List<Fixture> model = DbContext.Fixtures.Where(x => x.winner == "TBD" && x.gameName == "Badminton").OrderBy(x=>x.date).ThenBy(x=>x.time).ToList();
            return PartialView("_BadmintonFixturePartial", model);
        }
        public PartialViewResult CarromFixtures()
        {
            List<Fixture> model = DbContext.Fixtures.Where(x => x.winner == "TBD" && x.gameName == "Carrom").OrderBy(x => x.date).ThenBy(x => x.time).ToList();
            return PartialView("_CarromFixturePartial",model);
        }
        public PartialViewResult ChessFixtures()
        {
            List<Fixture> model = DbContext.Fixtures.Where(x => x.winner == "TBD" && x.gameName == "Chess").OrderBy(x => x.date).ThenBy(x => x.time).ToList();
            return PartialView("_ChessFixturePartial", model);
        }
        public PartialViewResult TTFixtures()
        {
            List<Fixture> model = DbContext.Fixtures.Where(x => x.winner == "TBD" && x.gameName == "TT").OrderBy(x => x.date).ThenBy(x => x.time).ToList();
            return PartialView("_TTFixturePartial", model);
        }
        public PartialViewResult BadmintonResults()
        {
            List<Fixture> model = DbContext.Fixtures.Where(x => x.winner != "TBD" && x.gameName == "Badminton").OrderBy(x => x.date).ThenBy(x => x.time).ToList();
            return PartialView("_BadmintonResultPartial", model);
        }
        public PartialViewResult CarromResults()
        {
            List<Fixture> model = DbContext.Fixtures.Where(x => x.winner != "TBD" && x.gameName == "Carrom").OrderBy(x => x.date).ThenBy(x => x.time).ToList();
            return PartialView("_CarromResultPartial", model);
        }
        public PartialViewResult ChessResults()
        {
            List<Fixture> model = DbContext.Fixtures.Where(x => x.winner != "TBD" && x.gameName == "Chess").OrderBy(x => x.date).ThenBy(x => x.time).ToList();
            return PartialView("_ChessResultPartial", model);
        }
        public PartialViewResult TTResults()
        {
            List<Fixture> model = DbContext.Fixtures.Where(x => x.winner != "TBD" && x.gameName == "TT").OrderBy(x => x.date).ThenBy(x => x.time).ToList();
            return PartialView("_TTResultPartial", model);
        }
        
        public PartialViewResult BadmintonPlayerStandings()
        {
            Thread.Sleep(1000);
            List<plyerBadmintonRankView> model = DbContext.plyerBadmintonRankViews.ToList();
            plyerBadmintonRankView firstData = DbContext.plyerBadmintonRankViews.FirstOrDefault();
            if (firstData.badmintonPoints == 0)
            {
                return PartialView("_DefaultPlayerStandingsPartial");
            }
            else
            {
                return PartialView("_BadmintonPlayerStandingsPartial", model);
            }
        }
        public PartialViewResult CarromPlayerStandings()
        {
            Thread.Sleep(1000);
            List<plyerCarromRankView> model = DbContext.plyerCarromRankViews.ToList();
            plyerCarromRankView firstData = DbContext.plyerCarromRankViews.FirstOrDefault();
            if (firstData.caromPoints == 0)
            {
                return PartialView("_DefaultPlayerStandingsPartial");
            }
            else
            {
                return PartialView("_CarromPlayerStandingsPartial", model);
            }
        }
        public PartialViewResult ChessPlayerStandings()
        {
            Thread.Sleep(1000);
            List<plyerChessRankView> model = DbContext.plyerChessRankViews.ToList();
            plyerChessRankView firstData = DbContext.plyerChessRankViews.FirstOrDefault();
            if (firstData.chessPoints == 0)
            {
                return PartialView("_DefaultPlayerStandingsPartial");
            }
            else
            {
                return PartialView("_ChessPlayerStandingsPartial", model);
            }
        }
        public PartialViewResult TTPlayerStandings()
        {
            Thread.Sleep(1000);
            List<plyerTTRankView> model = DbContext.plyerTTRankViews.ToList();
            plyerTTRankView firstData = DbContext.plyerTTRankViews.FirstOrDefault();
            if (firstData.ttPoints == 0)
            {
                return PartialView("_DefaultPlayerStandingsPartial");
            }
            else
            {
                return PartialView("_TTPlayerStandingsPartial", model);
            }
        }
        public PartialViewResult OverallPlayerStandings()
        {
            Thread.Sleep(1000);
            List<plyerRankView> model = DbContext.plyerRankViews.ToList();
            plyerRankView firstData = DbContext.plyerRankViews.FirstOrDefault();
            if (firstData.totalPoints == 0)
            {
                return PartialView("_DefaultPlayerStandingsPartial");
            }
            else
            {
                return PartialView("_OverallPlayerStandingsPartial", model);
            }
          
        }

    }
}