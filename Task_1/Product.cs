using System.Diagnostics;

namespace Task_1
{
    public class Product
    {
        private readonly double _price;
        private readonly string _producer;
        private readonly string _owner;

        public Product(double price, string producer, string owner)
        {
            _price = price;
            _producer = producer;
            _owner = owner;
        }

        public void Info(bool calledOutside = false)
        {
            Debug.WriteLine($"{nameof(Product)} characteristics");
            Debug.WriteLine($"Price: {_price}");
            Debug.WriteLine($"Producer: {_producer}");
            Debug.WriteLine($"Owner: {_owner}{(calledOutside ? "" : "\n")}");
        }
    }
}