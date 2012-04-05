using System;
using System.Linq.Expressions;

namespace ExpressionsExample.PermissionExpressions
{
    /// <summary>
    /// Chain a bunch of functions together with AND / OR logic,
    /// evaluated into a boolean.
    /// </summary>
    public class PermissionExpressionBuilder
    {
        /// <summary>
        /// the function that evaluate our parsed string, and return true or false.
        /// </summary>
        private Func<string, bool> verifyFunction;



        /// <summary>
        /// Build an Expression which represents calls to the permissionCheck function, 
        /// glued together with And and Or operators as specified in the permissions string.
        /// </summary>
        /// <param name="permissions">The permissions to check.</param>
        /// <param name="permissionCheck">The function that will evaluate each permission.</param>
        /// <returns>An Expression representing the code you would need to evaluate the permissions.</returns>
        public Expression<Func<bool>> Build(string permissions, Func<string, bool> permissionCheck)
        {
            verifyFunction = permissionCheck;
            return BuildExpression(new Parser(permissions).Parse());
        }








        private Expression<Func<bool>> BuildExpression(ExpressionToken token)
        {
            if (token is OperatorExpressionToken)
            {
                // have to wrap BinaryExpression in a Lambda so we can execute it.
                return Expression.Lambda<Func<bool>>(BuildOperatorExpression((OperatorExpressionToken)token));
            }
            return BuildPermissionExpression((PermissionExpressionToken)token);
        }

        private BinaryExpression BuildOperatorExpression(OperatorExpressionToken op)
        {
            if (op.Operator == Operator.And)
            {
                return Expression.AndAlso(BuildPermissionExpression(op.Left).Body, BuildExpression(op.Right).Body);
            }
            return Expression.OrElse(BuildPermissionExpression(op.Left).Body, BuildExpression(op.Right).Body);
        }

        private Expression<Func<bool>> BuildPermissionExpression(PermissionExpressionToken token)
        {
            return () => verifyFunction(token.PermissionName);
        }
    }
}