using System;
using System.Collections.Generic;
using System.IO;
using System.IO.Compression;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Security.Policy;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using System.Windows.Controls;
using TourPlanner.Models;

public class MapQuestAPIService
{
    public async Task<Tour> GetTourApiData(string tourName, string? tourDescription, string tourFrom, string tourTo, ComboBoxItem transportType)
    {
        try
        {
            //System.Diagnostics.Debug.WriteLine($"GetTourApiData: {tourName + tourFrom + tourTo + transportType.Content.ToString()}");
            HttpClient httpClient = new HttpClient();

            string tourUrl = $"https://www.mapquestapi.com/directions/v2/route?key=Onp32CiclUmZec2wy29CPWe7wognIARR&from={tourFrom}&to={tourTo}&transportType={transportType.Content.ToString()}";
            string staticMapUrl = $"https://www.mapquestapi.com/staticmap/v5/map?key=Onp32CiclUmZec2wy29CPWe7wognIARR&start={tourFrom}&end={tourTo}&format=png";

            HttpResponseMessage response = await httpClient.GetAsync(tourUrl);
            if (response.IsSuccessStatusCode)
            {

                string jsonTourResponse = await response.Content.ReadAsStringAsync();
                var apiResponseTour = JsonSerializer.Deserialize<MapQuestResponse>(jsonTourResponse);

                return new Tour
                {
                    Tourname = tourName,
                    Tourdescription = tourDescription,
                    Tourfrom = tourFrom,
                    Tourto = tourTo,
                    Tourtransporttype = transportType.Content.ToString(),
                    Tourdistance = apiResponseTour.route.distance.ToString(),
                    Tourtimeestimate = apiResponseTour.route.formattedTime.ToString(),
                    Tourrouteinformation = null
                };
            }
            return null;
        }
        catch (Exception e)
        {
            System.Diagnostics.Debug.WriteLine($"Exception: {e.Message}");
            return null;
        }
    }

    public async Task<string> GetApiMapData(Tour tour)
    {
        try
        {
            HttpClient httpClient = new HttpClient();
            string staticMapUrl = $"https://www.mapquestapi.com/staticmap/v5/map?key=Onp32CiclUmZec2wy29CPWe7wognIARR&start={tour.Tourfrom}&end={tour.Tourto}&format=png";

            byte[] mapResponse = await httpClient.GetByteArrayAsync(staticMapUrl);

            string imagePath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "..\\..\\..\\Images");
            Directory.CreateDirectory(imagePath);

            string imageFile = Path.Combine(imagePath, $"Tour_{tour.Tourid}.png");

            System.Diagnostics.Debug.WriteLine($"saveImageFile: {imagePath}");
            File.WriteAllBytes(imageFile, mapResponse);
            return imageFile;
        }
        catch (Exception e)
        {
            System.Diagnostics.Debug.WriteLine("GetMapData fail");
            System.Diagnostics.Debug.WriteLine($"Exception: {e.Message}");
            return null;
        }
    }

}
