namespace SpecIt
{
    public interface IThenOperator<out T>
        where T : IThen
    {
        T And();
    }


    //public interface IThenOperator : IThenOperator<IThen>
    //{
    //}
}