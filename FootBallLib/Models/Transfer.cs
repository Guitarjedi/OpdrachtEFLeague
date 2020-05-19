using System;
using System.Collections.Generic;
using System.Text;

namespace FootBallLib.Models
{
    public class Transfer
    {
        public int Id { get; set; }
        public Speler Speler { get; set; }
        public Team OldTeam { get; set; }
        public Team NewTeam { get; set; }
        public long TranferPrijs { get; set; }
    }
}
