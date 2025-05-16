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

            Assert.IsTrue(board.CheckWin(1));
        }

        [TestMethod]
        public void CheckWin_HorizontalNoWin_ReturnsFalse()
        {
            ConnectFourBoard board = new();

            board.SetDiscAt(0, 0, 1);
            board.SetDiscAt(0, 1, 0);
            board.SetDiscAt(0, 2, 1);
            board.SetDiscAt(0, 3, 1);

            Assert.IsFalse(board.CheckWin(1));
        }

        [TestMethod]
        public void CheckWin_VerticalWin_ReturnsTrue()
        {
            ConnectFourBoard board = new();

            board.SetDiscAt(0, 0, 1);
            board.SetDiscAt(1, 0, 1);
            board.SetDiscAt(2, 0, 1);
            board.SetDiscAt(3, 0, 1);

            Assert.IsTrue(board.CheckWin(1));
        }

        [TestMethod]
        public void CheckWin_VerticalNoWin_ReturnsFalse()
        {
            ConnectFourBoard board = new();

            board.SetDiscAt(0, 0, 1);
            board.SetDiscAt(1, 0, 0);
            board.SetDiscAt(2, 0, 1);
            board.SetDiscAt(3, 0, 1);

            Assert.IsFalse(board.CheckWin(1));
        }

        [TestMethod]
        public void CheckWin_DiagonalUpLeftWin_ReturnsTrue()
        {
            ConnectFourBoard board = new();

            board.SetDiscAt(0, 0, 1);
            board.SetDiscAt(1, 1, 1);
            board.SetDiscAt(2, 2, 1);
            board.SetDiscAt(3, 3, 1);

            Assert.IsTrue(board.CheckWin(1));
        }

        [TestMethod]
        public void CheckWin_DiagonalUpRightWin_ReturnsTrue()
        {
            ConnectFourBoard board = new();

            board.SetDiscAt(3, 0, 1);
            board.SetDiscAt(2, 1, 1);
            board.SetDiscAt(1, 2, 1);
            board.SetDiscAt(0, 3, 1);

            Assert.IsTrue(board.CheckWin(1));
        }

        [TestMethod]
        public void CheckWin_DiagonalNoWin_ReturnsFalse()
        {
            ConnectFourBoard board = new();

            board.SetDiscAt(0, 0, 1);
            board.SetDiscAt(1, 1, 0);
            board.SetDiscAt(2, 2, 1);
            board.SetDiscAt(3, 3, 1);

            Assert.IsFalse(board.CheckWin(1));
        }


        [TestMethod]
        public void CheckOutOfBounds_Horizontal()
        {
            ConnectFourBoard board = new();

            board.SetDiscAt(0, 3, 1);
            board.SetDiscAt(0, 4, 1);
            board.SetDiscAt(0, 5, 1);
            board.SetDiscAt(0, 6, 1);

            Assert.IsTrue(board.CheckWin(1));
        }
    }
}
