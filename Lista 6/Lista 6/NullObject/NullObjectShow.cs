namespace Lista_6.NullObject
{
    public class NullObjectShow
    {
        public static void Do()
        {
            ILogger fileLogger = LoggerFactory.GetLogger(LogType.File,
                @"R:\Code\POO\Lista 6\Lista 6\NullObject\log.txt");
            fileLogger.Log("foo bar");

            ILogger noLogger = LoggerFactory.GetLogger(LogType.None);
            noLogger.Log("qux");
        }
    }
}