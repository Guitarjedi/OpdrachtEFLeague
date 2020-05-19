using FootBallLib;
using FootBallLib.Models;
using System;
using System.Transactions;

namespace FootBallApp
{
    class Program
    {
        static void Main(string[] args)
        {
            var db = new Repository();
            db.InitializeDatabase(@"C:\Users\Matthijs\Documents\HBO5Programmeren\Jaar1Sem2\Progr4\EF\foot.csv");

            var team = EntityFactory.NieuwTeam("Club Brokke", 89, "De Broegjes", "Jean-Cleade");
            var speler = EntityFactory.NieuweSpeler(456, "Rich Guy", 45896, team);
            team.Spelers.Add(speler);
            try
            {
                db.VoegTeamToe(team);
            }
            catch(Exception e)
            {
                Console.WriteLine(e.Message);
            }
            var team2 = EntityFactory.NieuwTeam("Club Brakke", 82, "De Broegjes", "Jean - Cleade");
            try
            {
                db.VoegTeamToe(team2);
            }
            catch(Exception e)
            {
                Console.WriteLine(e.Message);
            }
            team2.Spelers.Add(EntityFactory.NieuweSpeler(46, "Pieter de Boef", 4589006, team2));

            var transfer = new Transfer() { NewTeam = team, OldTeam = team2, Speler = EntityFactory.NieuweSpeler(78, "TransferSpeler", 0, team) };
            db.VoegTransferToe(transfer);

            speler.Waarde = 9999999;
            db.UpdateSpeler(speler);

            team.Trainer = "nieuwe trainer";
            db.UpdateTeam(team);
        }
    }
}
