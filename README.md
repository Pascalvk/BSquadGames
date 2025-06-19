# BSquadGames
Code written by Pascalvk & TheMumbleKing.  
Some comments were generated with AI assistance to streamline the documentation process.  
This project is intended for learning purposes only.

# Connect Four Game - BSquadGames

This project contains an implementation of the classic **Connect Four** board game in C#, including comprehensive unit tests with MSTest.

## 📦 Project Structure
- **BSquadGames.Components.Pages.ConnectFour.ConnectMain.razor**  
  Implements the user interface using Blazor components and Razor syntax.  
  Handles rendering the Connect Four game board, user interactions (clicks, mouseovers), and game state display.
  
- **BSquadGames.Classes.ConnectFour.ConnectFourBoard.cs**  
  Contains the core game logic such as the board, win conditions, and valid moves.

- **BSquadTesting.ConnectFour.BoardTest.cs**  
  Contains unit tests for all important game board logic (win checks, valid moves, etc).

## 🔧 Features

- 6x7 playing field (standard Connect Four size).
- Supports 2 players (Player 1 and Player 2).
- Detects horizontal, vertical, and diagonal winning conditions.
- Checks valid moves following gravity rules.
- Ability to start a new game via `StartNewGame`.

## 🧪 Testing

The `BoardTests` class includes unit tests for:

- Horizontal, vertical, and diagonal wins.
- Edge cases such as wins at board edges.
- No-win scenarios with interrupted sequences.
- Multiple simultaneous win conditions.
- Verification of legal moves considering gravity.

All tests use MSTest’s `Assert` methods. Run them via Visual Studio Test Explorer or CLI.


