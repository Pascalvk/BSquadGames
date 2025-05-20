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
        [TestMethod]
        public void CheckWin_HorizontalWin_ReturnsTrue()
        {
            ConnectFourBoard board = new();

            board.SetDiscAt(0, 0, 1);
            board.SetDiscAt(0, 1, 1);
            board.SetDiscAt(0, 2, 1);
            board.SetDiscAt(0, 3, 1);

            board.CheckWinner();

            Assert.IsTrue(board.GameWon);
        }

        [TestMethod]
        public void CheckWin_HorizontalNoWin_ReturnsFalse()
        {
            ConnectFourBoard board = new();

            board.SetDiscAt(0, 0, 1);
            board.SetDiscAt(0, 1, 0);
            board.SetDiscAt(0, 2, 1);
            board.SetDiscAt(0, 3, 1);

            board.CheckWinner();

            Assert.IsFalse(board.GameWon);
        }

        [TestMethod]
        public void CheckWin_VerticalWin_ReturnsTrue()
        {
            ConnectFourBoard board = new();

            board.SetDiscAt(0, 0, 1);
            board.SetDiscAt(1, 0, 1);
            board.SetDiscAt(2, 0, 1);
            board.SetDiscAt(3, 0, 1);

            board.CheckWinner();

            Assert.IsTrue(board.GameWon);
        }

        [TestMethod]
        public void CheckWin_VerticalNoWin_ReturnsFalse()
        {
            ConnectFourBoard board = new();

            board.SetDiscAt(0, 0, 1);
            board.SetDiscAt(1, 0, 0);
            board.SetDiscAt(2, 0, 1);
            board.SetDiscAt(3, 0, 1);

            board.CheckWinner();

            Assert.IsFalse(board.GameWon);
        }

        [TestMethod]
        public void CheckWin_DiagonalUpLeftWin_ReturnsTrue()
        {
            ConnectFourBoard board = new();

            board.SetDiscAt(0, 0, 1);
            board.SetDiscAt(1, 1, 1);
            board.SetDiscAt(2, 2, 1);
            board.SetDiscAt(3, 3, 1);

            board.CheckWinner();

            Assert.IsTrue(board.GameWon);
        }

        [TestMethod]
        public void CheckWin_DiagonalUpRightWin_ReturnsTrue()
        {
            ConnectFourBoard board = new();

            board.SetDiscAt(3, 0, 1);
            board.SetDiscAt(2, 1, 1);
            board.SetDiscAt(1, 2, 1);
            board.SetDiscAt(0, 3, 1);

            board.CheckWinner();

            Assert.IsTrue(board.GameWon);
        }

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

        [TestMethod]
        public void CheckWin_DiagonalNoWin_ReturnsFalse()
        {
            ConnectFourBoard board = new();

            board.SetDiscAt(0, 0, 1);
            board.SetDiscAt(1, 1, 0);
            board.SetDiscAt(2, 2, 1);
            board.SetDiscAt(3, 3, 1);

            board.CheckWinner();

            Assert.IsFalse(board.GameWon);
        }


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

        [TestMethod]
        public void CheckWin_DiagonalUpLeft_InterruptedSequence_ReturnsFalse()
        {
            ConnectFourBoard board = new();

            board.SetDiscAt(2, 6, 1);
            board.SetDiscAt(3, 5, 2);
            board.SetDiscAt(4, 4, 1);
            board.SetDiscAt(5, 3, 1);

            board.CheckWinner();

            Assert.IsFalse(board.GameWon);
        }

        [TestMethod]
        public void CheckWin_MixedBoard_NoWin_ReturnsFalse()
        {
            ConnectFourBoard board = new();

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

        [TestMethod]
        public void CheckWin_MultipleWinConditions_ReturnsTrue()
        {
            ConnectFourBoard board = new();

            // Horizontal win
            board.SetDiscAt(0, 0, 1);
            board.SetDiscAt(0, 1, 1);
            board.SetDiscAt(0, 2, 1);
            board.SetDiscAt(0, 3, 1);

            // Diagonal win
            board.SetDiscAt(1, 1, 1);
            board.SetDiscAt(2, 2, 1);
            board.SetDiscAt(3, 3, 1);

            board.CheckWinner();

            Assert.IsTrue(board.GameWon);
        }
    }
}
