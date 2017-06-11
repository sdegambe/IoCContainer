namespace DevIoC
{
    public interface IDevIoCContainer
    {
        T Resolve<T>();
        void RegisterType<TFrom, TTo>();
    }
}
