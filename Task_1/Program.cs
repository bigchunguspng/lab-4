using System;

namespace Task_1
{
    internal class Program
    {
        public static void Main(string[] args)
        {
            Product coffee = new Product(1.28, "Nestle LLC Inc.", "Joseph Jostar");
            coffee.Info();
            
            Vehicle car = new Vehicle(12000, "Coyota", "Used Cars (Alabama)", 31, 3);
            car.Info();

            Product vehicle = (Product) car;
            vehicle.Info();
            
            Vehicle automobile = (Vehicle) vehicle;
            automobile.Info();
            
            Product bus = new Vehicle(37239.01, "ЗАЗ", "Київпастранс", 80, 40);
            bus.Info();
        }
    }
}