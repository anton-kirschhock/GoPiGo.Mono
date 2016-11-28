#Timing#

Due to the architecture of I2C, it is important to find a perfect timing between I2C commands.

After a long search, why some commands fail, I found out that there should be at least a 7ms Thread.Sleep to give the GoPiGo the time to execute the command.

It is suggested that you use even a 8ms between commands!

*To view where you have to this manualy, see the readme files of these methods!*