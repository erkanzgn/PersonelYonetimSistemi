﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entites.Concretes
{
    public  class Role
    {
        public  int Id { get; set; }    
        public string RoleName { get; set; }

        public ICollection<User> Users { get; set;}
    }
}
