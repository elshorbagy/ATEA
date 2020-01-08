using System;
using Atea.Framework;
using Microsoft.Extensions.DependencyInjection;

namespace AteaConsole
{
    static class DependencyBuild
    {
        public static IRepository GetRepository(string file)
        {
            var serviceProvider = new ServiceCollection();
            
            //Repository is a file
            if (!string.IsNullOrEmpty(file))
                serviceProvider.AddScoped<IRepository>(_ => new FileRepository(file));
            else
                throw new Exception("Repository is not implemented");
                            
            var services = serviceProvider.BuildServiceProvider();

            var repository = services
                .GetService<IRepository>();

            return repository;
        }

    }
}
