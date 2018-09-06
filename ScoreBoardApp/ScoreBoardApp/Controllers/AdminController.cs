using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ScoreBoardApp.Models;
using System.Web.Security;
using System.Security.Principal;

namespace ScoreBoardApp.Controllers
{
    public class AdminController : Controller
    {
        ScoreBoardDBEntities DbContext = new ScoreBoardDBEntities();
        // GET: Admin
        public ActionResult Login()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Login(UserIdentity userIdentity)
        {
            if (ModelState.IsValid)
            {
                UserIdentity user = DbContext.UserIdentities
                      .SingleOrDefault(x => x.userName == userIdentity.userName && x.password == userIdentity.password);
                if (user != null)
                {
                    FormsAuthentication.SetAuthCookie(userIdentity.userName, true);

                    return RedirectToAction("TeamIndex", "Admin");
                }
                else
                {
                    ModelState.AddModelError(string.Empty, "User Name or Password is invalid");

                }
            }
            return View(userIdentity);
        }

        [Authorize]
        public ActionResult TeamIndex()
        {
            return View(DbContext.Teams.ToList().OrderByDescending(x=>x.ttPoints).ThenBy(x=>x.teamName));
        }
        [Authorize]
        public ActionResult CreateTeam()
        {
            return View();
        }
        [Authorize]
        [HttpPost]
        public ActionResult CreateTeam(Team team)
        {

            if (ModelState.IsValid)
            {
                if (DbContext.Teams.SingleOrDefault(x => x.teamName == team.teamName) == null)
                {
                    Team newTeam = new Team();
                    newTeam.teamName = team.teamName;
                    newTeam.caromPoints = newTeam.chessPoints = newTeam.ttPoints = newTeam.badmintonPoints = newTeam.totalPoints = 0;
                    DbContext.Teams.Add(newTeam);
                    DbContext.SaveChanges();
                    return RedirectToAction("TeamIndex");
                }
                else
                {
                    ModelState.AddModelError(string.Empty, "Team Name is already taken.");
                    return View(team);
                }
            }

            else
            {
                return View(team);
            }

        }
        public JsonResult IsTeamNameAvailable(string teamName)
        {
            return Json(!DbContext.Teams.Any(x => x.teamName == teamName), JsonRequestBehavior.AllowGet);
        }
        [Authorize]
        public ActionResult EditTeam(string teamName)
        {
            return View(DbContext.Teams.SingleOrDefault(x => x.teamName == teamName));
        }
        [Authorize]
        [HttpPost]
        public ActionResult EditTeam(Team team)
        {
            Team selectedTeam = DbContext.Teams.SingleOrDefault(x => x.teamName == team.teamName);
            selectedTeam.caromPoints = team.caromPoints; selectedTeam.ttPoints = team.ttPoints;
            selectedTeam.chessPoints = team.chessPoints; selectedTeam.badmintonPoints = team.badmintonPoints;
            selectedTeam.totalPoints = team.totalPoints;
            DbContext.SaveChanges();
            return RedirectToAction("TeamIndex");
        }
        [Authorize]
        public ActionResult DeleteTeam(string teamName)
        {
            Team team = DbContext.Teams.SingleOrDefault(x => x.teamName == teamName);
            DbContext.Teams.Remove(team);
            DbContext.SaveChanges();
            return RedirectToAction("TeamIndex");
        }
        [Authorize]
        public ActionResult PlayerIndex()
        {
            return View(DbContext.Players.ToList().OrderByDescending(x=>x.ttPoints).ThenBy(x=>x.playerName));
        }
        [Authorize]
        public ActionResult CreatePlayer()
        {
            List<SelectListItem> ddlTeam = new List<SelectListItem>();
            List<Team> teamList = DbContext.Teams.ToList();
            foreach (var data in teamList)
            {
                ddlTeam.Add(new SelectListItem { Text = data.teamName, Value = data.teamName });
            }
            ViewBag.team = ddlTeam;
            return View();
        }
        [Authorize]
        [HttpPost]
        public ActionResult CreatePlayer(Player player)
        {

            if (ModelState.IsValid)
            {
                if (DbContext.Players.SingleOrDefault(x => x.playerName == player.playerName) == null)
                {
                    Player newPlayer = new Player();
                    newPlayer.playerName = player.playerName;
                    newPlayer.employeeID = player.employeeID;
                    newPlayer.team = player.team;
                    newPlayer.badmintonPoints = newPlayer.chessPoints = newPlayer.caromPoints = newPlayer.ttPoints = newPlayer.totalPoints = 0;
                    DbContext.Players.Add(newPlayer);
                    DbContext.SaveChanges();
                    return RedirectToAction("PlayerIndex");
                }
                else
                {
                    ModelState.AddModelError(string.Empty, "Player name is already taken.");
                    return View(player);
                }
            }

            else
            {
                return View(player);
            }

        }
        public JsonResult IsPlayerNameAvailable(string playerName)
        {
            return Json(!DbContext.Players.Any(x => x.playerName == playerName),JsonRequestBehavior.AllowGet);
        }
        [Authorize]
        public ActionResult DeletePlayer(string playerName)
        {
            Player player = DbContext.Players.SingleOrDefault(x => x.playerName == playerName);
            DbContext.Players.Remove(player);
            DbContext.SaveChanges();
            return RedirectToAction("PlayerIndex");
        }
        [Authorize]
        public ActionResult EditPlayer(string playerName)
        {
            return View(DbContext.Players.SingleOrDefault(x => x.playerName == playerName));
        }
        [Authorize]
        [HttpPost]
        public ActionResult EditPlayer(Player player)
        {
            Player selectedPlayer = DbContext.Players.SingleOrDefault(x => x.playerName == player.playerName);
            selectedPlayer.caromPoints = player.caromPoints; selectedPlayer.ttPoints = player.ttPoints;
            selectedPlayer.chessPoints = player.chessPoints; selectedPlayer.badmintonPoints = player.badmintonPoints;
            selectedPlayer.totalPoints = player.totalPoints;
            selectedPlayer.team = player.team;
            DbContext.SaveChanges();
            return RedirectToAction("PlayerIndex");
        }
        [Authorize]
        public ActionResult LogOff()
        {
            FormsAuthentication.SignOut();
            return RedirectToAction("Index", "Home");
        }

    }
}