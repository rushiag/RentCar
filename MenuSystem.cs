using System.Runtime.CompilerServices;
using System.Data.SqlClient;

namespace Project;
class MenuSystem
{
    private List<Car> cars;
    private List<Customer> customers;
    private List<Rental> rentals;

    public MenuSystem(){
        cars = new List<Car>();
        customers = new List<Customer>();
        rentals = new List<Rental>();
        // LoadCarsFromDatabase();
    }
    public void AddCar(Car car)
    {
        cars.Add(car);
    }
    public void AddCustomer(Customer customer)
    {
        customers.Add(customer);   
    }

    public void RentCar(Car car,Customer customer,int Days)
    {
        if(car.IsAvailable())
        {
            car.Rent();
            rentals.Add(new Rental(car,customer,Days));
        }
        else
        {
            Console.WriteLine("Car not Available for rental");
        }
    }
    public void Return(Car car)
    {
        car.Return();
        Rental RemoveRental = null;
        foreach(Rental rental in rentals)
        {
            if(rental.C==car)
            {
                RemoveRental = rental;
                break;
            }
        }
        if(RemoveRental!=null)
        {
            rentals.Remove(RemoveRental);
        }
        else
        {
            Console.WriteLine("Car was not Rented");
        }
    }

    public void Menu()
    {
        while(true)
        {
            Console.WriteLine("========CarRentals========");
            Console.WriteLine("1.Rent a Car");
            Console.WriteLine("2.Return a Car");
            Console.WriteLine("3.Exit");

            Console.WriteLine("Enter Your Choice:");
            

            int choice= int.Parse(Console.ReadLine());

            if(choice ==1)
            {
                Console.WriteLine("===Rent A Car===");
                Console.WriteLine("Enter Your Name:");
                    // Enter the logic for the rental of the car
                    string CustomerName= Console.ReadLine();
                    Console.WriteLine("Avilable Cars:");
                    foreach(Car car in cars)
                    {
                        if(car.IsAvailable())
                        {
                                Console.WriteLine(car.carId+"-"+car.brand+" "+car.model);

                        
                        }
                    
                    }
                    Console.WriteLine("Enter the car id you want to rent");
                    string carid = Console.ReadLine();
                    Console.WriteLine("Enter the number of days you want to rent");
                    int RentalDays=int.Parse(Console.ReadLine());
                    Customer newcustomer = new Customer("C1"+(customers.Count +1),CustomerName);
                    AddCustomer(newcustomer);

                Car selectedCar = null;
                foreach(Car car in cars)
                {
                    if(car.carId.Equals(carid)&& car.IsAvailable())
                    {
                        selectedCar =car;
                        break;
                    }
                }

                if(selectedCar != null)
                {
                    double TotalPrice = selectedCar.GetBasePrice(RentalDays);
                    Console.WriteLine("n======Rental Information=======");
                    Console.WriteLine("Customer Id:"+newcustomer.customerId);
                    Console.WriteLine("Customer Name:"+newcustomer.name);
                    Console.WriteLine("Selected Car:"+selectedCar.brand+" "+selectedCar.model);
                    Console.WriteLine("Renatal Days:"+RentalDays);
                    Console.WriteLine("Total Price:"+TotalPrice);

                    Console.WriteLine("Confirm rental (Y/N): ");
                    string confirm = Console.ReadLine();

                    if (confirm.Equals("Y", StringComparison.OrdinalIgnoreCase))
                    {
                        RentCar(selectedCar,newcustomer,RentalDays);
                        Console.WriteLine("Car rented successfully");

                    }
                    else
                    {
                        Console.WriteLine("Rental Canceled");
                    }


                }
                else {
                    Console.WriteLine("\nInvalid car selection or car not available for rent.");
                }
            }
            else if(choice ==2)
            {   
                Console.WriteLine("======Return Car=======");
                Console.WriteLine("Enter the car id you want to return:");
                string carid = Console.ReadLine();
                
                Car cartoreturn = null;
                foreach(Car car in cars)
                {
                    if(car.carId.Equals(carid)&& !car.IsAvailable())
                    {
                        cartoreturn = car;
                        break;
                    }
                }
                    if(cartoreturn != null)
                    {
                        Customer customer = null;
                        foreach(Rental rental in rentals)
                        {
                            if(rental.C==cartoreturn)
                            {
                                customer=rental.Cus;
                                break;
                            }
                        }
                        if(customer!=null)
                        {
                            Return(cartoreturn);
                            Console.WriteLine("Car Returned Sucessf ully by:"+customer.name);
                        }
                        else
                        {
                            Console.WriteLine("Car not found in rentals");
                        }
                    }
                    else
                    {
                        Console.WriteLine("Invalid");
                    }
                }
                //Enter the logic for the returning of the car

            
            else if(choice ==3)
            {
                break;
                // exit the prgm
            }
            else
            {
                Console.WriteLine("Invalid choice. Please enter a valid option.");
            }
            
        }
        Console.WriteLine("\nThank you for using the Car Rental System!");
    }
    // public void LoadCarsFromDatabase()
    // {
    //     string connectionString = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=|DataDirectory|RentalSystemDB.sql;Integrated Security=True";
    //     using (SqlConnection connection = new SqlConnection(connectionString))
    //     {
    //         connection.Open();
    //         string sql = "SELECT * FROM Cars";
    //         using (SqlCommand command = new SqlCommand(sql,connection))
    //         {
    //             using(SqlDataReader reader = command.ExecuteReader())
    //             {
    //                 while(reader.Read())
    //                 {
    //                   Car car = new Car(reader["CarId"].ToString(), reader["Brand"].ToString(), reader["Model"].ToString(), (double)reader["BasePrice"]);
    //                     cars.Add(car);
    //                 }

    //             }
                
    //           }
    //     }
    // }
}