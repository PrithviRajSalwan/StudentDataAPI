using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace StudentDataAPI.Models
{
    public class CFilterData
    {
        public int FilterType {
            get; set;
        }
        public string FilterQuery
        {
            get; set;
        }

    }
}
