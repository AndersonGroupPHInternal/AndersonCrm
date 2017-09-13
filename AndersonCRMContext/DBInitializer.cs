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
                var employee = context.Employees.Add(
                    new EEmployee
                    {
                        CompanyId = company.CompanyId,
                        PositionId = 1,
                        EmployeeColor = "000000",
                        EmployeeNumber = "A0090",
                        FirstName = "Adrianne Claude",
                        LastName = "Tubig",
                        MiddleName = "Ramos"
                    });
                context.SaveChanges();

                if (employee != null)
                {
                    var peripheral = context.Peripherals.Add(
                    new EPeripheral
                    {
                        EmployeeId = employee.EmployeeId,
                        PeripheralColor ="fafafa",
                        PeripheralName = "Computer",
                        Description = "computer",
                        SerialNumber = "AGPDSK00134"
                    });
                    context.Peripherals.Add(
                    new EPeripheral
                    {
                        EmployeeId = employee.EmployeeId,
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
            base.Seed(context);

            }
        }
    }
