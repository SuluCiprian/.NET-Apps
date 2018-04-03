using System;

namespace GraphicalApp
{
    class Program
    {
        static void Main(string[] args)
        {
            ProgramManager programManager = new ProgramManager();
            programManager.Initialize();
            programManager.RunApp();
        }
    }
}
