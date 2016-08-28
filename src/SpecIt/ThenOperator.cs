namespace SpecIt
{
    public class ThenOperator<T> : IThenOperator<T>
        where T : IThen
    {
        private readonly T then;

        public ThenOperator(T then)
        {
            this.then = then;
        }

        public T And()
        {
            return this.then;
        }
    }
}