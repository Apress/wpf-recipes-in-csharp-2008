﻿using System;

namespace Recipe_01_14
{
    public class MyApp
    {
        [STAThread]
        public static void Main(string[] args)
        {
            //Create our new single instance manager
            SingleInstanceManager manager = new SingleInstanceManager();
            manager.Run(args);
        }
    }
}
