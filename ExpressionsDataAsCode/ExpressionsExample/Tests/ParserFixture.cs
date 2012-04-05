using ExpressionsExample.PermissionExpressions;
using NUnit.Framework;

namespace ExpressionsExample.Tests
{
    [TestFixture]
    public class ParserFixture
    {
        [Test]
        public void SimplestExpression()
        {
            var expr = "permission.name";
            var p = new Parser(expr);
            ExpressionToken t = p.Parse();
            Assert.IsInstanceOfType(typeof(PermissionExpressionToken), t);
            Assert.AreEqual(expr, ((PermissionExpressionToken)t).PermissionName);
        }

        [Test]
        public void SimpleAndExpression()
        {
            var expr = "p.1 & p.2";
            var p = new Parser(expr);
            var root = (OperatorExpressionToken)p.Parse();
            Assert.AreEqual(Operator.And, root.Operator);
            var lhs = root.Left;
            var rhs = (PermissionExpressionToken)root.Right;
            Assert.AreEqual("p.1", lhs.PermissionName);
            Assert.AreEqual("p.2", rhs.PermissionName);
        }

        [Test]
        public void SimpleOrExpression()
        {
            var expr = "p.1 | p.2";
            var p = new Parser(expr);
            var root = (OperatorExpressionToken)p.Parse();
            Assert.AreEqual(Operator.Or, root.Operator);
            var lhs = root.Left;
            var rhs = (PermissionExpressionToken)root.Right;
            Assert.AreEqual("p.1", lhs.PermissionName);
            Assert.AreEqual("p.2", rhs.PermissionName);
        }

        [Test]
        public void DoubleAndExpression()
        {
            var expr = "p.1 & p.2 & p.3";
            var p = new Parser(expr);
            var root = (OperatorExpressionToken)p.Parse();
            Assert.AreEqual(Operator.And, root.Operator);
            var firstPermission = root.Left;
            var secondExpression = (OperatorExpressionToken)root.Right;
            Assert.AreEqual("p.1", firstPermission.PermissionName);

            Assert.AreEqual(Operator.And, secondExpression.Operator);
            Assert.AreEqual("p.2", secondExpression.Left.PermissionName);
            Assert.AreEqual("p.3", ((PermissionExpressionToken)secondExpression.Right).PermissionName);
        }

        [Test]
        public void BigExpression()
        {
            var expr = "p.1 & p.2 & p.3 | p.4";
            var p = new Parser(expr);
            var root = (OperatorExpressionToken)p.Parse();
            Assert.AreEqual(Operator.And, root.Operator);
            var firstPermission = root.Left;
            
            var secondExpression = (OperatorExpressionToken)root.Right;
            Assert.AreEqual("p.1", firstPermission.PermissionName);

            Assert.AreEqual(Operator.And, secondExpression.Operator);
            Assert.AreEqual("p.2", secondExpression.Left.PermissionName);

            var thirdExpression = (OperatorExpressionToken)secondExpression.Right;
            Assert.AreEqual(Operator.Or, thirdExpression.Operator);
            Assert.AreEqual("p.3", thirdExpression.Left.PermissionName);
            Assert.AreEqual("p.4", ((PermissionExpressionToken)thirdExpression.Right).PermissionName);
        }
    }
}