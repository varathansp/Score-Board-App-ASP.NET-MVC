using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Web.Mvc;

namespace ScoreBoardApp.Models
{
    [MetadataType(typeof(UserIdentityMetaData))]
    public partial class UserIdentity
    { }
    public class UserIdentityMetaData
    {
        [Required]
        [Display(Name = "User Name")]
        public string userName { get; set; }
        [Required]
        [Display(Name = "Password")]
        [DataType(DataType.Password)]
        public string password { get; set; }
    }
    [MetadataType(typeof(TeamMetaData))]
    public partial class Team
    { }
    public class TeamMetaData
    {
        [Required]
        [Display(Name = "Team Name")]
        [Remote("IsTeamNameAvailable", "Admin", ErrorMessage = "Team name is already taken.")]
        public string teamName { get; set; }
        [Display(Name = "Badminton Points")]
        public Nullable<int> badmintonPoints { get; set; }
        [Display(Name = "Carrom Points")]
        public Nullable<int> caromPoints { get; set; }
        [Display(Name = "Chess Points")]
        public Nullable<int> chessPoints { get; set; }
        [Display(Name = "TT Points")]
        public Nullable<int> ttPoints { get; set; }
        [Display(Name = "Total Points")]
        public Nullable<int> totalPoints { get; set; }
    }
    [MetadataType(typeof(PlayerMetaData))]
    public partial class Player
    { }
    public class PlayerMetaData
    {
        [Required]
        [Display(Name = "Name")]
        [Remote("IsPlayerNameAvailable", "Admin", ErrorMessage = "Player name is already taken.")]
        public string playerName { get; set; }
        [Required]
        [Display(Name = "Employe ID")]
        public Nullable<int> employeeID { get; set; }
        [Required]
        [Display(Name = "Team")]
        public string team { get; set; }
        [Display(Name = "Badminton Points")]
        public Nullable<int> badmintonPoints { get; set; }
        [Display(Name = "Carom Points")]
        public Nullable<int> caromPoints { get; set; }
        [Display(Name = "Chess Points")]
        public Nullable<int> chessPoints { get; set; }
        [Display(Name = "TT Points")]
        public Nullable<int> ttPoints { get; set; }
        [Display(Name = "Total Points")]
        public Nullable<int> totalPoints { get; set; }
    }
    [MetadataType(typeof(FixtureMetaData))]
    public partial class Fixture
    { }
    public class FixtureMetaData
    {
        [Display(Name ="Game ID")]
        public int gameID { get; set; }
        [Required]
        [Display(Name ="Type")]
       public string gameType { get; set; }
        [Required]
        [Display(Name = "Game")]
        public string gameName { get; set; }
        [Required]
        [Display(Name ="Team 1")]
        public string team1 { get; set; }
        [Required]
        [Display(Name = "Team 2")]
        public string team2 { get; set; }
        [Required]
        [Display(Name ="Player1")]
        public string tm1pl1 { get; set; }
        [Display(Name = "Player2")]
        public string tm1pl2 { get; set; }
        [Required]
        [Display(Name = "Player1")]
        public string tm2pl1 { get; set; }
        [Display(Name = "Player2")]
        public string tm2pl2 { get; set; }
        [Required]
        [Display(Name ="Venue")]
        public string venue { get; set; }
        [Required]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:MM/dd/yyyy}")]
        [Display(Name ="Date")]
        public Nullable<System.DateTime> date { get; set; }
        [Required]
        [Display(Name ="Time")]
        public string time { get; set; }
        [Display(Name ="Team1 Score")]
        public string team1Score { get; set; }
        [Display(Name = "Team2 Score")]
        public string team2Score { get; set; }
        [Display(Name ="Winner")]
        public string winner { get; set; }
    }
    [MetadataType(typeof(TeamRankViewMetaData))]
    public partial class TeamRankView
    { }
    public class TeamRankViewMetaData
    {
        [Display(Name = "Team")]
        public string teamName { get; set; }
        [Display(Name = "Badminton")]
        public Nullable<int> badmintonPoints { get; set; }
        [Display(Name = "Carrom")]
        public Nullable<int> caromPoints { get; set; }
        [Display(Name = "Chess")]
        public Nullable<int> chessPoints { get; set; }
        [Display(Name = "Table Tennis")]
        public Nullable<int> ttPoints { get; set; }
        [Display(Name = "Total Points")]
        public Nullable<int> totalPoints { get; set; }
        [Display(Name = "Rank")]
        public Nullable<long> Rank { get; set; }

    }

}