using System.Text;
using BuilderPattern.M1;
using BuilderPattern.M2;

var sb = new StringBuilder();

sb.Append("emre").Append(" ").Append("Kilic");
sb.Append(" Kilic");

var fullname = sb.ToString();

var eb = new EndpointBuilder("https://localhost");

eb
 .Append("api")
 .Append("v1")
 .Append("user")
 .AppendParam("id", "10")
 .AppendParam("username", "emre");

var url = eb.Build();

var empBuilder = new EmployeeBuilderM1();

var employee = empBuilder
    .SetFullName("Emre KILIC")
    .SetUserName("emrekilic")
    .SetEmailAddress("emrekilic@gmail.com")
    .BuildEmployee();

var emp = GenerateEmployee("emre kilic", "emrekilic@gmail.com", 0);
Console.WriteLine("Email Address: " + emp.EmailAddress);

EmployeeM2 GenerateEmployee(string fullName, string emailAddress, int empType)
{
    IEmployeeBuilderM2 employeeBuilder;
    if (empType == 0)
        employeeBuilder = new InternalEmployeeBuilder();
    else
        employeeBuilder = new ExternalEmployeeBuilder();

    employeeBuilder.SetFullName(fullName);
    employeeBuilder.SetEmailAddress(emailAddress);

    return employeeBuilder.BuildEmployee();
}