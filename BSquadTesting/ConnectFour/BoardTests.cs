using BSquadGames.Classes.ConnectFour;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BSquadTesting.ConnectFour
{
    [TestClass]
    public class BoardTests
    {
        // Test for horizontal win condition
        [TestMethod]
        public void CheckWin_HorizontalWin_ReturnsTrue()
        {
            ConnectFourBoard board = new();

            // Place four discs horizontally
            board.SetDiscAt(0, 0, 1);
            board.SetDiscAt(0, 1, 1);
            board.SetDiscAt(0, 2, 1);
            board.SetDiscAt(0, 3, 1);

            board.CheckWinner();

            Assert.IsTrue(board.GameWon);
        }

        // Test for horizontal non-win (broken sequence)
        [TestMethod]
        public void CheckWin_HorizontalNoWin_ReturnsFalse()
        {
            ConnectFourBoard board = new();

            // Interrupt the sequence with a 0 (empty)
            board.SetDiscAt(0, 0, 1);
            board.SetDiscAt(0, 1, 0);
            board.SetDiscAt(0, 2, 1);
            board.SetDiscAt(0, 3, 1);

            board.CheckWinner();

            Assert.IsFalse(board.GameWon);
        }

        // Test for vertical win condition
        [TestMethod]
        public void CheckWin_VerticalWin_ReturnsTrue()
        {
            ConnectFourBoard board = new();

            // Place four discs vertically in the same column
            board.SetDiscAt(0, 0, 1);
            board.SetDiscAt(1, 0, 1);
            board.SetDiscAt(2, 0, 1);
            board.SetDiscAt(3, 0, 1);

            board.CheckWinner();

            Assert.IsTrue(board.GameWon);
        }

        // Test for vertical non-win (interrupted sequence)
        [TestMethod]
        public void CheckWin_VerticalNoWin_ReturnsFalse()
        {
            ConnectFourBoard board = new();

            // Sequence broken by empty cell
            board.SetDiscAt(0, 0, 1);
            board.SetDiscAt(1, 0, 0);
            board.SetDiscAt(2, 0, 1);
            board.SetDiscAt(3, 0, 1);

            board.CheckWinner();

            Assert.IsFalse(board.GameWon);
        }

        // Test diagonal win (up-right direction)
        [TestMethod]
        public void CheckWin_DiagonalUpLeftWin_ReturnsTrue()
        {
            ConnectFourBoard board = new();

            // Diagonal: bottom-left to top-right
            board.SetDiscAt(0, 0, 1);
            board.SetDiscAt(1, 1, 1);
            board.SetDiscAt(2, 2, 1);
            board.SetDiscAt(3, 3, 1);

            board.CheckWinner();

            Assert.IsTrue(board.GameWon);
        }

        // Test diagonal win (up-left direction)
        [TestMethod]
        public void CheckWin_DiagonalUpRightWin_ReturnsTrue()
        {
            ConnectFourBoard board = new();

            // Diagonal: bottom-right to top-left
            board.SetDiscAt(3, 0, 1);
            board.SetDiscAt(2, 1, 1);
            board.SetDiscAt(1, 2, 1);
            board.SetDiscAt(0, 3, 1);

            board.CheckWinner();

            Assert.IsTrue(board.GameWon);
        }

        // Diagonal win on edge case (bottom-right to top-left)
        [TestMethod]
        public void CheckWin_DiagonalUpLeftWin_EdgeBottomRight_ReturnsTrue()
        {
            ConnectFourBoard board = new();

            board.SetDiscAt(2, 6, 1);
            board.SetDiscAt(3, 5, 1);
            board.SetDiscAt(4, 4, 1);
            board.SetDiscAt(5, 3, 1);

            board.CheckWinner();

            Assert.IsTrue(board.GameWon);
        }

        // Diagonal win on edge case (bottom-left to top-right)
        [TestMethod]
        public void CheckWin_DiagonalUpRightWin_EdgeBottomLeft_ReturnsTrue()
        {
            ConnectFourBoard board = new();

            board.SetDiscAt(5, 0, 1);
            board.SetDiscAt(4, 1, 1);
            board.SetDiscAt(3, 2, 1);
            board.SetDiscAt(2, 3, 1);

            board.CheckWinner();

            Assert.IsTrue(board.GameWon);
        }

        // Test for diagonal with broken sequence
        [TestMethod]
        public void CheckWin_DiagonalNoWin_ReturnsFalse()
        {
            ConnectFourBoard board = new();

            // One cell in the diagonal is empty (or wrong)
            board.SetDiscAt(0, 0, 1);
            board.SetDiscAt(1, 1, 0);
            board.SetDiscAt(2, 2, 1);
            board.SetDiscAt(3, 3, 1);

            board.CheckWinner();

            Assert.IsFalse(board.GameWon);
        }

        // Horizontal win at the far right (edge of board)
        [TestMethod]
        public void CheckOutOfBounds_Horizontal()
        {
            ConnectFourBoard board = new();

            board.SetDiscAt(0, 3, 1);
            board.SetDiscAt(0, 4, 1);
            board.SetDiscAt(0, 5, 1);
            board.SetDiscAt(0, 6, 1);

            board.CheckWinner();

            Assert.IsTrue(board.GameWon);
        }

        // Only three in diagonal sequence – should not win
        [TestMethod]
        public void CheckWin_DiagonalUpRight_OnlyThreeInARow_ReturnsFalse()
        {
            ConnectFourBoard board = new();

            board.SetDiscAt(5, 0, 1);
            board.SetDiscAt(4, 1, 1);
            board.SetDiscAt(3, 2, 1);

            board.CheckWinner();

            Assert.IsFalse(board.GameWon);
        }

        // Diagonal sequence interrupted by opponent disc
        [TestMethod]
        public void CheckWin_DiagonalUpLeft_InterruptedSequence_ReturnsFalse()
        {
            ConnectFourBoard board = new();

            board.SetDiscAt(2, 6, 1);
            board.SetDiscAt(3, 5, 2); // opponent disc interrupts
            board.SetDiscAt(4, 4, 1);
            board.SetDiscAt(5, 3, 1);

            board.CheckWinner();

            Assert.IsFalse(board.GameWon);
        }

        // Mixed board with no four-in-a-row
        [TestMethod]
        public void CheckWin_MixedBoard_NoWin_ReturnsFalse()
        {
            ConnectFourBoard board = new();

            // Alternating players, no win condition met
            board.SetDiscAt(0, 0, 1);
            board.SetDiscAt(0, 1, 2);
            board.SetDiscAt(0, 2, 1);
            board.SetDiscAt(0, 3, 2);
            board.SetDiscAt(1, 0, 2);
            board.SetDiscAt(1, 1, 1);
            board.SetDiscAt(1, 2, 2);
            board.SetDiscAt(1, 3, 1);

            board.CheckWinner();

            Assert.IsFalse(board.GameWon);
        }

        // Test vertical win at the top of the board
        [TestMethod]
        public void CheckWin_VerticalWin_TopEdge_ReturnsTrue()
        {
            ConnectFourBoard board = new();

            board.SetDiscAt(2, 0, 1);
            board.SetDiscAt(3, 0, 1);
            board.SetDiscAt(4, 0, 1);
            board.SetDiscAt(5, 0, 1);

            board.CheckWinner();

            Assert.IsTrue(board.GameWon);
        }

        // Diagonal win at top edge
        [TestMethod]
        public void CheckWin_DiagonalUpRight_TopEdge_ReturnsTrue()
        {
            ConnectFourBoard board = new();

            board.SetDiscAt(2, 3, 1);
            board.SetDiscAt(3, 4, 1);
            board.SetDiscAt(4, 5, 1);
            board.SetDiscAt(5, 6, 1);

            board.CheckWinner();

            Assert.IsTrue(board.GameWon);
        }

        // Test with multiple winning sequences present
        [TestMethod]
        public void CheckWin_MultipleWinConditions_ReturnsTrue()
        {
            ConnectFourBoard board = new();

            // Horizontal win
            board.SetDiscAt(0, 0, 1);
            board.SetDiscAt(0, 1, 1);
            board.SetDiscAt(0, 2, 1);
            board.SetDiscAt(0, 3, 1);

            // Diagonal sequence also present (optional)
            board.SetDiscAt(1, 1, 1);
            board.SetDiscAt(2, 2, 1);
            board.SetDiscAt(3, 3, 1);

            board.CheckWinner();

            Assert.IsTrue(board.GameWon);
        }
    }
}
