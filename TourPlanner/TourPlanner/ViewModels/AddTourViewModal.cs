using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Net.Http;
using System.Net;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using System.Windows.Input;
using TourPlanner.Models;

public class AddTourViewModel : INotifyPropertyChanged
{
    // ... Ihre vorhandenen Eigenschaften und Methoden
    public string Tourname { get; set; } = null!;
    public string? Tourdescription { get; set; }
    public string Tourfrom { get; set; } = null!;
    public string Tourto { get; set; } = null!;
    public string Tourtransporttype { get; set; } = null!;
    public string? Tourdistance { get; set; }
    public string? Tourtimeestimate { get; set; }
    public string? Tourrouteinformation { get; set; }

    public ICommand AddTourCommand { get; private set; }

    public event Action CloseRequested;

    public AddTourViewModel()
    {
        AddTourCommand = new RelayCommand(async () => await AddTourAsync());
    }

    public event PropertyChangedEventHandler? PropertyChanged;

    private async Task AddTourAsync()
    {
        try { 
            HttpClient httpClient = new HttpClient();
            // https://www.mapquestapi.com/directions/v2/route?key=KEY&from=Clarendon Blvd,Arlington,VA&to=2400+S+Glebe+Rd,+Arlington,+VA
            string url = $"https://www.mapquestapi.com/directions/v2/route?key=Onp32CiclUmZec2wy29CPWe7wognIARR&from={this.Tourfrom}&to={this.Tourto}&transportType={this.Tourtransporttype}";

            System.Diagnostics.Debug.WriteLine("TEEEEEEEEEEEEEESSSSSSSSSSSSSSTTTTTTTTT");

            HttpResponseMessage response = await httpClient.GetAsync(url);

            if (response.IsSuccessStatusCode)
            {
                System.Diagnostics.Debug.WriteLine("API-Aufruf erfolgreich");
                System.Diagnostics.Debug.WriteLine(response.StatusCode);
                System.Diagnostics.Debug.WriteLine(response.Content);
                string jsonResponse = await response.Content.ReadAsStringAsync();

                // Verwenden Sie JsonSerializer, um die Antwort zu deserialisieren
                var apiResponse = JsonSerializer.Deserialize<MapQuestResponse>(jsonResponse);

                // Speichern Sie die Daten in der Datenbank
                using (TourPlannerContext context = new TourPlannerContext())
                {
                    Tour newTour = new Tour
                    {
                        Tourname = this.Tourname,
                        Tourdescription = this.Tourdescription,
                        Tourfrom = this.Tourfrom,
                        Tourto = this.Tourto,
                        Tourtransporttype = this.Tourtransporttype,
                        Tourdistance = this.Tourdistance,
                        Tourtimeestimate = this.Tourtimeestimate,
                        Tourrouteinformation = this.Tourrouteinformation,
                        // Fügen Sie hier weitere Felder aus der API-Antwort hinzu, z.B.
                        // Distance = apiResponse.Route.Distance,
                        // Time = apiResponse.Route.Time
                    };
                    context.Tours.Add(newTour);
                    await context.SaveChangesAsync();
                }

                // Schließen Sie die AddTourView
                //OnAddTour();
            }
            else { /* Fehlerbehandlung */
                System.Diagnostics.Debug.WriteLine("API-Aufruf unerfolgreich");
                System.Diagnostics.Debug.WriteLine(response.StatusCode);
                System.Diagnostics.Debug.WriteLine(response.Content);
            }
        } catch (Exception e)
        {
            System.Diagnostics.Debug.WriteLine($"Exception: {e.Message}");
        }
    }

    private void OnAddTour()
    {
        // Führen Sie Ihre Logik zum Hinzufügen einer Tour aus
        // ...

        // Event auslösen
        CloseRequested?.Invoke();
    }

}
