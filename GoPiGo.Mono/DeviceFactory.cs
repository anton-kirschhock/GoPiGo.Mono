using System;
using System.Threading.Tasks;

using GoPiGo.Sensors;

namespace GoPiGo
{
    public static class DeviceFactory
    {
        public static IBuildGoPiGoDevices Factory { get; } = new DeviceBuilder();
    }

    public interface IBuildGoPiGoDevices
    {
        IGoPiGo BuildGoPiGo();
        ILed BuildLed(Pin pin);
        IUltrasonicRangerSensor BuildUltraSonicSensor(Pin pin);
    }

    internal class DeviceBuilder : IBuildGoPiGoDevices
    {
        private GoPiGo _device;

        public ILed BuildLed(Pin pin)
        {
            return DoBuild(x => new Led(x, pin));
        }

        public IUltrasonicRangerSensor BuildUltraSonicSensor(Pin pin)
        {
            return DoBuild(x => new UltrasonicRangerSensor(x, pin));
        }

        private TSensor DoBuild<TSensor>(Func<GoPiGo, TSensor> factory)
        {
            return factory(_device);
        }

        public IGoPiGo BuildGoPiGo()
        {
            if (_device == null)
            {
                _device = new GoPiGo();
            }
            return _device;

        }
    }
}
