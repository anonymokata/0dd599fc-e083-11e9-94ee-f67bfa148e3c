using EHale.Wordsearch.Entities;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace EHale.Wordsearch.Test
{
    [TestClass]
    public class WordSearchTests
    {
        private SearchBoard board;

        private string[] testBoard = {"U,M,K,H,U,L,K,I,N,V,J,O,C,W,E",
            "L,L,S,H,K,Z,Z,W,Z,C,G,J,U,Y,G",
            "H,S,U,P,J,P,R,J,D,H,S,B,X,T,G",
            "B,R,J,S,O,E,Q,E,T,I,K,K,G,L,E",
            "A,Y,O,A,G,C,I,R,D,Q,H,R,T,C,D",
            "S,C,O,T,T,Y,K,Z,R,E,P,P,X,P,F",
            "B,L,Q,S,L,N,E,E,E,V,U,L,F,M,Z",
            "O,K,R,I,K,A,M,M,R,M,F,B,A,P,P",
            "N,U,I,I,Y,H,Q,M,E,M,Q,R,Y,F,S",
            "E,Y,Z,Y,G,K,Q,J,P,C,Q,W,Y,A,K",
            "S,J,F,Z,M,Q,I,B,D,B,E,M,K,W,D",
            "T,G,L,B,H,C,B,E,C,H,T,O,Y,I,K",
            "O,J,Y,E,U,L,N,C,C,L,Y,B,Z,U,H",
            "W,Z,M,I,S,U,K,U,R,B,I,D,U,X,S",
            "K,Y,L,B,Q,Q,P,M,D,F,C,K,E,A,B"
        };

        [TestInitialize]
        public void Setup()
        {
            board = new SearchBoard(testBoard);
        }

        [TestMethod]
        public void WhenWordSearchHasAHorizontalWordItReturnsTheLocation()
        {
            string results = board.Find("SCOTTY");

            Assert.AreEqual("SCOTTY: (0,5),(1,5),(2,5),(3,5),(4,5),(5,5)", results);
        }

        [TestMethod]
        public void WhenWordSearchHasAVerticalWordItReturnsTheLocation()
        {
            string results = board.Find("BONES");

            Assert.AreEqual("BONES: (0,6),(0,7),(0,8),(0,9),(0,10)", results);
        }

        [TestMethod]
        public void WhenWordSearchHasADiagonallyDescendingWordItReturnsTheLocation()
        {
            string results = board.Find("SPOCK");

            Assert.AreEqual("SPOCK: (2,1),(3,2),(4,3),(5,4),(6,5)", results);
        }

        [TestMethod]
        public void WhenWordSearchHasADiagonallyAscendingWordItReturnsTheLocation()
        {
            string results = board.Find("BSSH");

            Assert.AreEqual("BSSH: (0,3),(1,2),(2,1),(3,0)", results);
        }

        [TestMethod]
        public void WhenWordSearchHasAHorizontalBackwardsWordItReturnsTheLocation()
        {
            string results = board.Find("KIRK");

            Assert.AreEqual("KIRK: (4,7),(3,7),(2,7),(1,7)", results);
        }

        [TestMethod]
        public void WhenWordSearchHasAVerticalBackwardsWordItReturnsTheLocation()
        {
            string results = board.Find("KHAN");

            Assert.AreEqual("KHAN: (5,9),(5,8),(5,7),(5,6)", results);
        }

        [TestMethod]
        public void WhenWordSearchHasADiagonallyDescendingBackwardsWordItReturnsTheLocation()
        {
            string results = board.Find("SULU");

            Assert.AreEqual("SULU: (3,3),(2,2),(1,1),(0,0)", results);
        }

        [TestMethod]
        public void WhenWordSearchHasADiagonallyAscendingBackwardsWordItReturnsTheLocation()
        {
            string results = board.Find("UHURA");

            Assert.AreEqual("UHURA: (4,0),(3,1),(2,2),(1,3),(0,4)", results);
        }
    }
}
