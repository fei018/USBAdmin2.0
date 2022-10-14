using System;
using System.IO;
using System.Linq;

namespace SetupClient
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                //if (args.Count() > 0)
                //{
                //    if (args[0].ToLower() == "uninstall")
                //    {
                //        UnSetup();
                //    }
                //}
                //else
                //{
                //    Setup();
                //}

                SetupRegistryKey.InitialRegistryKey();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        static void Setup()
        {
            try
            {
                Console.WriteLine("Setup Start ...");
                Console.WriteLine();

                new SetupHelp().Setup();

                Console.WriteLine("Setup Done !!!");
                LogHelp.Log("Setup done.");
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);

                LogHelp.Log(ex.Message);
            }
        }

        static void UnSetup()
        {
            try
            {
                Console.WriteLine("UnSetup Start ...");

                new SetupHelp().UnSetup();

                Console.WriteLine("UnSetup Done !!!");
                LogHelp.Log("UnSetup done.");
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);

                LogHelp.Log(ex.Message);
            }
        }
    }
}
