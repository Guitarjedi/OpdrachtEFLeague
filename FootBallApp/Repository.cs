using FootBallLib;
using FootBallLib.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Http.Headers;
using System.Text;

namespace FootBallApp
{
    public class Repository
    {
        private FootBallContext _context = new FootBallContext();

        public void InitializeDatabase(string path)
        {
            using (StreamReader reader = new StreamReader(path))
            {
                HashSet<Speler> spelers = new HashSet<Speler>();
                Dictionary<string, Team> teams = new Dictionary<string, Team>();

                string naam; int nummer; long waarde; string clubNaam;
                int stamNr; string trainer; string bijnaam;
                string s = String.Empty;
                reader.ReadLine();

                while ((s = reader.ReadLine()) != null)
                {
                    var sArray = s.Split(",").Select(x => x.Trim()).ToArray();
                    naam = sArray[0];
                    nummer = Convert.ToInt32(sArray[1]);
                    clubNaam = sArray[2];
                    waarde = long.Parse(sArray[3].Replace(" ", String.Empty));
                    stamNr = Convert.ToInt32(sArray[4]);
                    trainer = sArray[5];
                    bijnaam = sArray[6];

                    if (!teams.ContainsKey(clubNaam)) teams.Add(clubNaam, new Team(clubNaam, stamNr, bijnaam, trainer));
                    spelers.Add(new Speler(naam, nummer, waarde, teams[clubNaam]));

                };
                _context.AddRange(spelers);
                _context.SaveChanges();



            }
        }
        public void VoegSpelerToe(Speler speler)
        {
            if (_context.Spelers.Contains(speler)) throw new Exception($"Speler({speler.Naam}) already present in the database");
            var team = _context.Teams.Where(t => t.Stamnummer == speler.Team.Stamnummer).FirstOrDefault() ?? speler.Team;
            _context.Add(EntityFactory.NieuweSpeler(speler.Rugnummer, speler.Naam, speler.Waarde, team));
            _context.SaveChanges();

        }
        public void VoegTeamToe(Team team)
        {

            if (_context.Teams.Contains(team)) throw new Exception($"Team({team.Naam}) already present in the database");
            _context.Add(team);
            _context.SaveChanges();

        }
        public void VoegTransferToe(Transfer tranfer)
        {
            Team newTeam;
            if ((newTeam = SelecteerTeam(tranfer.NewTeam.Stamnummer)) != null)
            {
                Team oldTeam;
                if ((oldTeam = SelecteerTeam(tranfer.OldTeam.Stamnummer)) != null)
                {
                    tranfer = EntityFactory.NieuweTransfer(tranfer.Speler, oldTeam, newTeam, tranfer.TranferPrijs);
                }
                tranfer = EntityFactory.NieuweTransfer(tranfer.Speler, tranfer.OldTeam, newTeam, tranfer.TranferPrijs);

            }
            _context.Add(tranfer);
            _context.SaveChanges();
            tranfer.Speler.Team = newTeam;
            UpdateSpeler(tranfer.Speler);

        }
        public Team SelecteerTeam(int stamNummer)
        {

            return _context.Teams.Include(s => s.Spelers).Where(t => t.Stamnummer == stamNummer).FirstOrDefault();

        }
        public Speler SelecteerSpeler(int spelerId)
        {
            return _context.Spelers.Include(s => s.Team).Where(s => s.Id == spelerId).FirstOrDefault();
        }
        public Transfer SelecteerTransfer(int transferId)
        {
            return _context.Tranfers.Include(t => t.OldTeam).ThenInclude(t => t.Spelers)
                .Include(t => t.NewTeam).ThenInclude(t => t.Spelers)
                .Include(t => t.Speler).Where(t => t.Id == transferId).FirstOrDefault();

        }
        public void UpdateSpeler(Speler speler)
        {
            //var oldSpeler = SelecteerSpeler(speler.Id);
            //if (oldSpeler == null) throw new Exception($"Speler{speler.Id} not found");
            //oldSpeler = speler;
            _context.SaveChanges();

        }
        public void UpdateTeam(Team team)
        {
            //var oldTeam = SelecteerTeam(team.Stamnummer);
            //if (oldTeam == null) throw new Exception($"Speler{team.Stamnummer} not found");
            //oldTeam = team;
            _context.SaveChanges();
        }


    }
}
