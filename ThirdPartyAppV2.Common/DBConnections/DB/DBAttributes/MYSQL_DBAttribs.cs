using PostSharp.Patterns.Diagnostics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ThirdPartyAppV2.Common.DBConnections.DB.DBAttributes
{
    public class MYSQL_DBAttribs
    {
        public string Server { get; set; }
        public string Database { get; set; }
        public uint Port { get; set; }
        public string UserId { get; set; }
        public string Password { get; set; }
    }
}
