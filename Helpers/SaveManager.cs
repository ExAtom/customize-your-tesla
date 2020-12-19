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
        public static List<CarConfiguration> SavedConfigs { get; private set; } = new List<CarConfiguration>();

        public static bool FileLoadingFailed { get; private set; } = false;

        private static string saveLocation = "save.txt";

        public static void SaveToFile(CarConfiguration carConfiguration)
        {
            string token = carConfiguration.ToToken();
            File.AppendAllLines(saveLocation, new List<string>() { token });
        }

        public static void LoadSavedConfigs()
        {
            SavedConfigs.Clear();
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
                    CarConfiguration cfg = new CarConfiguration(line) {IsSaved=true };
                    SavedConfigs.Add(cfg);
                }
                catch (Exception)
                {
                    SavedConfigs.Add(null);
                }
            }
        }

        public static bool IsSaved(CarConfiguration cfg)
        {
            return SavedConfigs.Any(c => c != null && c.ConfigName == cfg.ConfigName);
        }

        public static void SaveState()
        {
            File.WriteAllLines(saveLocation, SavedConfigs.Select(c => c == null ? "" : c.ToToken()));
        }

        public  static void UpdateSavedConfig(CarConfiguration cfg) { 
            int alreadySavedIndex = SavedConfigs.FindIndex(c => c != null && c.ConfigName == cfg.ConfigName);
            if (alreadySavedIndex >= 0)
            {
                SavedConfigs[alreadySavedIndex] = cfg;
            }
            SaveState();
        }

        public static void SaveNewConfig(CarConfiguration cfg) {
            SavedConfigs.Add(cfg);
            cfg.IsSaved = true;
            SaveState();
        }

        public static void DeleteConfig(CarConfiguration cfg)
        {
            SavedConfigs.RemoveAll(c => c?.ConfigName == cfg.ConfigName);
            SaveState();
        }
    }
}
