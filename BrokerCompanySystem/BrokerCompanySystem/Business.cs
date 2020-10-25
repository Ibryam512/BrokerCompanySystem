using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BrokerCompanySystem
{
    class Business : Building
    {
        public Business(string name, string city, int stars, double rentAmount) : base(name, city, stars, rentAmount)
        {
            string[] names = this.Name.Split().ToArray();
            if (names[names.Length - 1] != "Business")
            {
                throw new ArgumentException("Name of business buildings should end on Business!");
            }
        }
    }
}
