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
                var led1 = factory.BuildLed(Pin.LedLeft);
                var led2 = factory.BuildLed(Pin.LedRight);
                led1.ChangeState(GoPiGo.Sensors.SensorStatus.On);
                Thread.Sleep(20);
                led2.ChangeState(GoPiGo.Sensors.SensorStatus.On);
                Thread.Sleep(1500);
                led1.ChangeState(GoPiGo.Sensors.SensorStatus.Off);
                Thread.Sleep(20);
                led2.ChangeState(GoPiGo.Sensors.SensorStatus.Off);
                
                DateTime dtStart = DateTime.Now;
                var ultrasonic = factory.BuildUltraSonicSensor(Pin.Analog1);
                gopigo.MotorController().EnableServo();
                gopigo.MotorController().RotateServo(90);
                gopigo.MotorController().DisableServo();
                while ((DateTime.Now - dtStart).TotalMinutes < 5)
                {
                    Console.WriteLine("battery: " + gopigo.BatteryVoltage());
                    gopigo.MotorController().Stop();
                    gopigo.MotorController().MoveForward();
                    Thread.Sleep(50);
                    var d = ultrasonic.MeasureInCentimeters();
                    while (d > 30)
                    {
                        Thread.Sleep(500);
                        d = ultrasonic.MeasureInCentimeters();
                        Console.WriteLine($"Driving forward with {d} cm of space");


                    }
                    gopigo.MotorController().Stop();
                    
                    while (d < 30)
                    {
                        led1.ChangeState(GoPiGo.Sensors.SensorStatus.On);
                        gopigo.MotorController().RotateLeft();
                        Thread.Sleep(250);
                        gopigo.MotorController().Stop();
                        led1.ChangeState(GoPiGo.Sensors.SensorStatus.Off);
                        Thread.Sleep(500);
                        d = ultrasonic.MeasureInCentimeters();
                        Thread.Sleep(10);
                    }
                }
            }

        }
    }

}
/*
                 var ultrasonic = factory.BuildUltraSonicSensor(Pin.Analog1);
                var l1 = factory.BuildLed(Pin.LedLeft);
                var l2 = factory.BuildLed(Pin.LedRight);
                Thread.Sleep(2500);
                l1.ChangeState(GoPiGo.Sensors.SensorStatus.On);
                l2.ChangeState(GoPiGo.Sensors.SensorStatus.On);
                Thread.Sleep(2500);

                l1.ChangeState(GoPiGo.Sensors.SensorStatus.Off);
                l2.ChangeState(GoPiGo.Sensors.SensorStatus.Off);
                gopigo.MotorController().EnableServo();
                for (int i = 0; i < 180; i++)
                {
                    gopigo.MotorController().RotateServo(i);
                }
                gopigo.MotorController().DisableServo();
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
     */
