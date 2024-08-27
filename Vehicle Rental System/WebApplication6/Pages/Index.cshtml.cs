using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Collections.Generic;

namespace WebApplication6.Pages
{
    public class IndexModel : PageModel
    {
        private readonly ILogger<IndexModel> _logger;

        public IndexModel(ILogger<IndexModel> logger)
        {
            _logger = logger;
        }

        public List<Vehicle> Vehicles { get; set; }

        public void OnGet()
        {
            Vehicles = new List<Vehicle>();

            Car car = new Car("Toyota", "Camry", 40.00m, 4);
            Truck truck = new Truck("Ford", "F-150", 60.00m, 2000);
            Motorcycle motorcycle = new Motorcycle("Honda", "CBR500R", 30.00m, 500);

            Vehicles.Add(car);
            Vehicles.Add(truck);
            Vehicles.Add(motorcycle);
        }

        public IActionResult OnPostRent(int id)
        {
            Vehicle vehicle = Vehicles[id];
            vehicle.Rent();
            return RedirectToPage();
        }

        public IActionResult OnPostReturn(int id)
        {
            Vehicle vehicle = Vehicles[id];
            vehicle.ReturnVehicle();
            return RedirectToPage();
        }
    }

    public class Vehicle
    {
        public string Make { get; set; }
        public string Model { get; set; }
        public decimal RentalPrice { get; set; }
        public bool IsAvailable { get; set; }

        public Vehicle(string make, string model, decimal rentalPrice)
        {
            Make = make;
            Model = model;
            RentalPrice = rentalPrice;
            IsAvailable = true;
        }

        public virtual void Rent()
        {
            if (IsAvailable)
            {
                IsAvailable = false;
            }
        }

        public virtual void ReturnVehicle()
        {
            if (!IsAvailable)
            {
                IsAvailable = true;
            }
        }
    }

    public class Car : Vehicle
    {
        public int NumberOfDoors { get; set; }

        public Car(string make, string model, decimal rentalPrice, int numberOfDoors)
            : base(make, model, rentalPrice)
        {
            NumberOfDoors = numberOfDoors;
        }
    }

    public class Truck : Vehicle
    {
        public int PayloadCapacity { get; set; }

        public Truck(string make, string model, decimal rentalPrice, int payloadCapacity)
            : base(make, model, rentalPrice)
        {
            PayloadCapacity = payloadCapacity;
        }
    }

    public class Motorcycle : Vehicle
    {
        public int EngineSize { get; set; }

        public Motorcycle(string make, string model, decimal rentalPrice, int engineSize)
            : base(make, model, rentalPrice)
        {
            EngineSize = engineSize;
        }
    }
}