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
    
    public partial class plyerTTRankView
    {
        public string playerName { get; set; }
        public Nullable<int> employeeID { get; set; }
        public string team { get; set; }
        public Nullable<int> badmintonPoints { get; set; }
        public Nullable<int> caromPoints { get; set; }
        public Nullable<int> chessPoints { get; set; }
        public Nullable<int> ttPoints { get; set; }
        public Nullable<int> totalPoints { get; set; }
        public Nullable<long> playerRank { get; set; }
    }
}
