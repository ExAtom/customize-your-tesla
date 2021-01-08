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
        public static Dictionary<Guid, CarConfiguration> SavedConfigs { get; private set; } = new Dictionary<Guid, CarConfiguration>();

        public static bool FileLoadingFailed { get; private set; } = false;

        private static string saveLocation = "save.txt";

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
                    string[] split = line.Split(':');
                    CarConfiguration cfg = new CarConfiguration(split[0], split[1]) { IsSaved = true };
                    SavedConfigs.Add(cfg.Id, cfg);
                }
                catch (Exception)
                {
                    SavedConfigs.Add(Guid.NewGuid(), null);
                }
            }
        }

        public static bool IsSaved(CarConfiguration cfg)
        {
            if (cfg == null)
            {
                return false;
            }
            return SavedConfigs.ContainsKey(cfg.Id);
        }

        public static bool IsNameUnique(string name)
        {
            return SavedConfigs.All(cfg =>cfg.Value!=null && cfg.Value.ConfigName != name);
        }

        public static void SaveState()
        {
            File.WriteAllLines(saveLocation, SavedConfigs.Select(c => c.Value == null ? "" : $"{c.Key}:{c.Value.ToToken()}"));
        }

        public static void AddOrOverride(CarConfiguration cfg)
        {
            var conflictingNames = SavedConfigs.Where(c => c.Value != null&& c.Value.ConfigName == cfg.ConfigName);
            foreach (var conflict in conflictingNames)
            {
                SavedConfigs.Remove(conflict.Key);
            }
            if (SavedConfigs.ContainsKey(cfg.Id))
            {
                SavedConfigs[cfg.Id] = cfg;
            }
            else
            {
                SavedConfigs.Add(cfg.Id, cfg);
            }
            SaveState();
        }

        public static void DeleteConfig(CarConfiguration cfg)
        {
            SavedConfigs.Remove(cfg.Id);
            SaveState();
        }
    }
}
