﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab_Workflow_Manager.Models
{
    public abstract class Person
    {
        public long Id { get; set; }
        public string Name { get; set; }

        public string Contact { get; set; }

        public string Address { get; set; }
    }
}
