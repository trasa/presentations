using System.Linq.Expressions;

namespace RobotArmy.Core.Extensions
{
    public static class ControllerExtensions
    {
        /// <summary>
        /// Extract the action name out of this expression.
        /// </summary>
        /// <param name="actionExpression"></param>
        /// <returns></returns>
        public static string GetActionName(this LambdaExpression actionExpression)
        {
            // Convention: we are expecting that the body of the expression 
            // given is a Method Call.  Once we have that, we can extract
            // the Name from the expression.
            return ((MethodCallExpression)actionExpression.Body).Method.Name;
        }
    }
}
