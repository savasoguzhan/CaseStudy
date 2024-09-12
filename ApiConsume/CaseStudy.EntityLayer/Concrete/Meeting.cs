﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CaseStudy.EntityLayer.Concrete
{
    public class Meeting :BaseClass
    {

        public string MeetingName { get; set; }

        public DateTime StartDate { get; set; }

        public DateTime EndDate { get; set; }

        public string Description { get; set; }

        public string? DocumentPath { get; set; }
    }
}
