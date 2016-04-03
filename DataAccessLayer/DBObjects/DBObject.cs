using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.DBObjects
{
    class DBObject
    {
        //id, Address, AddDate, Cost, Owner, Area, AppartamentOrHouse, NumberOfRooms
        public int id;
        public string address;
        public DateTime addDate;
        public Money cost;
        public int owner;
        public int area;
        public int appartamentOrHouse;
        public int numberOfRooms;
        public DBObject() { }
    }

    public struct Money
    {
        int ammount;
        string currency;
        public Money(int ammount, string currency)
        {
            this.ammount = ammount;
            this.currency = currency;
        }
    }
}
