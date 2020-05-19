using System;
using System.Collections.Generic;
using System.Text;

namespace FootBallLib.Models
{
    public static class EntityFactory
    {
        public static Speler NieuweSpeler(int rugNummer, string naam, long waarde, Team team)
        {
            return new Speler(naam, rugNummer, waarde, team);
        }
        public static Team NieuwTeam(string naam, int stamnummer, string bijnaam, string trainer)
        {
            return new Team(naam, stamnummer, bijnaam, trainer);
        }
        public static Transfer NieuweTransfer(Speler speler, Team ot, Team nt, long transferPrijs)
        {
            return new Transfer() { Speler = speler, NewTeam = nt, OldTeam = ot, TranferPrijs = transferPrijs };
        }
    }
}
