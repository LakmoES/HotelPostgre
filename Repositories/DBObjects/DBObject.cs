using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repositories
{
    public class DBObject
    {
        //id, Address, AddDate, Cost, Owner, Area, AppartamentOrHouse, NumberOfRooms
        public int id;
        public string address;
        public DateTime addDate;
        //public Money cost;
        public int cost;
        public int owner;
        public int area;
        public string appartamentOrHouse;
        public int numberOfRooms;
        public DBObject(int id, string address, DateTime addDate, int cost, int owner, string appartamentOrHouse, int area, int numberOfRooms)
        {
            this.id = id;
            this.address = address;
            this.addDate = addDate;
            this.cost = cost;
            this.owner = owner;
            this.appartamentOrHouse = appartamentOrHouse;
            this.area = area;
            this.numberOfRooms = numberOfRooms;
        }
    }

    //public struct Money
    //{
    //    int ammount;
    //    string currency;
    //    public Money(int ammount, string currency)
    //    {
    //        this.ammount = ammount;
    //        this.currency = currency;
    //    }
    //    public Money(string value)
    //    {
    //        this.ammount = 0;
    //        this.currency = "";
    //    }
    //    public override string ToString()
    //    {
    //        return String.Format("{0} {1}", ammount, currency);
    //    }
    //    public int Ammount
    //    {
    //        get
    //        {
    //            return ammount;
    //        }
    //    }
    //    public string Currency
    //    {
    //        get
    //        {
    //            return currency;
    //        }
    //    }
    //}
}
