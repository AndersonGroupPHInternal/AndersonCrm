﻿using BaseModel;
using System;
using System.Collections.Generic;
using System.Configuration;

namespace AndersonCRMModel
{
    public class Employee : Base
    {
        public DateTime DateHired { get; set; }
        public DateTime DateStarted { get; set; }
        public DateTime? DateEnded { get; set; }

        public int TeamId { get; set; }
        public int DepartmentId { get; set; }
        public int CompanyId { get; set; }
        public int EmployeeId { get; set; }
        public int JobTitleId { get; set; }
        public int ManagerEmployeeId { get; set; }

        public string EmployeeNumber { get; set; }
        public string Email { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string MiddleName { get; set; }
        public string Pin { get; set; }
        public string EmployeeImage => System.Configuration.ConfigurationManager.AppSettings["filepath"] + EmployeeId.ToString()+".jpg";


        public virtual Department Department { get; set; }
        public virtual Company Company { get; set; }
        public virtual JobTitle JobTitle { get; set; }
        public virtual Team Team { get; set; }

        public virtual ICollection<EmployeeDepartment> EmployeeDepartments { get; set; }
        public virtual ICollection<EmployeeTeam> EmployeeTeams { get; set; }
        public virtual ICollection<Asset> Assets { get; set; }
        public virtual ICollection<AssetHistory> AssetHistories { get; set; }
    }
}
