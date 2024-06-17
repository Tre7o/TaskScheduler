using log4net;
using log4net.Appender;
using log4net.Config;
using log4net.Core;
using log4net.Layout;

namespace TaskScheduler.log4net
{
    public class TestLogger
    {
        private static TestLogger instance; // instance of TestLogger
        private static ILog logger; // instance of ILog

        // private so that no other objects can instantiate the class thru constructor
        private TestLogger()
        {
            // Step 4 Get intsance of the logger
            logger = LogManager.GetLogger(typeof(TestLogger));
        }

        // retruning instance of TestLogger
        public static TestLogger GetInstance()
        {
            if (instance == null)
            {
                instance = new TestLogger();
            }
            return instance;
        }

        // method to perform logging
        public ILog TestLog4Net()
        {
            // Step 1. Create the layout
            var patternLayout = new PatternLayout();
            patternLayout.ConversionPattern = "%m%n"; // defines the format of the messages
            patternLayout.ActivateOptions();

            // Step 2. Use this layout in the appender
            // creating console appender
            var consoleAppender = new ConsoleAppender()
            {
                Name = "consoleAppender",
                Layout = patternLayout,
                Threshold = Level.All
            };

            consoleAppender.ActivateOptions();

            var fileAppender = new FileAppender()
            {

                Name = "fileAppender",
                File = @"C:\Users\John Suubi\AnotherTaskScheduler\log4net\logs.txt",
                AppendToFile = true,
                Layout = patternLayout,
                Threshold = Level.All
            };

            fileAppender.ActivateOptions();

            // Step 3. Initialize the configuration
            BasicConfigurator.Configure(consoleAppender);
            //XmlConfigurator.Configure();

            // ILog logger = LogManager.GetLogger(typeof(TestLogger));

            /* logger.Debug("This is Debug information");
            logger.Info("This is Info information");
            logger.Error("This is Error information");
            logger.Fatal("This is Fatal information");
            logger.Warn("This is Warn information"); */

            return logger;
        }
    }
}
