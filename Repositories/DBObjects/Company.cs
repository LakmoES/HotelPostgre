﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repositories
{
    public class Company
    {
        //id, title, telephone, address
        public int id;
        public string title;
        public string telephone;
        public string address;
        public Company(int id, string title, string telephone, string address)
        {
            this.id = id;
            this.title = title;
            this.telephone = telephone;
            this.address = address;
        }
    }
}
