using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Npgsql;

namespace LemoTask
{
    public class Connectioncs
    {
        private static NpgsqlConnection? con = null;

        public static NpgsqlConnection? getConnection()
        {
            string url = "";
            try
            {
                if (con == null)
                {
                    con = new NpgsqlConnection(url);
                }
                return con;
            }
            catch (Exception ex)
            {
                
                return null;
            }
        }
    }
}
