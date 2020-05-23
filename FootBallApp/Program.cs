using FootBallLib;
using FootBallLib.Models;
using Microsoft.EntityFrameworkCore.Update.Internal;
using System;
using System.Transactions;

namespace FootBallApp
{
    class Program
    {
        static void Main(string[] args)
        {

            var repo = new Repository();
            var speler = repo.SelecteerSpeler(40);
            speler.Team = EntityFactory.NieuwTeam("Brogej2", 567, "bla", "bli");
            repo.UpdateSpeler(speler);
            Console.WriteLine();
           
        }
    }
}
