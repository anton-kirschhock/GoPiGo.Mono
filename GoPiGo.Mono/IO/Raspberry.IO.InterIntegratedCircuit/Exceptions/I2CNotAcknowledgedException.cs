using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GoPiGo.Mono.IO.Raspberry.IO.InterIntegratedCircuit.Exceptions
{
    public class I2CNotAcknowledgedException : InvalidOperationException
    {
        public I2CNotAcknowledgedException() : base("Read operation failed with BCM2835_I2C_REASON_ERROR_NACK status")
        {
        }
    }
}
