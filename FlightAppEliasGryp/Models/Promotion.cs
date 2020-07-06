using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FlightAppEliasGryp.Models
{
    public class Promotion
    {
        public int Id { get; set; }
        public int Percentage { get; set; }
        public DateTime Start { get; set; }
        public bool IsActive { get; set; }

        public Promotion() { }
        public Promotion(int percentage)
        {
            Percentage = percentage;
            Start = DateTime.Now;
            IsActive = true;
        }
    }
}
