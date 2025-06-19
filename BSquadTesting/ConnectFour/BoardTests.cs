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
            ConnectFourGameManager manager = new ConnectFourGameManager();

            // Place four discs horizontally
            manager.ConnectFourBoard.SetDiscAt(0, 0, 1);
            manager.ConnectFourBoard.SetDiscAt(0, 1, 1);
            manager.ConnectFourBoard.SetDiscAt(0, 2, 1);
            manager.ConnectFourBoard.SetDiscAt(0, 3, 1);

            manager.CheckWinner();

            Assert.IsTrue(manager.GameWon);
        }

        // Test for horizontal non-win (broken sequence)
        [TestMethod]
        public void CheckWin_HorizontalNoWin_ReturnsFalse()
        {
            ConnectFourGameManager manager = new ConnectFourGameManager();

            // Interrupt the sequence with a 0 (empty)
            manager.ConnectFourBoard.SetDiscAt(0, 0, 1);
            manager.ConnectFourBoard.SetDiscAt(0, 1, 0);
            manager.ConnectFourBoard.SetDiscAt(0, 2, 1);
            manager.ConnectFourBoard.SetDiscAt(0, 3, 1);

            manager.CheckWinner();

            Assert.IsFalse(manager.GameWon);
        }

        // Test for vertical win condition
        [TestMethod]
        public void CheckWin_VerticalWin_ReturnsTrue()
        {
            ConnectFourGameManager manager = new ConnectFourGameManager();

            // Place four discs vertically in the same column
            manager.ConnectFourBoard.SetDiscAt(0, 0, 1);
            manager.ConnectFourBoard.SetDiscAt(1, 0, 1);
            manager.ConnectFourBoard.SetDiscAt(2, 0, 1);
            manager.ConnectFourBoard.SetDiscAt(3, 0, 1);

            manager.CheckWinner();

            Assert.IsTrue(manager.GameWon);
        }

        // Test for vertical non-win (interrupted sequence)
        [TestMethod]
        public void CheckWin_VerticalNoWin_ReturnsFalse()
        {
            ConnectFourGameManager manager = new ConnectFourGameManager();

            // Sequence broken by empty cell
            manager.ConnectFourBoard.SetDiscAt(0, 0, 1);
            manager.ConnectFourBoard.SetDiscAt(1, 0, 0);
            manager.ConnectFourBoard.SetDiscAt(2, 0, 1);
            manager.ConnectFourBoard.SetDiscAt(3, 0, 1);

            manager.CheckWinner();

            Assert.IsFalse(manager.GameWon);
        }

        // Test diagonal win (up-right direction)
        [TestMethod]
        public void CheckWin_DiagonalUpLeftWin_ReturnsTrue()
        {
            ConnectFourGameManager manager = new ConnectFourGameManager();

            // Diagonal: bottom-left to top-right
            manager.ConnectFourBoard.SetDiscAt(0, 0, 1);
            manager.ConnectFourBoard.SetDiscAt(1, 1, 1);
            manager.ConnectFourBoard.SetDiscAt(2, 2, 1);
            manager.ConnectFourBoard.SetDiscAt(3, 3, 1);

            manager.CheckWinner();

            Assert.IsTrue(manager.GameWon);
        }

        // Test diagonal win (up-left direction)
        [TestMethod]
        public void CheckWin_DiagonalUpRightWin_ReturnsTrue()
        {
            ConnectFourGameManager manager = new ConnectFourGameManager();

            // Diagonal: bottom-right to top-left
            manager.ConnectFourBoard.SetDiscAt(3, 0, 1);
            manager.ConnectFourBoard.SetDiscAt(2, 1, 1);
            manager.ConnectFourBoard.SetDiscAt(1, 2, 1);
            manager.ConnectFourBoard.SetDiscAt(0, 3, 1);

            manager.CheckWinner();

            Assert.IsTrue(manager.GameWon);
        }

        // Diagonal win on edge case (bottom-right to top-left)
        [TestMethod]
        public void CheckWin_DiagonalUpLeftWin_EdgeBottomRight_ReturnsTrue()
        {
            ConnectFourGameManager manager = new ConnectFourGameManager();

            manager.ConnectFourBoard.SetDiscAt(2, 6, 1);
            manager.ConnectFourBoard.SetDiscAt(3, 5, 1);
            manager.ConnectFourBoard.SetDiscAt(4, 4, 1);
            manager.ConnectFourBoard.SetDiscAt(5, 3, 1);

            manager.CheckWinner();

            Assert.IsTrue(manager.GameWon);
        }

        // Diagonal win on edge case (bottom-left to top-right)
        [TestMethod]
        public void CheckWin_DiagonalUpRightWin_EdgeBottomLeft_ReturnsTrue()
        {
            ConnectFourGameManager manager = new ConnectFourGameManager();

            manager.ConnectFourBoard.SetDiscAt(5, 0, 1);
            manager.ConnectFourBoard.SetDiscAt(4, 1, 1);
            manager.ConnectFourBoard.SetDiscAt(3, 2, 1);
            manager.ConnectFourBoard.SetDiscAt(2, 3, 1);

            manager.CheckWinner();

            Assert.IsTrue(manager.GameWon);
        }

        // Test for diagonal with broken sequence
        [TestMethod]
        public void CheckWin_DiagonalNoWin_ReturnsFalse()
        {
            ConnectFourGameManager manager = new ConnectFourGameManager();

            // One cell in the diagonal is empty (or wrong)
            manager.ConnectFourBoard.SetDiscAt(0, 0, 1);
            manager.ConnectFourBoard.SetDiscAt(1, 1, 0);
            manager.ConnectFourBoard.SetDiscAt(2, 2, 1);
            manager.ConnectFourBoard.SetDiscAt(3, 3, 1);

            manager.CheckWinner();

            Assert.IsFalse(manager.GameWon);
        }

        // Horizontal win at the far right (edge of board)
        [TestMethod]
        public void CheckOutOfBounds_Horizontal()
        {
            ConnectFourGameManager manager = new ConnectFourGameManager();

            manager.ConnectFourBoard.SetDiscAt(0, 3, 1);
            manager.ConnectFourBoard.SetDiscAt(0, 4, 1);
            manager.ConnectFourBoard.SetDiscAt(0, 5, 1);
            manager.ConnectFourBoard.SetDiscAt(0, 6, 1);

            manager.CheckWinner();

            Assert.IsTrue(manager.GameWon);
        }

        // Only three in diagonal sequence – should not win
        [TestMethod]
        public void CheckWin_DiagonalUpRight_OnlyThreeInARow_ReturnsFalse()
        {
            ConnectFourGameManager manager = new ConnectFourGameManager();

            manager.ConnectFourBoard.SetDiscAt(5, 0, 1);
            manager.ConnectFourBoard.SetDiscAt(4, 1, 1);
            manager.ConnectFourBoard.SetDiscAt(3, 2, 1);

            manager.CheckWinner();

            Assert.IsFalse(manager.GameWon);
        }

        // Diagonal sequence interrupted by opponent disc
        [TestMethod]
        public void CheckWin_DiagonalUpLeft_InterruptedSequence_ReturnsFalse()
        {
            ConnectFourGameManager manager = new ConnectFourGameManager();

            manager.ConnectFourBoard.SetDiscAt(2, 6, 1);
            manager.ConnectFourBoard.SetDiscAt(3, 5, 2); // opponent disc interrupts
            manager.ConnectFourBoard.SetDiscAt(4, 4, 1);
            manager.ConnectFourBoard.SetDiscAt(5, 3, 1);

            manager.CheckWinner();

            Assert.IsFalse(manager.GameWon);
        }

        // Mixed board with no four-in-a-row
        [TestMethod]
        public void CheckWin_MixedBoard_NoWin_ReturnsFalse()
        {
            ConnectFourGameManager manager = new ConnectFourGameManager();

            // Alternating players, no win condition met
            manager.ConnectFourBoard.SetDiscAt(0, 0, 1);
            manager.ConnectFourBoard.SetDiscAt(0, 1, 2);
            manager.ConnectFourBoard.SetDiscAt(0, 2, 1);
            manager.ConnectFourBoard.SetDiscAt(0, 3, 2);
            manager.ConnectFourBoard.SetDiscAt(1, 0, 2);
            manager.ConnectFourBoard.SetDiscAt(1, 1, 1);
            manager.ConnectFourBoard.SetDiscAt(1, 2, 2);
            manager.ConnectFourBoard.SetDiscAt(1, 3, 1);

            manager.CheckWinner();

            Assert.IsFalse(manager.GameWon);
        }

        // Test vertical win at the top of the board
        [TestMethod]
        public void CheckWin_VerticalWin_TopEdge_ReturnsTrue()
        {
            ConnectFourGameManager manager = new ConnectFourGameManager();

            manager.ConnectFourBoard.SetDiscAt(2, 0, 1);
            manager.ConnectFourBoard.SetDiscAt(3, 0, 1);
            manager.ConnectFourBoard.SetDiscAt(4, 0, 1);
            manager.ConnectFourBoard.SetDiscAt(5, 0, 1);

            manager.CheckWinner();

            Assert.IsTrue(manager.GameWon);
        }

        // Diagonal win at top edge
        [TestMethod]
        public void CheckWin_DiagonalUpRight_TopEdge_ReturnsTrue()
        {
            ConnectFourGameManager manager = new ConnectFourGameManager();

            manager.ConnectFourBoard.SetDiscAt(2, 3, 1);
            manager.ConnectFourBoard.SetDiscAt(3, 4, 1);
            manager.ConnectFourBoard.SetDiscAt(4, 5, 1);
            manager.ConnectFourBoard.SetDiscAt(5, 6, 1);

            manager.CheckWinner();

            Assert.IsTrue(manager.GameWon);
        }

        // Test with multiple winning sequences present
        [TestMethod]
        public void CheckWin_MultipleWinConditions_ReturnsTrue()
        {
            ConnectFourGameManager manager = new ConnectFourGameManager();

            // Horizontal win
            manager.ConnectFourBoard.SetDiscAt(0, 0, 1);
            manager.ConnectFourBoard.SetDiscAt(0, 1, 1);
            manager.ConnectFourBoard.SetDiscAt(0, 2, 1);
            manager.ConnectFourBoard.SetDiscAt(0, 3, 1);

            // Diagonal sequence also present (optional)
            manager.ConnectFourBoard.SetDiscAt(1, 1, 1);
            manager.ConnectFourBoard.SetDiscAt(2, 2, 1);
            manager.ConnectFourBoard.SetDiscAt(3, 3, 1);

            manager.CheckWinner();

            Assert.IsTrue(manager.GameWon);
        }
    }
}
