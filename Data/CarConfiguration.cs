using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TeslaCarConfigurator.Data
{
    public class CarConfiguration
    {
        private string configName = "";

        public static int MaxNameLength { get; private set; } = 255;

        public bool IsSaved { get; set; } = false;

        public Guid Id { get; set; }

        public string ConfigName
        {
            get => configName; set
            {
                configName = string.Join("", value.Take(MaxNameLength));
            }
        }

        public int TotalPrice => new Feature[] { CarModel, Battery, Painting, Wheels, Transmission, Interior, Exterior, SoftwareFeatures }.Sum(feature => feature.CalculateAdditionalPrices());

        // Sziszi
        public Model CarModel { get; set; }

        // Ádosz
        public Battery Battery { get; set; }

        // Sziszi
        public Painting Painting { get; set; }

        // Sziszi
        public WheelConfiguration Wheels { get; set; }

        // Ádosz
        public Transmission Transmission { get; set; }

        // Attila
        public Interior Interior { get; set; }

        // Attila
        public Exterior Exterior { get; set; }

        // Attila
        public SoftwareFeatures SoftwareFeatures { get; set; }

        // Ádosz
        public CustomerDetails CustomerDetails { get; set; }

        public CarConfiguration()
        {
            CarModel = new Model(0);
            Battery = new Battery(0);
            Painting = new Painting(0);
            Wheels = new WheelConfiguration(0);
            Transmission = new Transmission(0);
            Interior = new Interior(false, false, false, false, false, 0, 0);
            Exterior = new Exterior(false, false, false);
            SoftwareFeatures = new SoftwareFeatures(false, false, false, false);
            CustomerDetails = new CustomerDetails();
            Id = Guid.NewGuid();
        }

        public CarConfiguration(string token)
        {
            DeserializeFromToken(token);
            Id = Guid.NewGuid();
        }

        public CarConfiguration(string id, string token)
        {
            Id = Guid.Parse(id);
            DeserializeFromToken(token);
        }

        private void DeserializeFromToken(string token)
        {
            byte[] data = Convert.FromBase64String(token);
            int index = 1;
            byte nameLength = data[0];

            ConfigName = Encoding.UTF8.GetString(data, index, nameLength);

            index += nameLength;

            CarModel = new Model(data.Skip(index).Take(Model.ByteLength).ToArray());
            index += Model.ByteLength;

            Battery = new Battery(data.Skip(index).Take(Battery.ByteLength).ToArray());
            index += Battery.ByteLength;

            Painting = new Painting(data.Skip(index).Take(Painting.ByteLength).ToArray());
            index += Painting.ByteLength;

            Wheels = new WheelConfiguration(data.Skip(index).Take(WheelConfiguration.ByteLength).ToArray());
            index += WheelConfiguration.ByteLength;

            Transmission = new Transmission(data.Skip(index).Take(Transmission.ByteLength).ToArray());
            index += Transmission.ByteLength;

            Interior = new Interior(data.Skip(index).Take(Interior.ByteLength).ToArray());
            index += Interior.ByteLength;

            Exterior = new Exterior(data.Skip(index).Take(Exterior.ByteLength).ToArray());
            index += Exterior.ByteLength;

            SoftwareFeatures = new SoftwareFeatures(data.Skip(index).Take(SoftwareFeatures.ByteLength).ToArray());

        }

        public string ToToken()
        {
            List<byte> bytes = new List<byte>();

            bytes.Add((byte)ConfigName.Length);
            byte[] nameBytes = Encoding.UTF8.GetBytes(ConfigName);

            bytes.AddRange(nameBytes);

            if (CarModel != null)
            {
                bytes.AddRange(CarModel.ToBytes());
            }

            if (Battery != null)
            {
                bytes.AddRange(Battery.ToBytes());
            }

            if (Painting != null)
            {
                bytes.AddRange(Painting.ToBytes());
            }

            if (Wheels != null)
            {
                bytes.AddRange(Wheels.ToBytes());
            }

            if (Transmission != null)
            {
                bytes.AddRange(Transmission.ToBytes());
            }

            if (Interior != null)
            {
                bytes.AddRange(Interior.ToBytes());
            }

            if (Exterior != null)
            {
                bytes.AddRange(Exterior.ToBytes());
            }

            if (SoftwareFeatures != null)
            {
                bytes.AddRange(SoftwareFeatures.ToBytes());
            }

            return Convert.ToBase64String(bytes.ToArray());
        }
    }
}
