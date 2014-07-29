using System;
using System.Linq;
using EloWeb.Models;
using NUnit.Framework;
using System.Collections.Generic;

namespace EloWeb.Tests.UnitTests
{
    public class GamesTests
    {
        [Test]
        public void Can_parse_the_text_description_of_a_Game()
        {
            Games.Initialise(new List<String>{"A beat B"});

            var expected = new Game {Winner = "A", Loser = "B"};
            var actual = Games.MostRecent(1).First();

            Assert.That(expected.Equals(actual));
        }

        [Test]
        public void Can_generate_a_text_description_of_a_Game()
        {
            var game = new Game { Winner = "A", Loser = "B" };            
            Assert.AreEqual("A beat B", game.ToString());
        }


        [Test]
        public void Can_store_a_list_of_games()
        {
            Games.Initialise(new List<String> { "A beat B", "A beat C", "B beat C" } );

            var expected = new List<Game>
            {
                new Game {Winner = "A", Loser = "B"},
                new Game {Winner = "A", Loser = "C"},
                new Game {Winner = "B", Loser = "C"},
            };

            Assert.AreEqual(expected, Games.All());
        }

        [Test]
        public void Can_reinitialise_the_list_of_games()
        {
            Games.Initialise(new List<String> { "D beat B", "B beat C", "C beat D" });

            var before = new List<Game>
            {
                new Game {Winner = "D", Loser = "B"},
                new Game {Winner = "B", Loser = "C"},
                new Game {Winner = "C", Loser = "D"},
            };
            Assert.AreEqual(before, Games.All());


            Games.Initialise(new List<String> { "A beat B", "A beat C", "B beat C" });

            var after = new List<Game>
            {
                new Game {Winner = "A", Loser = "B"},
                new Game {Winner = "A", Loser = "C"},
                new Game {Winner = "B", Loser = "C"},
            };

            Assert.AreEqual(after, Games.All());
        }


        [Test]
        public void Can_add_a_game_to_the_list()
        {
            Games.Initialise(new List<String>());

            Games.Add(new Game { Winner = "A", Loser = "B"});
            Games.Add(new Game { Winner = "A", Loser = "C" });
            Games.Add(new Game { Winner = "B", Loser = "C" });

            var expected = new List<Game>
            {
                new Game {Winner = "A", Loser = "B"},
                new Game {Winner = "A", Loser = "C"},
                new Game {Winner = "B", Loser = "C"},
            };

            Assert.AreEqual(expected, Games.All());
        }



        [Test]
        public void Can_retrieve_n_most_recent_games()
        {
            Games.Initialise(new List<String> { "A beat B", "A beat C", "B beat C" });

            var expected = new List<Game>
            {
                new Game {Winner = "A", Loser = "C"},
                new Game {Winner = "B", Loser = "C"},
            };

            Assert.AreEqual(expected, Games.MostRecent(2));
        }

        [Test]
        public void Can_retrieve_games_played_by_a_particular_player()
        {
            Games.Initialise(new List<String> { "A beat B", "A beat C", "B beat C" });

            var expected = new List<Game>
            {
                new Game {Winner = "A", Loser = "B"},
                new Game {Winner = "B", Loser = "C"},
            };

            Assert.AreEqual(expected, Games.GamesByPlayer("B"));
        }



    }
}
