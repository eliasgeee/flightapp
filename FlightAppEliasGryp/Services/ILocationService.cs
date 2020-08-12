using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.Devices.Geolocation;

namespace FlightAppEliasGryp.Services
{
    public interface ILocationService
    {
        Task<BasicGeoposition> GetCurrentLocationPlane();
    }
}
