using System;
using System.Reflection.Emit;
using SplashKitSDK;
using static System.Net.Mime.MediaTypeNames;

namespace MinhAnNguyen
{
    public class Student
    {
        public string GetName()
        {
            return "Minh An Nguyen - 104844794";
        }

        public static void Main()
        {
            new Window("Minh An Nguyen - 104844794", 800, 600);
            SplashKit.Delay(100000);
        }
    }
}
