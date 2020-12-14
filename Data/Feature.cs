using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TeslaCarConfigurator.Data
{
    public abstract class Feature
    { 

        public  Feature(byte[] bytes)
        {

        }

        public Feature()
        {

        }

        public abstract byte[] ToBytes();

        public abstract int CalculateAdditionalPrices();
    }
}
