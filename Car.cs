namespace Project;
class Car
{
    private string CarId;

    private string Brand;

    private string Model;

    private double BasePrice;

    private bool isAvailable;

    public Car(string CarId, string Brand, string Model, double BasePrice)
    {
        this.CarId = CarId;
        this.Brand = Brand;
        this.Model = Model;
        this.BasePrice = BasePrice;
        this.isAvailable = true;
    }

    public string carId
    {
        get { return this.CarId;}
        set { this.CarId = value; }
    }

    public string brand
    {
        get { return this.Brand;}
        set {this.Brand = value;}

    }

    public string model
    {
        get { return this.Model;}
        set { this.Model = value; }
    }

    public double GetBasePrice(int RentalDays)
    {
        return BasePrice * RentalDays;
    }

    public bool IsAvailable()
    {
        return isAvailable;
    }

    public void Rent()
    {
        isAvailable = false;
    }

    public void Return()
    {
        isAvailable = true;
    }
}