using GoPiGo;
using Raspberry.IO.GeneralPurpose;
using Raspberry.IO.InterIntegratedCircuit;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace RunMotor
{
    class Program
    {
        static void Main(string[] args)
        {
            var factory = DeviceFactory.Factory;
            using (var gopigo = factory.BuildGoPiGo())
            {
                var ultrasonic = factory.BuildUltraSonicSensor(Pin.Analog1);
                //var l1 = factory.BuildLed(Pin.LedLeft);
                //var l2 = factory.BuildLed(Pin.LedRight);
                //l1.ChangeState(GoPiGo.Sensors.SensorStatus.On);
                //l2.ChangeState(GoPiGo.Sensors.SensorStatus.On);
                //Thread.Sleep(2500);

                //l1.ChangeState(GoPiGo.Sensors.SensorStatus.Off);
                //l2.ChangeState(GoPiGo.Sensors.SensorStatus.Off);

                Console.WriteLine($"Dist: {ultrasonic.MeasureInCentimeters()}cm");
                Thread.Sleep(2500);

                gopigo.MotorController().MoveForward();
                Thread.Sleep(2500);

                gopigo.MotorController().MoveBackward();
                Thread.Sleep(2500);

                gopigo.MotorController().Stop();
                Thread.Sleep(2500);

                gopigo.MotorController().RotateLeft();
                Thread.Sleep(2500);

                gopigo.MotorController().RotateRight();
                Thread.Sleep(2500);

                gopigo.MotorController().MoveLeft();
                Thread.Sleep(2500);

                gopigo.MotorController().MoveRight();
                Thread.Sleep(2500);

                gopigo.MotorController().Stop();
            }
        }
    }
}
