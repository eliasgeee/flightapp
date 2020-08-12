using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.Devices.Geolocation;
using Windows.Storage;
using Windows.UI.Core;

namespace FlightAppEliasGryp.Services
{
    public class LocationService : ILocationService
    {
        public async Task<BasicGeoposition> GetCurrentLocationPlane()
        {
            BasicGeoposition basicGeoposition = new BasicGeoposition();
                try
                {
                // Update the UI with the completion status of the background task
                // The Run method of the background task sets this status. 
                //  var settings = ApplicationData.Current.LocalSettings;
                // Extract and display location data set by the background task if not null
                //      basicGeoposition.Latitude = (settings.Values["Latitude"] == null) ? 0.0 : (double) settings.Values["Latitude"];
                //      basicGeoposition.Longitude = (settings.Values["Longitude"] == null) ? 0.0 : (double) settings.Values["Longitude"];
                Geolocator geolocator = new Geolocator();
                Geoposition pos = await geolocator.GetGeopositionAsync();
                return pos.Coordinate.Point.Position;
            }
                catch (Exception ex)
                {
                }
            return basicGeoposition;
        }
    }
}
