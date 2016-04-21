using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TravelBlog.Models
{
    public class ExperienceLocation
    {
        public List<Location> locationList { get; set; }
        public Experience experience { get; set; }
    }
}
