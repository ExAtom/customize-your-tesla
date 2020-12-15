using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using TeslaCarConfigurator.Data;

namespace TeslaCarConfigurator.Helpers
{
    public static class SaveManager
    {
        public static List< CarConfiguration> SavedConfigs { get; private set; } = new List<CarConfiguration>();

        public static bool FileLoadingFailed { get; private set; } = false;

        private static string saveLocation = "save.txt";

        public static void SaveToFile(CarConfiguration carConfiguration)
        {
            string token = carConfiguration.ToToken();
            File.AppendAllLines(saveLocation, new List<string>() { token });
        }

        public static void LoadSavedConfigs()
        {
            string[] lines = new string[0];
            try
            {
                lines = File.ReadAllLines(saveLocation);
            }
            catch (FileNotFoundException)
            {
            }
            catch (Exception)
            {
                FileLoadingFailed = true;
            }
            for (int i = 0; i < lines.Length; i++)
            {
                string line = lines[i];
                try
                {
                    CarConfiguration cfg = new CarConfiguration(line);
                    SavedConfigs.Add(cfg);
                }
                catch (Exception)
                {
                    SavedConfigs.Add(null);
                }
            }
        }
    }
}
