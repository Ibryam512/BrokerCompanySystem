using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BrokerCompanySystem
{
    class CompanyController
    {
        List<Company> companies = new List<Company>();
        public string CreateCompany(List<string> args)
        {
            string name = args[0];
            if (companies.Any(x => x.Name == name))
            {
                return $"Company {name} is already registered!";
            }
            Company company = new Company(name);
            companies.Add(company);
            return $"Company {name} was successfully registerd in the system!";
        }

        public string RegisterBuilding(List<string> args)
        {
            Building building = new Hotel("Hotel", "0", 1, 1);
            string type = args[0];
            string name = args[1];
            string city = args[2];
            int stars = int.Parse(args[3]);
            double rentAmount = double.Parse(args[4]);
            string companyName = args[5];
            if (!companies.Any(x => x.Name == companyName))
            {
                return $"Invalid Company: {companyName}. Cannot find it in system!";
            }
            int index = companies.FindIndex(x => x.Name == companyName);
            if (companies[index].Buildings.Any(x => x.Name == name))
            {
                return $"Building {name} is already registerd in {companyName}!";
            }
            switch (type)
            {
                case "Hotel":
                    building = new Hotel(name, city, stars, rentAmount);
                    break;
                case "Residence":
                    building = new Residence(name, city, stars, rentAmount);
                    break;
                case "Business":
                    building = new Business(name, city, stars, rentAmount);
                    break;
            }
            companies[index].AddBuilding(building);
            return $"Building {name} was successfully registerd in {companyName} catalog!";
        }

        public string RegisterBroker(List<string> args)
        {
            string name = args[0];
            int age = int.Parse(args[1]);
            string city = args[2];
            string companyName = args[3];
            if (!companies.Any(x => x.Name == companyName))
            {
                return $"Invalid Company: {companyName}. Cannot find it in system!";
            }
            Broker broker = new Broker(name, age, city);
            int index = companies.FindIndex(x => x.Name == companyName);
            if (companies[index].Brokers.Any(x => x.Name == name))
            {
                return $"Broker {name} is already part of {companyName}!";
            }
            companies[index].AddBroker(broker);
            return $"Broker {name} was successfully hired in {companyName}!";
        }

        public string RentBuilding(List<string> args)
        {
            string companyName = args[0];
            string buildingName = args[1];
            string brokerName = args[2];
            if (!companies.Any(x => x.Name == companyName))
            {
                return $"Invalid Company: {companyName}. Cannot find it in system!";
            }
            int index = companies.FindIndex(x => x.Name == companyName);
            if (!companies[index].Buildings.Any(x => x.Name == buildingName))
            {
                return $"Invalid Building: {buildingName}. Cannot find it in {companyName} catalog!";
            }
            if (!companies[index].GetBuildingByName(buildingName).IsAvailable)
            {
                return $"Building: {buildingName} cannot be rented!";
            }
            if (!companies[index].Brokers.Any(x => x.Name == brokerName))
            {
                return $"Invalid Broker: {brokerName}. Cannot find employee in {companyName}!";
            }
            companies[index].GetBuildingByName(buildingName).IsAvailable = false;
            double bonus = companies[index].GetBrokerByName(brokerName).RecieveBonus(companies[index].GetBuildingByName(buildingName));
            return $"Successfully rented {buildingName}!\r\nBroker {brokerName} earned {bonus}!";
        }

        public string CompanyInfo(List<string> args)
        {
            string companyName = args[0];
            if (!companies.Any(x => x.Name == companyName))
            {
                return $"Invalid Company: {companyName}. Cannot find it in system!";
            }
            int index = companies.FindIndex(x => x.Name == companyName);
            return companies[index].ToString();
        }

        public string Shutdown()
        {
            string result = $"Companies: {companies.Count}";
            companies = companies.OrderBy(x => x.Name).ToList();
            foreach (var x in companies)
            {
                result += "\r\n" + CompanyInfo(new List<string> { x.Name });
            }
            return result;
        }
    }
}
