using log4net;
using log4net.Config;
using System.IO;
using System.Reflection;

public static class LogHelper
{
    public static readonly ILog Logger = LogManager.GetLogger(typeof(LogHelper));

    static LogHelper()
    {
        var logRepository = LogManager.GetRepository(Assembly.GetEntryAssembly());
        XmlConfigurator.Configure(logRepository, new FileInfo("log4net.config"));
    }
}
