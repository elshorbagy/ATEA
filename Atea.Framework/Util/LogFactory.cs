using Microsoft.Extensions.Logging;

namespace Atea.Framework.Util
{
    static class LogFactory
    {
        public static ILogger Create()
        {
            var loggerFactory = new LoggerFactory();

            return loggerFactory.CreateLogger<IRepository>();
        }
    }
}
