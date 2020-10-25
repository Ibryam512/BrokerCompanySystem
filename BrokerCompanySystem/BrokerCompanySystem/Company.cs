using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BrokerCompanySystem
{
    class Company
    {
        private string name;
        private List<Building> buildings = new List<Building>();
        private List<Broker> brokers = new List<Broker>();

        public string Name
        {
            get => this.name;
            set
            {
                if (string.IsNullOrEmpty(value))
                {
                    throw new ArgumentException("Company name must not be null or empty!");
                }
                this.name = value;
            }
        }

        public List<Building> Buildings
        {
            get => this.buildings;
            set => this.buildings = value;
        }

        public List<Broker> Brokers
        {
            get => this.brokers;
            set => this.brokers = value;
        }

        public Company(string name)
        {
            this.Name = name;
        }

        public void AddBroker(Broker broker)
        {
            if(!this.Brokers.Any(x => x.Name == broker.Name))
            {
                this.Brokers.Add(broker);
            }
        }

        public void AddBuilding(Building building)
        {
            if (!this.Buildings.Any(x => x.Name == building.Name))
            {
                this.Buildings.Add(building);
            }
        }

        public Broker GetBrokerByName(string name)
        {
            if(this.Brokers.Any(x => x.Name == name))
            {
                Broker broker = this.Brokers.Find(x => x.Name == name);
                return broker;
            }
            return null;
        }

        public Building GetBuildingByName(string name)
        {
            if (this.Buildings.Any(x => x.Name == name))
            {
                Building building = this.Buildings.Find(x => x.Name == name);
                return building;
            }
            return null;
        }

        public override string ToString()
        {
            string result = $"Company: {this.Name}\r\n##Brokers: {this.Brokers.Count}";
            foreach (var x in this.Brokers)
            {
                result += $"\r\n{x.ToString()}";
            }
            result += $"\r\n##Buildings: {this.Buildings.Count}";
            foreach (var x in this.Buildings)
            {
                result += $"\r\n{x.ToString()}";
            }
            return result;
        }
    }
}
