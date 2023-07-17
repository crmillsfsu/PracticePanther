using PP.Library.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PP.Library.Services
{
    public class TimeService
    {
        private static TimeService? instance;
        private List<Time> times;

        public List<Time> Times
        {
            get
            {
                return times;
            }
        }

        public static TimeService Current
        {
            get
            {
                if(instance == null)
                {
                    instance = new TimeService();
                }

                return instance;
            }
        }
        private TimeService()
        {
            times = new List<Time> { 
                new Time{Id = 1, EmployeeId = 1, ProjectId = 1, Hours=1.75M, Narrative = "TEST TIME ENTRY"},
                new Time{Id = 2, EmployeeId = 1, ProjectId = 1, Hours=1.25M, Narrative = "ANOTHER TIME ENTRY"}
            };
        }

        public Time AddOrUpdate(Time t)
        {
            times.Add(t);
            return t;
        }
    }
}
