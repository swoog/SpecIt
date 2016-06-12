namespace SpecIt.Assert
{
    using System;

    using Humanizer;

    public class Assert<T> : IAssert<T>
    {
        private readonly T value;

        private readonly string propertyName;

        private readonly IThenOperator thenOperator;

        public Assert(T value, string propertyName, IThenOperator thenOperator)
        {
            this.value = value;
            this.propertyName = propertyName;
            this.thenOperator = thenOperator;
        }
        public IThenOperator Is(Func<T, bool> predicate)
        {
            return this.Is(predicate, string.Empty);
        }

        private IThenOperator Is(Func<T, bool> predicate, string message)
        {
            if (!predicate(this.value))
            {
                throw new SpecItException(message + $" but was {this.GetValue()}");
            }

            return this.thenOperator;
        }

        private IThenOperator IsNot(Func<T, bool> predicate, string message)
        {
            if (predicate(this.value))
            {
                throw new SpecItException(message + $" but was {this.GetValue()}");
            }

            return this.thenOperator;
        }

        private string GetValue()
        {
            return this.FormatToString(this.value);
        }

        public IThenOperator IsEqualTo(T expected)
        {
            string typeName = Humanize();

            string exceptionName = $"Expected the {typeName} value {GetExpected(expected)}";
            if (this.propertyName != null)
            {
                var name = this.propertyName.Humanize();
                exceptionName = $"{name} expected the {typeName} value {GetExpected(expected)}";
            }

            return this.Is(v => v.Equals(expected), exceptionName);
        }

        private string GetExpected(T expected)
        {
            return FormatToString(expected);
        }

        private string FormatToString(T expected)
        {
            if (typeof(T) == typeof(string))
            {
                return $"\"{expected}\"";
            }

            return $"{expected}";
        }

        private static string Humanize()
        {
            switch (typeof(T).Name)
            {
                case "Int32":
                    return "int";
            }

            return typeof(T).Name.Transform(To.LowerCase);
        }

        public IThenOperator StartsWith(string message)
        {
            return this.Is(
                v =>
                    {
                        if (!(v is string))
                        {
                            return false;
                        }

                        return (v as string).StartsWith(message);
                    });
        }

        public IThenOperator IsNotEqualTo(T expected)
        {
            string typeName = Humanize();

            string exceptionName = $"The {typeName} value {GetExpected(expected)} is not expected";
            if (this.propertyName != null)
            {
                var name = this.propertyName.Humanize();
                exceptionName = $"The {typeName} value {GetExpected(expected)} is not expected for {name}";
            }

            return this.IsNot(v => v.Equals(expected), exceptionName);
        }
    }
}