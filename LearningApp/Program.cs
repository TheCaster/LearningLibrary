using LearningLibrary.Implementation;
using LearningLibrary.Interfaces;
using System;

namespace LearningApp
{
    class Program
    {
        static int Main(string[] args)
        {
            IClass obj = new Class();
            return obj.WaitForResult().Result;
        }
    }
}
