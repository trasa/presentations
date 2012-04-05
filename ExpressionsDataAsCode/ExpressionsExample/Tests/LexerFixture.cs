using ExpressionsExample.PermissionExpressions;
using NUnit.Framework;

namespace ExpressionsExample.Tests
{
    [TestFixture]
    public class LexerFixture
    {
        [Test]
        public void Parse()
        {
            Assert.AreEqual("p1", lexer.ReadNext().Value);
            Assert.AreEqual(OperatorLexeme.And, lexer.ReadNext());
            Assert.AreEqual("p2", lexer.ReadNext().Value);
            Assert.AreEqual(OperatorLexeme.Or, lexer.ReadNext());
            Assert.AreEqual("p3", lexer.ReadNext().Value);
            Assert.IsFalse(lexer.HasMoreTokens);
        }

        [Test]
        public void PushBack()
        {
            Assert.AreEqual("p1", lexer.ReadNext().Value);
            lexer.PushBack();
            Assert.AreEqual("p1", lexer.ReadNext().Value);
            Assert.IsTrue(lexer.HasMoreTokens);
        }



        private Lexer lexer;

        [SetUp]
        public void SetUp()
        {
            lexer = new Lexer("p1   &     p2    | p3");
        }
    }
}