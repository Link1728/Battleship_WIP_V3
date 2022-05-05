# Battleship_WIP_V3
A C# console based game of Battleship. This is an improved version of the V2, and it is a Work In Progress.

## Prerequisites
Before you can run this program, ensure that you have the following software installed and functional:
* One of the following operating systems: Windows 7, 8, 8.1, or 10.
* C++ 11

## Running
1. Download the source code from this repository.
2. Compile and run the application.
3. (NOTE) Many functions either don't work or work partially. Continue at your own risk.
4. When prompted, move the ships using the four arrow keys and press the Enter key to place ship.
5. Then, the screen will clear and the entire game board will be drawn with the player ships displayed on hte bottom grid.
6. A prompt will appear near the top right asking for a character and a number. Enter a character, press Enter, enter a number, and press Enter.
7. Any hits will either show as a White "O" or a Red "X".
8. In debug, the coordinates of the enemy ships appear in the top right in Yellow and in a (Ship) (X-coord(s)) / (Y-coord(s)) format. 

## File Summaries
Below is the list of each program file and a brief ecplanation of its role:
* [__Board.cs:__](Board.cs) Creates the grid lines and coordinates (Letters and numbers) for the game board.
* [__GameLoop.cs:__](GameLoop.cs) Dictates the game loop.
* [__UI.cs__](UI.cs) Displays the user interface, which includes coordinate input and coordinates for enemy ships (debug).
* [__EnemyShip.cs__](EnemyShip.cs) Set up the ships included in the Enemy's ShipList.
* [__HitDetection.cs__](HitDetection.cs) Calculates if a ship is hit and whether it is sunk or not.
* [__Player.cs__](Player.cs) Set up the player class, ship placement code, and ship overlap detection.
* [__PlayerShip.cs__](PlayerShip.cs) Set up the ships included in the Player's ShipList.
* [__Ship.cs__](Ship.cs) Set up the initial variables for a single ship.
* [__ShipList.cs__](ShipList.cs) Sets up a dictionary of ships and their respective coordinates.
* [__Program.cs__](Program.cs) Entry point for the application.

## Authors
*[**Brennan Sprague**](https://github.com/b-Sprague) - "Creator"

## License
This project is licensed under the Apache License Version 2.0 - see the [LICENSE](LICENSE) file for details.
