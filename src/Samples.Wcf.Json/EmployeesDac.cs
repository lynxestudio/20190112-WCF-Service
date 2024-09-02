using System;
using System.Collections.Generic;
using Oracle.DataAccess.Client;
using System.Data;

namespace Samples.Wcf.Json
{
    internal static class EmployeesDac {
        public static List<Employee> GetEmployees() {
            List<Employee> resp = null;
  string commandText = "SELECT EMPLOYEE_ID,FIRST_NAME,LAST_NAME,EMAIL,PHONE_NUMBER,HIRE_DATE,SALARY,COMMISSION_PCT FROM EMPLOYEES";
            using (OracleConnection conn = ConnectionManager.GetConnection()) {
                using (OracleCommand cmd = new OracleCommand(commandText,conn)) {
                    cmd.CommandType = CommandType.Text;
                    using (OracleDataReader reader = cmd.ExecuteReader()) {
                        if(reader.HasRows) {
                            resp = new List<Employee>();
                            while (reader.Read()) {
                                resp.Add(new Employee {
                                    EmployeeId = Util.CastNullToInt(reader, "EMPLOYEE_ID").Value,
                                    Commission = Util.CastNullToDecimal(reader, "COMMISSION_PCT"),
                                    Email = Util.CastNullToString(reader, "EMAIL"),
                                    FirstName = Util.CastNullToString(reader, "FIRST_NAME"),
                                    HireDate = Util.CastNullToDateTime(reader, "HIRE_DATE").Value.ToString("dd/MM/yyyy hh:mm:ss"),
                                    LastName = Util.CastNullToString(reader, "LAST_NAME"),
                                    PhoneNumber = Util.CastNullToString(reader, "PHONE_NUMBER"),
                                    Salary = Util.CastNullToDecimal(reader, "SALARY")
                                });
                            }
                        }
                    }
                }
            }
            return resp;
        }
        public static Employee GetEmployeeById(string id) {
            Employee resp = null;
  string commandText = "SELECT EMPLOYEE_ID,FIRST_NAME,LAST_NAME,EMAIL,PHONE_NUMBER,HIRE_DATE,SALARY,COMMISSION_PCT FROM EMPLOYEES WHERE EMPLOYEE_ID = :ID";
            using (OracleConnection conn = ConnectionManager.GetConnection()) {
                using (OracleCommand cmd = new OracleCommand(commandText, conn)) {
                    cmd.CommandType = CommandType.Text;
                    cmd.Parameters.Add(new OracleParameter("ID", id));
                    using (OracleDataReader reader = cmd.ExecuteReader()) {
                        if (reader.HasRows) {
                            while (reader.Read()) {
                                resp = new Employee {
                                    EmployeeId = Util.CastNullToInt(reader, "EMPLOYEE_ID").Value,
                                    Commission = Util.CastNullToDecimal(reader, "COMMISSION_PCT"),
                                    Email = Util.CastNullToString(reader, "EMAIL"),
                                    FirstName = Util.CastNullToString(reader, "FIRST_NAME"),
                                    HireDate = Util.CastNullToDateTime(reader, "HIRE_DATE").Value.ToString("dd/MM/yyyy hh:mm:ss"),
                                    LastName = Util.CastNullToString(reader, "LAST_NAME"),
                                    PhoneNumber = Util.CastNullToString(reader, "PHONE_NUMBER"),
                                    Salary = Util.CastNullToDecimal(reader, "SALARY")
                                };
                            }
                        }
                    }
                }
            }
            return resp;
        }
    }
}
