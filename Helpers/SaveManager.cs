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
        public static Dictionary<string, CarConfiguration> SavedConfigs { get; private set; } = new Dictionary<string, CarConfiguration>();

        public static List<int> InvalidConfigs { get; private set; } = new List<int>();

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
                    if (SavedConfigs.ContainsKey(cfg.ConfigName))
                    {
                        SavedConfigs[cfg.ConfigName] = cfg;
                    }
                    else
                    {
                        SavedConfigs.Add(cfg.ConfigName, cfg);
                    }
                }
                catch (Exception)
                {
                    InvalidConfigs.Add(i + 1);
                }
            }
        }
    }
}
