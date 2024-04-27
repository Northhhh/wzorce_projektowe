using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Zadanie_3_Builder
{
    public class Client
    {
        public static void Main(string[] args)
        {
            IPizzaBuilder builder = new ConcretePizzaBuilder();
            Director director = new Director();

            Pizza pizza = director.ConstructPizza(builder);

            Console.WriteLine(pizza.ToString());

            Console.ReadKey();
        }
    }

    public class Pizza
    {
        public string Crust { get; set; }
        public List<string> Meats { get; set; } = new List<string>();
        public List<string> Cheeses { get; set; } = new List<string>();
        public List<string> Vegetables { get; set; } = new List<string>();
        public List<string> Spices { get; set; } = new List<string>();

        public override string ToString()
        {
            return $"Pizza:\n" +
                   $"Spód: {Crust}\n" +
                   $"Mięso: {string.Join(", ", Meats)}\n" +
                   $"Sery: {string.Join(", ", Cheeses)}\n" +
                   $"Warzywa: {string.Join(", ", Vegetables)}\n" +
                   $"Przyprawy: {string.Join(", ", Spices)}";
        }
    }

    public interface IPizzaBuilder
    {
        void AddCrust(string crust);
        void AddMeats(List<string> meats);
        void AddCheeses(List<string> cheeses);
        void AddVegetables(List<string> vegetables);
        void AddSpices(List<string> spices);
        Pizza GetPizza();
    }

    public class ConcretePizzaBuilder : IPizzaBuilder
    {
        private Pizza pizza = new Pizza();

        public void AddCrust(string crust)
        {
            pizza.Crust = crust;
        }

        public void AddMeats(List<string> meats)
        {
            pizza.Meats.AddRange(meats);
        }

        public void AddCheeses(List<string> cheeses)
        {
            pizza.Cheeses.AddRange(cheeses);
        }

        public void AddVegetables(List<string> vegetables)
        {
            pizza.Vegetables.AddRange(vegetables);
        }

        public void AddSpices(List<string> spices)
        {
            pizza.Spices.AddRange(spices);
        }

        public Pizza GetPizza()
        {
            return pizza;
        }
    }
    public class Director
    {
        public Pizza ConstructPizza(IPizzaBuilder builder)
        {
            builder.AddCrust("Cienkie ciasto");
            builder.AddMeats(new List<string>() { "Szynka", "Salami" });
            builder.AddCheeses(new List<string>() { "Mozarella", "Gorgonzola" });
            builder.AddVegetables(new List<string>() { "Pieczarki", "Papryka" });
            builder.AddSpices(new List<string>() { "Oregano", "Bazylia" });

            return builder.GetPizza();
        }
    }


}
