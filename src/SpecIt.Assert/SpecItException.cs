namespace SpecIt.Assert
{
    using System;

    public class SpecItException : Exception
    {
        public SpecItException(string message)
            : base(message)
        {

        }
    }
}