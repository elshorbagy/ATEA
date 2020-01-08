using Atea.Framework.Model;
using System;

namespace AteaConsole
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            var repository = DependencyBuild.GetRepository(args[0]);
            repository.ReadResult += ReadResult;
            repository.Create(1, "New Message");
            repository.Read(1);
            repository.Update(1, "Update Message");
            repository.Delete(1);
            Console.ReadKey();
        }

        private static void ReadResult(object sender, ResultArgs eventArgs)
                            =>Console.WriteLine(eventArgs.Result);        
    }
}