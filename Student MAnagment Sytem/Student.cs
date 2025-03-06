﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Student_Managment_Sytem
{
    public class Student
    {
        
        public int Id { get; set; }    
        public string? Name { get; set; }
        public int Age { get; set; }
        public string Address { get; set; }
        public string Email { get; set; }
        public string PhoneNumber { get; set; }
        public string Batch { get; set; }
        public string Stream { get; set; }
        public DateTime DateOfBirth { get; set; }
        public string Gender { get; set; }
        public string GuardianName { get; set; }
        public string GuardianContact { get; set; }
        public DateTime EnrollmentDate { get; set; }
    }
}
