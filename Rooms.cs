using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dapper;

namespace WpfApp1
{
    public class Rooms
    {
        public int Room_ID { get; set; }

        public int Number_Beds { get; set; }

        public int Price { get; set; }

        public int Vacant_Beds { get; set; }

        public int Building_ID { get; set; }

        public int Counter { get; set; }
        
        //public string FullinfoR
        //{
        //    get
        //    {
        //        return $" { Room_ID } { Number_Beds } { Price } ";
        //    }
        //}
    }
}
