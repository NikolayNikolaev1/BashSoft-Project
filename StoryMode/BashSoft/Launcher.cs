﻿using System;

namespace BashSoft
{
    class Launcher
    {
        static void Main(string[] args)
        {
            IOManager.TraverseDirectory(@"C:\Users\user\Source\Repos");
        }
    }
}
