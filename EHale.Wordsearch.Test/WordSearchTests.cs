using EHale.Wordsearch.Entities;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace EHale.Wordsearch.Test
{
    [TestClass]
    public class WordSearchTests
    {
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

        [TestMethod]
        public void WhenWordSearchHasAHorizontalWordItReturnsTheLocation()
        {
            SearchBoard board = new SearchBoard(testBoard);
            string results = board.Find("SCOTTY");

            Assert.AreEqual("SCOTTY: (0,5),(1,5),(2,5),(3,5),(4,5),(5,5)", results);
        }

        [TestMethod]
        public void WhenWordSearchHasAVerticalWordItReturnsTheLocation()
        {
            SearchBoard board = new SearchBoard(testBoard);
            string results = board.Find("BONES");

            Assert.AreEqual("BONES: (0,6),(0,7),(0,8),(0,9),(0,10)", results);
        }

        [TestMethod]
        public void WhenWordSearchHasADiagonallyDescendingWordItReturnsTheLocation()
        {
            SearchBoard board = new SearchBoard(testBoard);
            string results = board.Find("SPOCK");

            Assert.AreEqual("SPOCK: (2,1),(3,2),(4,3),(5,4),(6,5)", results);
        }
    }
}