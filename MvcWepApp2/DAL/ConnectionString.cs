using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MvcWepApp2.DAL
{
    public static class ConnectionString
    {
        private static string _connection = @"Data Source=NED\NED; Initial Catalog = YonetimPaneli1; Integrated Security=True";
        public static string Connection { get { return _connection; } }

    }
}