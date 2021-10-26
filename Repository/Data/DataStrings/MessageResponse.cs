using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Repository.Data.DataStrings
{
    public class MessageResponse
    {
        public static string Response_Success = "Query carried out successfully.";
        public static string Invalid_Object = "{0} invalid.";
        public static string Invalid_Token = "Invalid token.";
        public static string Object_NotFound = "{0} not found.";
        public static string Object_NotExists = "Object not exists.";
        public static string Invalid_user = "Invalid username or password";
    }
}
