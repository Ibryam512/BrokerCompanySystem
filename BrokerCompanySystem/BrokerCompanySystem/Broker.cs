using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BrokerCompanySystem
{
    class Broker
    {
        private string name;
        private int age;
        private string city;
        private double bonus;
        private List<Building> buildings = new List<Building>();

        public string Name
        {
            get => this.name;
            set
            {
                if (string.IsNullOrEmpty(value))
                {
                    throw new ArgumentException("Broker name must not be null or empty!");
                }
                this.name = value;
            }
        }

        public int Age
        {
            get => this.age;
            set
            {
                if(value < 16 || value > 70)
                {
                    throw new ArgumentException("Broker's age cannot be less than 16 or above 70!");
                }
                this.age = value;
            }
        }

        public string City
        {
            get => this.city;
            set
            {
                if (string.IsNullOrEmpty(value))
                {
                    throw new ArgumentException("City must not be null or empty!");
                }
                this.city = value;
            }
        }

        public double Bonus
        {
            get => this.bonus;
            set => this.bonus = value;
        }

        public List<Building> Buildings
        {
            get => this.buildings;
            set => this.buildings = value;
        }

        public Broker(string name, int age, string city)
        {
            this.Name = name;
            this.Age = age;
            this.City = city;
        }

        public double RecieveBonus(Building building)
        {
            double amount = building.RentAmount * 2 * building.Stars / 100;
            this.Bonus += amount;
            this.Buildings.Add(building);
            return amount;

        }

        public override string ToString()
        {
            string result = $"****Broker: {this.Name} <{this.Age}>\r\n****Location: {this.City}\r\n****Bonus: {this.Bonus}";
            foreach(var x in this.Buildings)
            {
                result += $"\r\n****** {x.Name}";
            }
            return result;
        }
    }
}
