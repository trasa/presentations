
namespace ExpressionsExample.PermissionExpressions
{
    public abstract class ExpressionToken
    {

    }

    public class PermissionExpressionToken : ExpressionToken
    {
        public PermissionExpressionToken(string permissionName)
        {
            PermissionName = permissionName;
        }

        public string PermissionName { get; set; }

        public override string ToString()
        {
            return PermissionName;
        }
    }

    public enum Operator
    {
        And,
        Or
    }

    public abstract class OperatorExpressionToken : ExpressionToken
    {
        public abstract Operator Operator { get; }
        public PermissionExpressionToken Left { get; set; }
        public ExpressionToken Right { get; set; }

        public override string ToString()
        {
            return string.Format("{0} {1} {2}", Left, Operator, Right);
        }
    }

    public class AndExpressionToken : OperatorExpressionToken
    {
        public override Operator Operator
        {
            get { return Operator.And; }
        }
    }

    public class OrExpressionToken : OperatorExpressionToken
    {
        public override Operator Operator
        {
            get { return Operator.Or; }
        }
    }
}