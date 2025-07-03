using ObserverPattern;

var samsung = new Product("Samsung S23", 1000);
var apple = new Product("Iphone 15", 1000);

var amazon = new Amazon();
var emreObserver = new EmreObserver("Emre Kılıç");
var kilicObserver = new KilicObserver("Emre Kılıç");

amazon.Register(emreObserver, samsung);
amazon.Register(kilicObserver, apple);

amazon.NotifyAll();

Console.ReadLine();
class Amazon
{
    private Dictionary<IObserver, Product> observers = new();

    public void Register(IObserver observer, Product product)
    {
        observers.TryAdd(observer, product);
    }

    public void UnRegister(IObserver observer)
    {
        observers.Remove(observer);
    }

    public void NotifyAll()
    {
        foreach (var kv in observers)
        {
            kv.Key.Notify(kv.Value);
        }
    }

    public void NotifyForProductName(string productName)
    {
        foreach (var kv in observers)
        {
            if (kv.Value.Name == productName)
                kv.Key.Notify(kv.Value);
        }
    }
}

class KilicObserver : IObserver
{
    public string FullName { get; set; }

    public KilicObserver(string fullName)
    {
        FullName = fullName;
    }

    public void Notify(Product product)
    {
        Console.WriteLine($"{FullName}, Product {product.Name} in stock now!");
    }
}

class EmreObserver : IObserver
{
    public string FullName { get; set; }

    public EmreObserver(string fullName)
    {
        FullName = fullName ?? throw new ArgumentNullException(nameof(fullName));
    }

    public void Notify(Product product)
    {
        Console.WriteLine($"{FullName}, Product {product.Name} in stock now!");
    }
}