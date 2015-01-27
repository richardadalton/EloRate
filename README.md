EloRate
=======

[![Gitter](https://badges.gitter.im/Join%20Chat.svg)](https://gitter.im/richardadalton/EloRate?utm_source=badge&utm_medium=badge&utm_campaign=pr-badge&utm_content=badge)

An ELO Rating system for ranking players in 2 player games, e.g. Chess, Pool etc.


*Data*
The app currently stores all of it's data in text files. These are kept in the 

src\App_Data folder

Players.txt
Contains a list of all of the players. Even if a player retires/leaves the league, their name remains in this file.

RetiredPlayers.txt
If a player retires or otherwise leaves the league, then add their name to this file. Their games will still count towards other 
players ratings, and any "All-Time" records they hold will be maintained, but their name will not appear on the current leaderboard,
or current records.

Games.txt
This simply lists the games played. Each game is placed on a separate line using the following format.

Richard beat John
Paul beat Bill
Mary beat Paul

etc.


*Records*
In addition to the Elo Rating Leaderboard, the app provides details of a range of of "Records"

All-Time Rating
The highest rating ever achieved by a player.

Current Rating
The Current highest rating.

All-Time Winning Streak
The most consecutive wins ever recorded.

Current Winning Streak
The player with the most wins since their last defeat.

Most Games Played
The player who has played the most
