using Project;

class Customer
{
    private string CustomerId;

    private string Name;

    public Customer(string CustomerId, string Name)
    {
        this.CustomerId = CustomerId;
        this.Name = Name;
    }
    public string customerId
    {
        get { return this.CustomerId;}
        set { this.CustomerId = value; }
    }

    public string name
    {
        get { return this.Name;}
        set { this.Name = value; }
    }

    public static implicit operator Customer(Car v)
    {
        throw new NotImplementedException();
    }
}