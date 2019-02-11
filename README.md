# Avengers SkillsUSA

A programming exercise based on the plot of the Marvel movie Captain America: Civil War.

The requirements are below.  Test your skills to see what you can build.

The example solution is built with .NET Core as a console application (written on Mac OS using Visual Studio Code).  Read the *ExampleOutput.md* file to see what it produces.  It is object-oriented, uses dependency injection (for future unit testing), is extensible, validates input, covers all the requirements, and even includes the advanced features.

## Requirements

The Sokovia Accords have split the Marvel Avengers into two factions: *Team Stark* and *Team Cap*.

Seed the application with each team member, including their name, power level, and team.

Randomly select combatants from the available team members of each team to battle each other, team vs. team.

Allow the user to enter the number of combatants that will be chosen equally from each team.  Default to 4 combatants per team.

The winner of each battle is whichever team had the highest combined power level of its combatants.  Battles can end in a tie.

Track a series of battles with re-randomized combatants for each battle.

For each battle, display the results, including:

* Each team name
* Each combatant with their name and power level, and indicate which team they are on
* The total power level of the selected combatants for each team
* Which team won the battle (or if it was a tie)

Allow the user to enter the number of battles to have the Avengers fight.  Default to 5 battles.

Avengers must be unique within each battle, but can be reused in other battles (example: you can’t have a team of 2+ Black Panthers in a battle, but Black Panther could be randomly included in each battle).

Output the results of each of the battles, including the list of combatants, their power level, and their team, indicating each team’s score and which team was the winner (*Team Stark*, *Team Cap*, or a tie).

Determine which team won the most battles, or if it was a tie, and display the results as the winner of the Civil War.

## Seed Data

### Team Stark
* 10 Black Widow
* 20 War Machine
* 30 Spider-Man
* 40 Black Panther
* 50 Iron Man
* 60 Vision

### Team Cap
* 10 Hawkeye
* 20 Falcon
* 30 Ant-Man
* 40 Winter Soldier
* 50 Captain America
* 60 Scarlet Witch

## Advanced Features

1. Allow the user to add their own Avengers (such as Thor or Hulk), with their own custom power level, to either team and include them in the randomized selection for each battle.  Do not allow them to add Avengers that are already in the data.
2. Allow the end user to choose Infinity War mode, where they can battle Thanos (200 power level) against a total of 5 randomly selected combatants from both teams of Avengers combined, and output the result of the one-battle war.  The battle/war can end in a tie.  If the Avengers lose, randomly select 50% of all the Avengers from both teams (not just the combatants) to be turned to dust, and output the results of who survived and who perished.
