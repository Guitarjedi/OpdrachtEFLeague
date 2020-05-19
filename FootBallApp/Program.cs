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

            var repo = new Repository();
            var team = repo.SelecteerTeam(35);
            team.Naam = "Anderslecht";
            repo.UpdateTeam(team);

           
        }
    }
}
