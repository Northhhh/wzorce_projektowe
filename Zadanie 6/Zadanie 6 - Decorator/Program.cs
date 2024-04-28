using System;
using System.Collections.Generic;


class Coffee
{
    public string Description { get; set; }
    public double Price { get; set; }
    public List<string> Extras { get; set; }

    public Coffee(string description, double price, List<string> extras)
    {
        Description = description;
        Price = price;
        Extras = extras;
    }

    public override string ToString()
    {
        return Description + ": $" + Price;
    }
}

abstract class CoffeeDecorator : Coffee
{
    protected Coffee BaseCoffee { get; set; }

    public CoffeeDecorator(Coffee baseCoffee) : base(baseCoffee.Description, baseCoffee.Price, baseCoffee.Extras)
    {
        BaseCoffee = baseCoffee;
    }

    public override string ToString()
    {
        return base.ToString() + ", Extras: " + (base.Extras.Count > 0 ? string.Join(", ", base.Extras) : "none");
    }
}

class Milk : CoffeeDecorator
{
    public Milk(Coffee baseCoffee) : base(baseCoffee)
    {
        Price += 1.5;
        Extras.Add("milk");
    }
}

class Sugar : CoffeeDecorator
{
    public Sugar(Coffee baseCoffee) : base(baseCoffee)
    {
        Price += 0.5;
        Extras.Add("sugar");
    }

}

class Syrup : CoffeeDecorator
{
    public Syrup(Coffee baseCoffee, string flavor) : base(baseCoffee)
    {
        Price += 2.0;
        Extras.Add(flavor);
    }
}

class Program
{
    static void Main(string[] args)
    {
        Coffee baseCoffee = new Coffee("Americano", 8.0, new List<string>());

        Coffee coffeeWithExtra1 = new Milk(baseCoffee);
        Console.WriteLine(coffeeWithExtra1);

        Coffee coffeeWithExtra2 = new Sugar(coffeeWithExtra1);
        Console.WriteLine(coffeeWithExtra2);

        Coffee coffeeWithExtra3 = new Syrup(coffeeWithExtra2, "vanilla");
        Console.WriteLine(coffeeWithExtra3);

        Console.ReadKey();
    }
}
