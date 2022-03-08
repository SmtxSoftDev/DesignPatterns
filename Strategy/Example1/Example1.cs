namespace Strategy.Example1
{
    /// <summary>
    /// S
    /// Open Closed Principle
    /// L
    /// I
    /// D
    /// Logger strategy interface, this is pattern closer for principle in SOLID (Open Closed Principle)
    /// </summary>
    public interface ILog
    {
        void Write(string text);
    }

    /// <summary>
    /// Concrete logger class which can write log in Text file
    /// </summary>
    public class LogToFile : ILog
    {
        public void Write(string text)
        {
            Console.WriteLine($"Text -> {text} written in text file");
        }
    }

    /// <summary>
    /// Concrete logger class which can write log in DataBase
    /// </summary>
    public class LogToDataBase : ILog
    {
        public void Write(string text)
        {
            Console.WriteLine($"Text -> {text} written in Database");
        }
    }

    /// <summary>
    /// Concrete logger class which can write log in Xml file
    /// </summary>
    public class LogToXml : ILog
    {
        public void Write(string text)
        {
            Console.WriteLine($"Text -> {text} written in Xml file");
        }
    }

    /// <summary>
    /// The logger context stores a reference to the object of a particular strategy, 
    /// working with it through the general strategy interface.
    /// </summary>
    public class LoggerContext
    {
        ILog logger;
        string text;

        public LoggerContext() { }

        public LoggerContext(ILog logger, string text)
        {
            this.logger = logger;
            this.text = text;
        }

        public void Start()
        {
            Console.WriteLine($"Starting process to logging data...");
            Console.WriteLine("Check concrete logging object...");
            
            if(logger is null)
            {
                Console.WriteLine("Logger object is not implemented!!!");
                return;
            }
            logger.Write(text);
            Console.WriteLine("Writing log is completed successfully!");
        }
    }

    /// <summary>
    /// Example class for test
    /// </summary>
    public class Example1
    {
        /// <summary>
        /// Start test
        /// </summary>
        public static void Test()
        {
            LoggerContext logToFile = new (new LogToFile(), "TestWithLogToFile!");
            LoggerContext logToDataBase = new(new LogToDataBase(), "TestWithLogToDataBase!");
            LoggerContext logToXml = new(new LogToXml(), "TestWithLogToXml!");
            LoggerContext logToWithoutLoggerObject = new();

            logToFile.Start();
            Console.WriteLine("=======================================");
            logToDataBase.Start();
            Console.WriteLine("=======================================");
            logToXml.Start();
            Console.WriteLine("=======================================");
            logToWithoutLoggerObject.Start();
            Console.WriteLine("=======================================");
        }
    }
}
