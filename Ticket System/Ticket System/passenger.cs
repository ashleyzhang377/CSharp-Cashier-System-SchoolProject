using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Test
{
    class passenger
    {
        public int securityNumber { get; set; }
        public int passengerNo { get; set; }

        public string[] firstName { get; set; }
        public string[] lastName { get; set; }
        public string[] seatNumber { get; set; }

        public new string ToString()
        {
            return (firstName[passengerNo] + ' ' + lastName[passengerNo] + ',' + securityNumber + ' ' + '#' + seatNumber[passengerNo]);
        }

    }
}
