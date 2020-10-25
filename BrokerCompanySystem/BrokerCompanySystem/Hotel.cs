using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BrokerCompanySystem
{
    class Hotel : Building
    {
        public Hotel(string name, string city, int stars, double rentAmount) : base(name, city, stars, rentAmount)
        {
            string[] names = this.Name.Split().ToArray();
            if(names[names.Length - 1] != "Hotel")
            {
                throw new ArgumentException("Name of hotel buildings should end on Hotel!");
            }
        }
    }
}
