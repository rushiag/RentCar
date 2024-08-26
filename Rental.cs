using Project;

class Rental
{
    private Car car;
    private Customer customer;

    private int Days;

    public Rental(Car car, Customer customer,int Days)
    {
        this.car = car;
        this.customer = customer;
        this.Days = Days;
    }
    public Car C{
        get { return car; }
        set { car = value; }
    }

    public Customer Cus
    {
        get { return customer; }
        set { customer = value; }
    }
}