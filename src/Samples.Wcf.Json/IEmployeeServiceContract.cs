using System.Collections.Generic;
using System.ServiceModel;
using System.ServiceModel.Web;

namespace Samples.Wcf.Json
{

    [ServiceContract]
    public interface IEmployeeServiceContract
    {
        [WebGet(UriTemplate ="/Employees",ResponseFormat =WebMessageFormat.Json)]
        [OperationContract]
        List<Employee> GetEmployees();
        [WebGet(UriTemplate ="/Employees/{id}",ResponseFormat =WebMessageFormat.Json)]
        [OperationContract]
        Employee GetEmployeeById(string id);
    }


}