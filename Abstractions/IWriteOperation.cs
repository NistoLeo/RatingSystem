namespace Abstractions
{
    public interface ITest<TCommand>
    {
        void PerformOperation(TCommand operation);
    }
}
