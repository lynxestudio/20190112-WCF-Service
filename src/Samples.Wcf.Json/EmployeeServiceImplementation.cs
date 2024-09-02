using System.Collections.Generic;

namespace Samples.Wcf.Json
{
    public class EmployeeServiceImplementation : IEmployeeServiceContract
    {
        public Employee GetEmployeeById(string id)
        {
            Employee resp = null;
            resp = EmployeesDac.GetEmployeeById(id);
            return resp;
        }

        public List<Employee> GetEmployees()
        {
            List<Employee> resp = null;
            resp = EmployeesDac.GetEmployees();
            return resp;
        }
    }
}