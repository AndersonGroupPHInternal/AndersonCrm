using AndersonCRMEntity;
using System.Data.Entity;

namespace AndersonCRMContext
{
    public class DBInitializer : CreateDatabaseIfNotExists<Context>
    {
        public DBInitializer()
        {

        }
        protected override void Seed(Context context)
        {
            context.Companies.Add(
                new ECompany
                {

                    CompanyName = "No Specific Company"
                });
            context.SaveChanges();
            var company = context.Companies.Add(
                new ECompany
                {

                    CompanyName = "AndersonGroup"
                });
            context.SaveChanges();

            if (company != null)
            {
                var department = context.Departments.Add(
                new EDepartment
                {
                   Description = "Software Development"
                });
                context.SaveChanges();

                if (department != null)
                {

                    var employee = context.Employees.Add(
                    new EEmployee
                    {
                        CompanyId = 1,
                        PositionId = 1,
                        DepartmentId = 1,

                        ManagerEmployeeId = 1,
                        FirstName = "Adrianne Claude",
                        LastName = "Tubig",
                        MiddleName = "Ramos",
                        Email = "andersongroup@yahoo.com",
                        JobTitle = "Junior Software Developer",
                        HiringDate = "September 09, 2017",
                        StartingDate = "Septemeber 09, 2017"
                    
                    });
                    context.SaveChanges();
                

                    if (employee != null)
                    {
                        var peripheral = context.Peripherals.Add(
                        new EPeripheral
                        {
                            EmployeeId = employee.EmployeeId,
                            Date = "September 09, 2017",
                            PeripheralColor = "fafafa",
                            PeripheralName = "Computer",
                            Description = "computer",
                            SerialNumber = "AGPDSK00134"
                        });
                        context.Peripherals.Add(
                        new EPeripheral
                        {
                            EmployeeId = employee.EmployeeId,
                            Date = "September 09, 2017",
                            PeripheralColor = "fafafa",
                            PeripheralName = "Webcam",
                            Description = "webcam",
                            SerialNumber = "AGPCAM00004"

                        });
                        context.SaveChanges();

                        if (peripheral != null)
                        {
                            var position = context.Positions.Add(
                            new EPosition
                            {
                                PositionName = "Manager",
                                PositionColor = "bababa"
                            });
                            context.SaveChanges();
                        }
                    }

                }
            }
            base.Seed(context);

        }
    }
}   
