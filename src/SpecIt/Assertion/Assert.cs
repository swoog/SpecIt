namespace SpecIt.Assertion
{
    using System;

    public class Assert<T> : IAssert<T>
    {
        private readonly T value;

        private readonly IThenOperator thenOperator;

        public Assert(T value, IThenOperator thenOperator)
        {
            this.value = value;
            this.thenOperator = thenOperator;
        }

        public IThenOperator Is(Func<T, bool> predicate)
        {
            if (!predicate(this.value))
            {
                throw new Exception("Error in expected");
            }

            return this.thenOperator;
        }

        public IThenOperator IsEqualTo(T expected)
        {
            return this.Is(v => v.Equals(expected));
        }

        public IThenOperator StartsWith(string message)
        {
            return this.Is(v => (v as string).StartsWith(message));
        }
    }
}