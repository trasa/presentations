using System.Data;

namespace ExpressionsExample.PermissionExpressions
{
    public class Parser
    {
        private readonly Lexer lexer;

        public Parser(string permissions)
        {
            lexer = new Lexer(permissions);
        }

        public ExpressionToken Parse()
        {
            PermissionExpressionToken permission = ParsePermission();
            if (!lexer.HasMoreTokens)
            {
                // this is a simple, 1-permission, statement.
                return permission;
            }
            // this is a complex statement
            return ParseOperator(permission);
        }

        private PermissionExpressionToken ParsePermission()
        {
            Lexeme l = lexer.ReadNext();
            if (!(l is PermissionNameLexeme))
            {
                throw new SyntaxErrorException("Expecting a Permission, not '" + l.Value  + "'");
            }
            return new PermissionExpressionToken(l.Value);
        }

        private OperatorExpressionToken ParseOperator(PermissionExpressionToken lhs)
        {
            Lexeme l = lexer.ReadNext();
            var opLex = l as OperatorLexeme;
            if (!(l is OperatorLexeme))
            {
                throw new SyntaxErrorException("Expecting an Operator (& or |), not '" + l.Value + "'");
            }

            OperatorExpressionToken opToken;
            if (opLex == OperatorLexeme.And)
            {
                opToken = new AndExpressionToken();
            }
            else
            {
                opToken = new OrExpressionToken();
            }
            opToken.Left = lhs;
            opToken.Right = Parse();
            return opToken;
        }
    }
}