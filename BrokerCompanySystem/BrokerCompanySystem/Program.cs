using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BrokerCompanySystem
{
    class Program
    {
        static void Main(string[] args)
        {
            CompanyController c = new CompanyController();
            string[] command = Console.ReadLine().Split('*').ToArray();
            List<string> output = new List<string>();
            while (command[0] != "Shutdown")
            {
                try
                {
                    List<string> arg = command.ToList();
                    arg.RemoveAt(0);
                    switch (command[0])
                    {
                        case "CreateCompany":
                            output.Add(c.CreateCompany(arg));
                            break;
                        case "RegisterBuilding":
                            output.Add(c.RegisterBuilding(arg));
                            break;
                        case "RegisterBroker":
                            output.Add(c.RegisterBroker(arg));
                            break;
                        case "RentBuilding":
                            output.Add(c.RentBuilding(arg));
                            break;
                        case "CompanyInfo":
                            output.Add(c.CompanyInfo(arg));
                            break;
                    }
                    
                }
                catch(ArgumentException ex)
                {
                    output.Add(ex.Message);
                }
                command = Console.ReadLine().Split('*').ToArray();
            }
            output.Add(c.Shutdown());
            Console.Clear();
            foreach(var x in output)
            {
                Console.WriteLine(x);
            }
        }
    }
}
