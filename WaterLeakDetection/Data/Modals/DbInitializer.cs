using WaterLeakDetection.Data;
using WaterLeakDetection.Data.Modals;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using System.Collections.Generic;
using System.Linq;

namespace WaterLeakDetection.Data
{
    public class DbInitializer
    {
        public static void Seed(IApplicationBuilder applicationBuilder)
        {
            var scopeFactory = applicationBuilder.ApplicationServices.GetRequiredService<IServiceScopeFactory>();
            using (var scope = scopeFactory.CreateScope())
            {
                var context = scope.ServiceProvider.GetRequiredService<AppDbContext>();


                if (!context.Departements.Any())
                {
                    context.Departements.AddRange(Departements.Select(c => c.Value));
                }

                if (!context.Sensors.Any())
                {
                    context.AddRange
                    (
                        new Sensor
                        {
                            Name = "SM-1",
                            CurrentLevel = 45,
                            IsOn = true,
                            Departement = Departements["Mechanical Departement"]
                        },
                        new Sensor
                        {
                            Name = "SM-2",
                            CurrentLevel = 55,
                            IsOn = true,
                            Departement = Departements["Mechanical Departement"]
                        },
                        new Sensor
                        {
                            Name = "SM-3",
                            CurrentLevel = 65,
                            IsOn = false,
                            Departement = Departements["Mechanical Departement"]
                        },
                        new Sensor
                        {
                            Name = "SE-1",
                            CurrentLevel = 65,
                            IsOn = false,
                            Departement = Departements["Electrical Departement"]
                        },
                        new Sensor
                        {
                            Name = "SE-2",
                            CurrentLevel = 65,
                            IsOn = false,
                            Departement = Departements["Electrical Departement"]
                        },
                        new Sensor
                        {
                            Name = "SE-3",
                            CurrentLevel = 95,
                            IsOn = false,
                            Departement = Departements["Electrical Departement"]
                        },
                        new Sensor
                        {
                            Name = "SE-4",
                            CurrentLevel = 15,
                            IsOn = true,
                            Departement = Departements["Electrical Departement"]
                        },
                        new Sensor
                        {
                            Name = "SC-1",
                            CurrentLevel = 65,
                            IsOn = false,
                            Departement = Departements["Civil Departement"]
                        },
                        new Sensor
                        {
                            Name = "SC-2",
                            CurrentLevel = 75,
                            IsOn = false,
                            Departement = Departements["Civil Departement"]
                        }
                        ,
                        new Sensor
                        {
                            Name = "SC-3",
                            CurrentLevel = 95,
                            IsOn = true,
                            Departement = Departements["Civil Departement"]
                        }
                    );
                }

                context.SaveChanges();
            }
        }

        private static Dictionary<string, Departement> departements;
        public static Dictionary<string, Departement> Departements
        {
            get
            {
                if (departements == null)
                {
                    var genresList = new Departement[]
                    {
                        new Departement { Name = "Civil Departement" },
                        new Departement { Name = "Data Center" },
                        new Departement { Name = "Mechanical Departement" },
                        new Departement { Name = "Electrical Departement" }
                    };

                    departements = new Dictionary<string, Departement>();

                    foreach (Departement genre in genresList)
                    {
                        departements.Add(genre.Name, genre);
                    }
                }

                return departements;
            }
        }
    }
}