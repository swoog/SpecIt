namespace SpecIt
{
    using System;

    public class ResolverException : Exception
    {
        public ResolverException(string message, bool isFirst)
            : base(message)
        {
            this.IsFirst = isFirst;
        }

        public bool IsFirst { get; }
    }
}