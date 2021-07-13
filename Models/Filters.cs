using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NextCard.Models
{
    public class Filters
    {
        public Filters(string filterstring)
        {
            FilterString = filterstring ?? "0-0";
            string[] filters = FilterString.Split('-');
            int tempSprintId = Int32.Parse(filters[0]);
            int tempStatusId = Int32.Parse(filters[1]);
            SprintId = tempSprintId;
            StatusId = tempStatusId;
        }
        public string FilterString { get; }
        public int SprintId { get; }
        public int StatusId { get; }

        public bool HasSprint => SprintId != 0;
        public bool HasStatus => StatusId != 0;

    }
}
