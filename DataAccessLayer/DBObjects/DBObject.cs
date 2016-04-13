﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.DBObjects
{
    public class DBObject
    {
        //id, Address, AddDate, Cost, Owner, Area, AppartamentOrHouse, NumberOfRooms
        public int id;
        public string address;
        public DateTime addDate;
        public Money cost;
        public int owner;
        public int area;
        public string appartamentOrHouse;
        public int numberOfRooms;
        public DBObject(int id, string address, DateTime addDate, Money cost, int owner, int area, string appartamentOrHouse, int numberOfRooms)
        {
            this.id = id;
            this.address = address;
            this.addDate = addDate;
            this.cost = cost;
            this.owner = owner;
            this.area = area;
            this.appartamentOrHouse = appartamentOrHouse;
            this.numberOfRooms = numberOfRooms;
        }
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
        public override string ToString()
        {
            return String.Format("{0} {1}", ammount, currency);
        }
    }
}
