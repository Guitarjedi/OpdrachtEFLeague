using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace FootBallLib.Models
{
    public class Team
    {
        public Team(string naam, int stamnummer, string bijnaam, string trainer)
        {
            Naam = naam;
            Stamnummer = stamnummer;
            Bijnaam = bijnaam;
            Trainer = trainer;
        }

        public Team(string naam, int stamnummer, string bijnaam, string trainer, List<Speler> spelers)
        {
            Naam = naam;
            Stamnummer = stamnummer;
            Bijnaam = bijnaam;
            Trainer = trainer;
            Spelers = spelers;
        }

        public Team() { }
        public string Naam { get; set; }
        [Key]
        public int Stamnummer { get; set; }
        public string Bijnaam { get; set; }
        public string Trainer { get; set; }
        public List<Speler> Spelers { get; set; } = new List<Speler>();

        public override bool Equals(Object obj)
        {
            if ((obj == null) || !this.GetType().Equals(obj.GetType()))
            {
                return false;
            }
            else
            {
                Team t = (Team)obj;
                return (Naam == t.Naam) && (Stamnummer == t.Stamnummer);
            }
        }
    }
}
