using System;
using System.Collections.Generic;
using System.Text;

namespace FootBallLib.Models
{
    public class Speler
    {
        public Speler(string naam, int rugnummer, long waarde)
        {
            Naam = naam;
            Rugnummer = rugnummer;
            Waarde = waarde;
        }

        public Speler(string naam, int rugnummer, long waarde, Team team)
        {
            Naam = naam;
            Rugnummer = rugnummer;
            Waarde = waarde;
            Team = team;
        }
        public Speler() { }

        public int Id { get; set; }
        public string Naam { get; set; }
        public int Rugnummer { get; set; }
        public long Waarde { get; set; }
        public Team Team { get; set; }
    }
}
