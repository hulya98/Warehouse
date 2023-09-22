using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Intrinsics.Arm;
using System.Text;
using System.Threading.Tasks;

namespace Warehouse.Utils
{
    public static class HashHelper
    {
        public  static string  Hash(string data)
        {
            byte[] bytes = Encoding.UTF8.GetBytes(data);

            byte[] hash = System.Security.Cryptography.SHA256.HashData(bytes);

            return Encoding.UTF8.GetString(hash);
        }
    }
}
