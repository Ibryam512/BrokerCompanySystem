using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BrokerCompanySystem
{
    abstract class Building
    {
        private string name;
        private string city;
        private int stars;
        private double rentAmount;
        private bool isAvailable;

        public string Name
        {
            get => this.name;
            set
            {
                if(string.IsNullOrEmpty(value))
                {
                    throw new ArgumentException("Building name must not be null or empty!");
                }
                this.name = value;
            }
        }

        public string City
        {
            get => this.city;
            set
            {
                if(string.IsNullOrEmpty(value))
                {
                    throw new ArgumentException("City must not be null or empty!");
                }
                this.city = value;
            }
        }

        public int Stars
        {
            get => this.stars;
            set
            {
                if(value < 0 || value > 5)
                {
                    throw new ArgumentException("Stars cannot be less than 0 or above 5");
                }
                this.stars = value;
            }
        }

        public double RentAmount
        {
            get => this.rentAmount;
            set
            {
                if(value <= 0)
                {
                    throw new ArgumentException("Rent amount cannot be less or equal to 0!");
                }
                this.rentAmount = value;
            }
        }

        public bool IsAvailable
        {
            get => this.isAvailable;
            set => this.isAvailable = value;
        }
        
        public Building(string name, string city, int stars, double rentAmount)
        {
            this.Name = name;
            this.City = city;
            this.Stars = stars;
            this.RentAmount = rentAmount;
            this.IsAvailable = true;
        }

        public override string ToString()
        {
            return $"****Building: {this.Name} <{this.Stars}>\r\n****Location: {this.City}\r\n****RentAmount: {this.RentAmount}\r\n****Is Available: {this.IsAvailable}";

        }
    }
}
