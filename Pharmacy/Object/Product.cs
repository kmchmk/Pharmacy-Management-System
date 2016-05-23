using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pharmacy
{
    public class Product
    {
        int id;
        string code;
        string productName;
        string brand;
        int rackNo;
        double price;
        string description;





        public Product(int id, string code, string productName, string brand, int rackNo, double price, string description)
        {
            this.id = id;
            this.code = code;
            this.productName = productName;
            this.brand = brand;
            this.rackNo = rackNo;
            this.price = price;
            this.description = description;
        }

        public int getID() { return id; }
        public void setID(int id) { this.id = id; }
        public string getCode() { return code; }
        public void setCode(string code) { this.code = code; }
        public string getProductName() { return productName; }public void setProductName(string productName) { this.productName = productName; }
        public string getBrand() { return brand; }public void setBrand(string brand) { this.brand = brand; }
        public int getRackNo() { return rackNo; }public void setRackNo(int rackNo) { this.rackNo = rackNo; }
        public double getPrice() { return price; }public void setPrice(double price) { this.price = price; }
        public string getDescription() { return description; }public void setDescription(string description) { this.description = description; }








    }



}
