using FlightAppEliasGryp.Models.Entertainment.Audio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FlightAppEliasGryp.Models.Entertainment
{
    public abstract class MultiMedia
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public double Duration { get; set; }
        public string FileName { get; set; }
        public string Thumbnail { get; set; }
        public Person MainCreator { get; set; }
        public List<Person> OptionalCreators { get; set; }
        public List<object> Items { get; set; }
    }
}
