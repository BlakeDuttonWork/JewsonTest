﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Jewson.BranchData.WebApi.Models
{

    public class Rootobject
    {
        public Branch[] Branches { get; set; }
    }

    public class Branch
    {
        [Key]
        public int Number { get; set; }
        public string Name { get; set; }
        public string Address1 { get; set; }
        public string Address2 { get; set; }
        public string Address3 { get; set; }
        public string Town { get; set; }
        public string County { get; set; }
        public string Postcode { get; set; }
        public float Latitude { get; set; }
        public float Longitude { get; set; }
        public string Telephone1 { get; set; }
        public string Email { get; set; }
        public string BranchManager { get; set; }
        public string OpeningHoursWeekend { get; set; }
        public string OpeningHoursMonToFri { get; set; }
        public string ClosingHoursWeekend { get; set; }
        public string ClosingHoursMonToFri { get; set; }
        public string ClosingHoursWeekDay { get; set; }
        public Specialism[] Specialisms { get; set; }
    }

    public class Specialism
    {
        [Key]
        public int Id { get; set; }
        public string Name { get; set; }
        public object Description { get; set; }
    }
}