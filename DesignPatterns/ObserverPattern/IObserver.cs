namespace ObserverPattern
{
    public interface IObserver
    {
        string FullName { get; set; }
        void Notify(Product product);
    }
}