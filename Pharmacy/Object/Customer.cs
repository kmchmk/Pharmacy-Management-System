using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pharmacy
{
    class Customer
    {
        int id;
        string name;
        string telephoneNumber;
        public Customer(int id, string name, string telephoneNUmber)
        {
            this.id = id;
            this.name = name;
            this.telephoneNumber = telephoneNUmber;
        }

        public int getID() { return id; }
        public void setID(int id) { this.id = id; }
        public string getTelephoneNumber() { return telephoneNumber; }
        public void setTelephoneNumber(string telephoneNumber) { this.telephoneNumber = telephoneNumber; }
        public string getName() { return name; }
        public void setName(string name) { this.name = name; }


    }
}
