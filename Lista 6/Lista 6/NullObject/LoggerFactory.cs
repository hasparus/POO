using System;

namespace Lista_6.NullObject
{
    class LoggerFactory
    {
        LoggerFactory()
        {

        }

        public static ILogger GetLogger(LogType type, string parameters = null)
            => Instance.GetInstanceLogger(type, parameters);

        public ILogger GetInstanceLogger(LogType type, string parameters = null)
        {
            switch (type)
            {
                case LogType.None:
                    return new NoLogger();
                case LogType.Console:
                    return new ConsoleLogger();
                case LogType.File:
                    return new FileLogger(parameters);
                default:
                    throw new ArgumentOutOfRangeException(nameof(type), type, null);
            }
        }

        static LoggerFactory _instance;
        public static LoggerFactory Instance 
            => _instance ?? (_instance = new LoggerFactory());
    }
}
