using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repositories
{
    public class Entity
    {
        //id, Address, AddDate, Cost, Owner, Area, ApartmentOrHouse, NumberOfRooms
        public int id;
        public string address;
        public DateTime addDate;
        public float cost;
        public int owner;
        public float area;
        public string apartmentOrHouse;
        public int numberOfRooms;
        public Entity(int id, string address, DateTime addDate, float cost, int owner, string apartmentOrHouse, float area, int numberOfRooms)
        {
            this.id = id;
            this.address = address;
            this.addDate = addDate;
            this.cost = cost;
            this.owner = owner;
            this.apartmentOrHouse = apartmentOrHouse;
            this.area = area;
            this.numberOfRooms = numberOfRooms;
        }
    }
}
