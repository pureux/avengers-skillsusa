# Civil War

Did not add any custom Avengers, just played Civil War.  A tie occurred in one battle but not in the war.

```
Avengers SkillsUSA

Add another Avenger? [yes/no]
no

1 Civil War
2 Infinity War
Which war will you fight? [1]
1

How many Avengers per team should fight? [4]
4

How many battles should the teams fight? [5]
5
Battle 1
========================================
Team Stark                           180
  Iron Man                            50
  Vision                              60
  Black Panther                       40
  Spider-Man                          30
----------------------------------------
Team Cap                             150
  Captain America                     50
  Ant-Man                             30
  Hawkeye                             10
  Scarlet Witch                       60
----------------------------------------
WINNER                        Team Stark

Battle 2
========================================
Team Stark                           160
  War Machine                         20
  Spider-Man                          30
  Vision                              60
  Iron Man                            50
----------------------------------------
Team Cap                             130
  Winter Soldier                      40
  Scarlet Witch                       60
  Hawkeye                             10
  Falcon                              20
----------------------------------------
WINNER                        Team Stark

Battle 3
========================================
Team Stark                           150
  Spider-Man                          30
  Iron Man                            50
  Black Widow                         10
  Vision                              60
----------------------------------------
Team Cap                             150
  Ant-Man                             30
  Scarlet Witch                       60
  Winter Soldier                      40
  Falcon                              20
----------------------------------------
WINNER                               Tie

Battle 4
========================================
Team Stark                           170
  Iron Man                            50
  Black Panther                       40
  War Machine                         20
  Vision                              60
----------------------------------------
Team Cap                             140
  Hawkeye                             10
  Ant-Man                             30
  Scarlet Witch                       60
  Winter Soldier                      40
----------------------------------------
WINNER                        Team Stark

Battle 5
========================================
Team Stark                           120
  Spider-Man                          30
  Black Widow                         10
  Vision                              60
  War Machine                         20
----------------------------------------
Team Cap                             150
  Captain America                     50
  Ant-Man                             30
  Scarlet Witch                       60
  Hawkeye                             10
----------------------------------------
WINNER                          Team Cap

Battles Won
========================================
Team Stark                             3
Tie                                    1
Team Cap                               1
----------------------------------------
CIVIL WAR WINNER              Team Stark
```

# Infinity War

Added *Captain Marvel* but in this instance she wasn't randomly selected as a combatant, and the Avengers lost to Thanos (and consequently 50% were turned to dust).

```
Avengers SkillsUSA

Add another Avenger? [yes/no]
yes
What is their name?
Captain Marvel
What is their power level? [1-200] [30]
100
What team are they on?
Avengers

Add another Avenger? [yes/no]
no

1 Civil War
2 Infinity War
Which war will you fight? [1]
2
Battle 1
========================================
Avengers                             180
  Vision                              60
  Black Widow                         10
  Winter Soldier                      40
  Spider-Man                          30
  Black Panther                       40
----------------------------------------
Thanos                               200
  Thanos                             200
----------------------------------------
WINNER                            Thanos

Thanos defeated the Avengers and turned half of them to dust!

Avengers
========================================
Black Widow                         Dust
War Machine                         Safe
Spider-Man                          Dust
Black Panther                       Dust
Iron Man                            Safe
Vision                              Dust
Hawkeye                             Dust
Falcon                              Dust
Ant-Man                             Safe
Winter Soldier                      Safe
Captain America                     Safe
Scarlet Witch                       Dust
Captain Marvel                      Safe
```

# Additional Teams

Specifying a team name other than *Team Stark* or *Team Cap* when adding another Avenger creates a whole other team for the battles/war, this time ending in a three-way tie.

```
Avengers SkillsUSA

Add another Avenger? [yes/no]
yes
What is their name?
Hulk
What is their power level? [1-200] [30]
150
What team are they on?
New Team

Add another Avenger? [yes/no]
no

1 Civil War
2 Infinity War
Which war will you fight? [1]
1

How many Avengers per team should fight? [4]
4

How many battles should the teams fight? [5]
3
Battle 1
========================================
Team Stark                           150
  Spider-Man                          30
  Iron Man                            50
  Black Widow                         10
  Vision                              60
----------------------------------------
Team Cap                             160
  Winter Soldier                      40
  Hawkeye                             10
  Captain America                     50
  Scarlet Witch                       60
----------------------------------------
New Team                             150
  Hulk                               150
----------------------------------------
WINNER                          Team Cap

Battle 2
========================================
Team Stark                           180
  Vision                              60
  Black Panther                       40
  Iron Man                            50
  Spider-Man                          30
----------------------------------------
Team Cap                             150
  Scarlet Witch                       60
  Winter Soldier                      40
  Falcon                              20
  Ant-Man                             30
----------------------------------------
New Team                             150
  Hulk                               150
----------------------------------------
WINNER                        Team Stark

Battle 3
========================================
Team Stark                           130
  Black Widow                         10
  Iron Man                            50
  Spider-Man                          30
  Black Panther                       40
----------------------------------------
Team Cap                             130
  Hawkeye                             10
  Ant-Man                             30
  Captain America                     50
  Winter Soldier                      40
----------------------------------------
New Team                             150
  Hulk                               150
----------------------------------------
WINNER                          New Team

Battles Won
========================================
Team Cap                               1
Team Stark                             1
New Team                               1
----------------------------------------
CIVIL WAR WINNER                     Tie
```

# Validation

Numeric fields are validated.

```
How many Avengers per team should fight? [4]
20
You must enter a whole number between 1 and 6.
5
```

New Avenger names cannot match existing Avengers.

```
Add another Avenger? [yes/no]
yes
What is their name?
Vision
You must enter a value. It cannot be any of the following: / Ant-Man / Black Panther / Black Widow / Captain America / Falcon / Hawkeye / Iron Man / Scarlet Witch / Spider-Man / Vision / War Machine / Winter Soldier /
```