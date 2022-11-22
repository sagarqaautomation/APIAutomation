using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace APIGeneric.Environment
{

    public class APIGenericEnvironment
    {
        public static string baseURL = "https://reqres.in/";
        public static string getPageUser = "api/users?page=2";
        public static string postPageUser = "api/users";
        public static string getUserById(string id) => $"api/users/{id}";

    }

}
