﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab_Workflow_Manager.Models
{
    public class Sample
    {
        public long Id { get; set; }

        public Patient Patient { get; set; }

        public SampleType SampleType { get; set; }


    }
}
