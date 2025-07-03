// State Design Pattern

var order = new Order();
order.PrintOrderState();

order.NextState();
order.PrintOrderState();

order.NextState();
order.PrintOrderState();

Console.ReadLine();

interface IOrderState
{
    void Next(Order order);
    void Previous(Order order);
    void PrintStatus();
}

record DeliveredState : IOrderState // teslim edildi durumu
{
    public void Next(Order order)
    {
        Console.WriteLine("Bu son durumdur");
    }

    public void Previous(Order order)
    {
        order.State = new OnTheWayState();
    }

    public void PrintStatus()
    {
        Console.WriteLine("Sipariş teslim edildi");
    }
}

record OnTheWayState : IOrderState // yolda durumu
{
    public void Next(Order order)
    {
        order.State = new DeliveredState();
    }

    public void Previous(Order order)
    {
        order.State = new ProcessingState();
    }

    public void PrintStatus()
    {
        Console.WriteLine("Sipariş yolda");
    }
}

record ProcessingState : IOrderState // işleniyor durumu
{
    public void Next(Order order)
    {
        order.State = new OnTheWayState();
    }

    public void Previous(Order order)
    {
        order.State = new NewOrderState();
    }

    public void PrintStatus()
    {
        Console.WriteLine("Sipariş işleme alınıyor");
    }
}

record NewOrderState : IOrderState // yeni sipariş durumu
{
    public void Next(Order order)
    {
        order.State = new ProcessingState();
    }

    public void Previous(Order order)
    {
        Console.WriteLine("Bu ilk durumdur");
    }

    public void PrintStatus()
    {
        Console.WriteLine("Sipariş verildi");
    }
}

class Order
{
    public IOrderState State { get; set; }

    public Order()
    {
        State = new NewOrderState();
    }

    public void NextState()
    {
        State.Next(this);
    }

    public void PreviousState()
    {
        State.Previous(this);
    }

    public void PrintOrderState()
    {
        State.PrintStatus();
    }
}