using System.Collections.Generic;
using System.Linq;
using ExpressionsExample.PermissionExpressions;
using NUnit.Framework;

namespace ExpressionsExample.Tests
{
    [TestFixture]
    public class PermissionExpressionBuilderFixture
    {
        [Test]
        public void BuildSimplestExpression()
        {
            var expr = new PermissionExpressionBuilder().Build("foo", Verify);
            Assert.IsTrue(expr.Compile().Invoke());
            AssertPermissionsChecked("foo");
        }

        [Test]
        public void MultipleAnds()
        {
            var expr = new PermissionExpressionBuilder().Build("foo & bar & baz", Verify);
            Assert.IsTrue(expr.Compile().Invoke());
            AssertPermissionsChecked("foo", "bar", "baz");
        }


        [Test]
        public void BuildAndExpression_SuccessfulVerification()
        {
            var expr = new PermissionExpressionBuilder().Build("foo & bar", Verify);
            Assert.IsTrue(expr.Compile().Invoke());
            AssertPermissionsChecked("foo", "bar");
        }

        [Test]
        public void BuildAndExpression_FailVerification_WithShortCircuit()
        {
            var expr = new PermissionExpressionBuilder().Build("foo & bar", permissionName =>
                                                                                {
                                                                                    if (permissionName == "foo")
                                                                                    {
                                                                                        permissionsChecked.Add("foo");
                                                                                        return true;
                                                                                    }
                                                                                    return false;
                                                                                });
            Assert.IsFalse(expr.Compile().Invoke());
            AssertPermissionsChecked("foo");
        }

        [Test]
        public void BuildOrExpression_SuccessfulVerification()
        {
            var expr = new PermissionExpressionBuilder().Build("foo | bar", Verify);
            Assert.IsTrue(expr.Compile().Invoke());
            AssertPermissionsChecked("foo"); // short circuit
        }

        [Test]
        public void BuildOrExpression_FailVerification()
        {
            var expr = new PermissionExpressionBuilder().Build("foo | bar", permissionName =>
                                                                                {
                                                                                    permissionsChecked.Add(permissionName);
                                                                                    return false;
                                                                                });
            Assert.IsFalse(expr.Compile().Invoke());
            AssertPermissionsChecked("foo", "bar");
        }

        [Test]
        public void MultipleOrs()
        {
            var expr = new PermissionExpressionBuilder().Build("foo | bar | baz", permissionName =>
                                                                                      {
                                                                                          permissionsChecked.Add(permissionName);
                                                                                          return permissionName == "baz";
                                                                                      });
            Assert.IsTrue(expr.Compile().Invoke());
            AssertPermissionsChecked("foo", "bar", "baz");
        }


        [Test]
        public void MixedLogic_LeftToRight_Precedence_And()
        {
            var expr = new PermissionExpressionBuilder().Build("foo & bar | baz", permissionName =>
                                                                                      {
                                                                                          permissionsChecked.Add(permissionName);
                                                                                          // foo = true, bar = false, baz = true should force this to be true.  foo & (bar | baz)
                                                                                          return permissionName == "foo" || permissionName == "baz";
                                                                                      });
            Assert.IsTrue(expr.Compile().Invoke());
            AssertPermissionsChecked("foo", "bar", "baz");
        }

        [Test]
        public void MixedLogic_LeftToRight_Precedence_And_Fail()
        {
            var expr = new PermissionExpressionBuilder().Build("foo & bar | baz", permissionName =>
                                                                                      {
                                                                                          permissionsChecked.Add(permissionName);
                                                                                          // foo = false, should force this to be true.  foo & (bar | baz)
                                                                                          return permissionName == "bar" || permissionName == "baz";
                                                                                      });
            Assert.IsFalse(expr.Compile().Invoke());
            AssertPermissionsChecked("foo");
        }




        [Test]
        public void MixedLogic_LeftToRight_Precedence_Or()
        {
            var expr = new PermissionExpressionBuilder().Build("foo | bar & baz", permissionName =>
                                                                                      {
                                                                                          permissionsChecked.Add(permissionName);
                                                                                          // foo = false, bar = true, baz = true should force this to be true.  foo | (bar & baz)
                                                                                          return permissionName == "bar" || permissionName == "baz";
                                                                                      });
            Assert.IsTrue(expr.Compile().Invoke());
            AssertPermissionsChecked("foo", "bar", "baz");
        }


        [Test]
        public void MixedLogic_LeftToRight_Precedence_Or_ShortCircuit() 
        {
            // see MixedLogic_LeftToRight_Precedence_Or
            var expr = new PermissionExpressionBuilder().Build("foo | bar & baz", permissionName =>
                                                                                      {
                                                                                          permissionsChecked.Add(permissionName);
                                                                                          // foo = true , bar = false , baz = false should force this to be true.  foo | (bar & baz)
                                                                                          return permissionName == "foo";
                                                                                      });
            Assert.IsTrue(expr.Compile().Invoke());
            AssertPermissionsChecked("foo");
        }





        private bool Verify(string permissionName)
        {
            permissionsChecked.Add(permissionName);
            return true;
        }

        private void AssertPermissionsChecked(params string[] permissionNamesToVerify)
        {
            Assert.AreEqual(permissionsChecked.Count, permissionNamesToVerify.Length);
            // permissionsChecked should contain all of permissionNamesToVerify (the intersection should be complete) 
            permissionsChecked.ForEach(p => Assert.IsTrue(permissionNamesToVerify.Contains(p)));
        }


        private List<string> permissionsChecked;

        [SetUp]
        public void SetUp()
        {
            permissionsChecked = new List<string>();
        }
    }
}