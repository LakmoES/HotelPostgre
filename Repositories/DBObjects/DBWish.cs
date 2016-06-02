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
        public float? area;
        public int? numberOfRooms;
        public float? cost;

        public DBWish(int id, int client, string township, string apartamentOrHouse, float? area, int? numberOfRooms, float? cost)
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
