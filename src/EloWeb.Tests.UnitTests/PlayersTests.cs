using System;
using System.Linq;
using EloWeb.Models;
using NUnit.Framework;
using System.Collections.Generic;

namespace EloWeb.Tests.UnitTests
{
    class PlayersTests
    {
        [Test]
        public void Can_parse_the_text_description_of_a_Player()
        {
            Games.Initialise(new List<String>());
            Players.Initialise(new List<String> { "Richard" });

            var player = Players.PlayerByName("Richard");

            Assert.AreEqual("Richard", player.Name);
            Assert.AreEqual(1000, player.Rating);
        }

    }
}
