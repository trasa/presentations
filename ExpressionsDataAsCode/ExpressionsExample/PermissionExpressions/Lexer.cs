using System;

namespace ExpressionsExample.PermissionExpressions
{
    public class Lexer
    {
        private readonly string[] symbols;
        private int currentSymbol;

        public Lexer(string permissions)
        {
            if (permissions == null)
                throw new ArgumentNullException("permissions");
            symbols = permissions.Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
        }

        public bool HasMoreTokens
        {
            get { return currentSymbol != symbols.Length; }
        }

        public Lexeme ReadNext()
        {
            string result = symbols[currentSymbol];
            currentSymbol++;
            if (result == "&")
                return OperatorLexeme.And;
            if (result == "|")
                return OperatorLexeme.Or;
            return new PermissionNameLexeme(result);
        }

        public void PushBack()
        {
            currentSymbol--;
        }
    }

    public abstract class Lexeme
    {
        protected Lexeme(string value)
        {
            Value = value;
        }

        public string Value { get; private set; }
    }

    public class OperatorLexeme : Lexeme
    {
        public static readonly OperatorLexeme And = new OperatorLexeme("&");
        public static readonly OperatorLexeme Or = new OperatorLexeme("|");

        public OperatorLexeme(string value): base(value)
        {
            
        }
    }

    public class PermissionNameLexeme : Lexeme
    {
        public PermissionNameLexeme(string value) : base(value)
        {
            
        }
    }
}