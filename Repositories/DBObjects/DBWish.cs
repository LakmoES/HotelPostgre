using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repositories
{
    public class DBWish
    {
        //id, Client, Township, ApartamentOrHouse, Area, NumberOfRooms, Cost
        public int id;
        public int client;
        public string township;
        public string apartamentOrHouse;
        public int? area;
        public int? numberOfRooms;
        public int? cost;

        public DBWish(int id, int client, string township, string apartamentOrHouse, int? area, int? numberOfRooms, int? cost)
        {
            this.id = id;
            this.client = client;
            this.township = township;
            this.apartamentOrHouse = apartamentOrHouse;
            this.area = area;
            this.numberOfRooms = numberOfRooms;
            this.cost = cost;
        }
    }
}
