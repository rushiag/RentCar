namespace Project;

class Program
{
    static void Main(string[] args)
    {
        MenuSystem rensys = new MenuSystem();
        //Create car objects.......
        Car car1 = new Car("C1","BMW","330i",2000);
        Car car2 = new Car("C2","BMW","530i",4000);
        Car car3 = new Car("C3","BMW","730i",6000);


        //Add the created car objects......

        rensys.AddCar(car1);
        rensys.AddCar(car2);
        rensys.AddCar(car3);
        rensys.Menu();
    }
}
