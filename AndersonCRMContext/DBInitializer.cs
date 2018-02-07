using AndersonCRMEntity;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;

namespace AndersonCRMContext
{
    public class DBInitializer : CreateDatabaseIfNotExists<Context>
    {
        public DBInitializer()
        {

        }
        protected override void Seed(Context context)
        {
            var company = context.Companies.Add(
                new ECompany
                {
                    CreatedDate = DateTime.Now,

                    CreatedBy = 0,

                    Name = "AndersonGroupPH"
                });

            List<EDepartment> departments = new List<EDepartment>()
            {
                new EDepartment
                {
                    CreatedDate = DateTime.Now,

                    CreatedBy = 0,

                    Name = "Software Development"
                },
                new EDepartment
                {
                    CreatedDate = DateTime.Now,

                    CreatedBy = 0,

                    Name = "Software Development Philippines"
                }
            };
            context.Departments.AddRange(departments);

            List<EJobTitle> jobTitles = new List<EJobTitle>()
            {
                new EJobTitle
                {
                    CreatedDate = DateTime.Now,

                    CreatedBy = 0,

                    Name = "Intern Document Specialist"
                },
                new EJobTitle
                {
                    CreatedDate = DateTime.Now,

                    CreatedBy = 0,

                    Name = "Intern Project Manager"
                },
                new EJobTitle
                {
                    CreatedDate = DateTime.Now,

                    CreatedBy = 0,

                    Name = "Intern Software Architect"
                },
                new EJobTitle
                {
                    CreatedDate = DateTime.Now,

                    CreatedBy = 0,

                    Name = "Intern Software Developer"
                },
                new EJobTitle
                {
                    CreatedDate = DateTime.Now,

                    CreatedBy = 0,

                    Name = "Junior Software Developer"
                },
                new EJobTitle
                {
                    CreatedDate = DateTime.Now,

                    CreatedBy = 0,

                    Name = "Senior Software Developer"
                },
                new EJobTitle
                {
                    CreatedDate = DateTime.Now,

                    CreatedBy = 0,

                    Name = "Software Developer"
                }
            };            
            context.JobTitles.AddRange(jobTitles);

            List<EAssetType> assetTypes = new List<EAssetType>()
            {
                new EAssetType
                {
                    CreatedDate = DateTime.Now,

                    CreatedBy = 0,

                    Name = "Webcam"
                },
                new EAssetType
                {
                    CreatedDate = DateTime.Now,

                    CreatedBy = 0,

                    Name = "Desktop Computer"
                }
            };
            context.AssetTypes.AddRange(assetTypes);

            context.SaveChanges();

            var jobTitle = context.JobTitles.FirstOrDefault(a => a.Name == "Software Developer");

            if (company != null && jobTitle != null)
            {
                var employee = context.Employees.Add(
                new EEmployee
                {
                    CreatedDate = DateTime.Now,
                    DateHired = new DateTime(2016, 04, 15),
                    DateStarted = new DateTime(2016, 04, 22),

                    CompanyId = company.CompanyId,
                    CreatedBy = 0,
                    JobTitleId = jobTitle.JobTitleId,
                    ManagerEmployeeId = 0,
                    Email = "adriannet@andersongroup.uk.com",
                    FirstName = "Adrianne Claude",
                    LastName = "Tubig",
                    MiddleName = "Ramos",

                });
                context.SaveChanges();

                var assetType = context.AssetTypes.FirstOrDefault(a => a.Name == "Desktop Computer");

                if (employee != null && assetType != null)
                {
                    var asset = context.Assets.Add(
                    new EAsset
                    {
                        CreatedDate = DateTime.Now,

                        CreatedBy = 0,

                        EmployeeId = employee.EmployeeId,
                        AssetTypeId = assetType.AssetTypeId,

                        AssetTag = "AGPDSK00134",
                        Description = "Work Computer",
                        Name = "AGPDSK00134",
                        SerialNumber = "AGPDSK00134"
                    });
                    context.SaveChanges();

                    if (asset != null)
                    {
                        context.AssetHistories.Add(
                            new EAssetHistory
                            {
                                CreatedDate = DateTime.Now,
                                DateAssigned = new DateTime(2016, 04, 22),

                                CreatedBy = 0,
                                EmployeeId = employee.EmployeeId,
                                AssetId = asset.AssetId
                            });
                        context.SaveChanges();
                    }
                }

                var departmentSoftwareDevelopment = context.Departments.FirstOrDefault(a => a.Name == "Software Development");
                if (employee != null && departmentSoftwareDevelopment != null)
                {
                    context.EmployeeDepartments.Add(
                        new EEmployeeDepartment
                        {
                            CreatedDate = DateTime.Now,

                            CreatedBy = 0,
                            DepartmentId = departmentSoftwareDevelopment.DepartmentId,
                            EmployeeId = employee.EmployeeId
                        });
                    context.SaveChanges();
                }

                var departmentSoftwareDevelopmentPhilippines = context.Departments.FirstOrDefault(a => a.Name == "Software Development Philippines");
                if (employee != null && departmentSoftwareDevelopmentPhilippines != null)
                {
                    context.EmployeeDepartments.Add(
                        new EEmployeeDepartment
                        {
                            CreatedDate = DateTime.Now,

                            CreatedBy = 0,
                            DepartmentId = departmentSoftwareDevelopmentPhilippines.DepartmentId,
                            EmployeeId = employee.EmployeeId
                        });
                    context.SaveChanges();
                }

            }

            base.Seed(context);

        }
    }
}
