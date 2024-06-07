using System;
using System.Collections.Generic;
using System.Linq;

namespace Zadanie_9
{
    interface IObserver
    {
        void Update(WeatherData data);
    }

    interface ISubject
    {
        void Attach(IObserver observer);
        void Detach(IObserver observer);
        void NotifyObservers(WeatherData data);
    }

    class WeatherData
    {
        public double temperature;
        public string cloudiness;
        public int rainChance;

        public WeatherData(double temperature, string cloudiness, int rainChance)
        {
            this.cloudiness = cloudiness;
            this.rainChance = rainChance;
            this.temperature = temperature;
        }
    }

    class ConcreteObserver : IObserver
    {
        private string name;
        public string[] parameters;

        public ConcreteObserver(string name, string[] parameters)
        {
            this.name = name;
            this.parameters = parameters;
        }

        public void Update(WeatherData data)
        {
            foreach(string parameter in parameters)
            {
                var singleData = typeof(WeatherData).GetField(parameter).GetValue(data);

                if (singleData != null)
                {
                    Console.WriteLine(name + ": " + singleData);
                }
            }
        }
    }

    class WeatherStation : ISubject
    {
        private List<IObserver> observers = new List<IObserver> { };
        private WeatherData data;

        public void Attach(IObserver observer)
        {
            observers.Add(observer);
        }

        public void Detach(IObserver observer)
        {
            observers.Remove(observer);
        }

        public void NotifyObservers(WeatherData data)
        {
            foreach (IObserver observer in observers)
            {
                observer.Update(data);
            }
        }

        public void SetData(WeatherData data)
        {
            this.data = data;
            NotifyObservers(this.data);
        }
    }



    class Program
    {
        static void Main(string[] args)
        {
            WeatherStation weatherStation = new WeatherStation();

            ConcreteObserver observerTemperature = new ("Temperature", new string[] { "temperature" });
            ConcreteObserver observerCloudiness = new("Cloudiness", new string[] { "cloudiness" });
            ConcreteObserver observerRainChance = new("Rain Chance", new string[] { "rainChance" });

            weatherStation.Attach(observerTemperature);
            weatherStation.Attach(observerCloudiness);
            weatherStation.Attach(observerRainChance);

            weatherStation.SetData(new WeatherData(12.34, "Cloudy", 80));
        }
    }
}
