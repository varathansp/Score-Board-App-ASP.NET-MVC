//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace ScoreBoardApp.Models
{
    using System;
    using System.Collections.Generic;
    
    public partial class Fixture
    {
        public int gameID { get; set; }
        public string gameType { get; set; }
        public string team1 { get; set; }
        public string team2 { get; set; }
        public string tm1pl1 { get; set; }
        public string tm1pl2 { get; set; }
        public string tm2pl1 { get; set; }
        public string tm2pl2 { get; set; }
        public string venue { get; set; }
        public Nullable<System.DateTime> date { get; set; }
        public string time { get; set; }
        public string team1Score { get; set; }
        public string team2Score { get; set; }
        public string winner { get; set; }
        public string gameName { get; set; }
    }
}
