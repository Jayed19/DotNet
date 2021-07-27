using System;
using System.Data;
using System.Diagnostics;
using System.IO;
using System.Reflection;
using log4net;
using log4net.Appender;
using log4net.Config;
using log4net.Layout;
using log4net.Repository.Hierarchy;

namespace BvrsRestLibTestModule
{
    /// <summary>
    ///  A common logger for application, static configuration
    /// </summary>

    public class TLog
    {
        private static ILog log;

        // main logger name, if empty then it will use default 
        public static String LoggerName { get; set; }
        // configuration file name 
        public static String Log4NetConfFileName { get; set; }

        static TLog()
        {
            try
            {
                //log4net.GlobalContext.Properties["LogFileName"] = Process.GetCurrentProcess().Id.ToString();

                Log4NetConfFileName = "log4net.xml";
                LoggerName = "AppLog";

                // init logger here 
                ConfigLogger();

                //InitializeLog(LoggerName);

                log = LogManager.GetLogger(LoggerName ?? "");
            }
            catch (Exception ex)
            {
                //Console.WriteLine("Log4net initialization failed.");
                throw ex;
            }
        }

        private static bool InitializeLog(string LoggerName)
        {
            try
            {
                string NewFile = System.Environment.GetFolderPath(System.Environment.SpecialFolder.ApplicationData) + "\\" + Global.PATH_COMPANY + "\\Log\\" + Global.LogFileName;
                bool ret = SetLogFileName(LoggerName, NewFile);
                return ret;
            }
            catch (Exception ex) { }

            return false;


        }
        private static bool SetLogFileName(string AppenderName, string NewFilename)
        {

            //CustomMessageBox.Show("1");
            log4net.Repository.ILoggerRepository RootRep;

            //CustomMessageBox.Show("2");
            RootRep = log4net.LogManager.GetRepository();


            //CustomMessageBox.Show("3");
            foreach (log4net.Appender.IAppender iApp in RootRep.GetAppenders())
            {

                if (iApp.Name.CompareTo(AppenderName) == 0 && iApp is log4net.Appender.FileAppender)
                {

                    //CustomMessageBox.Show("4");
                    log4net.Appender.FileAppender fApp = (log4net.Appender.FileAppender)iApp;

                    //CustomMessageBox.Show("5");
                    fApp.File = NewFilename;

                    //CustomMessageBox.Show("6");
                    fApp.ActivateOptions();

                    //CustomMessageBox.Show("7");
                    return true; // Appender found and name changed to NewFilename
                }

            }
            return false; // appender not found

        }
        private static void ConfigLogger()
        {
            // N.B.: Windows CE does not support following part, 
            // It will check app.config for configuration otherwise from config file 
            if (String.IsNullOrEmpty(Log4NetConfFileName))
                log4net.Config.XmlConfigurator.Configure();
            else
            {
#if WinCE
                //Load log4net.xml to setup log4net, for WinCE read from executable path 
                String path = System.IO.Path.GetDirectoryName(Assembly.GetExecutingAssembly().GetName().CodeBase);
                   //.GetModules()[0].FullyQualifiedName) + @"\\" + Log4NetConfFileName;                
                path = System.IO.Path.Combine(path, Log4NetConfFileName);

                if (System.IO.File.Exists(path))
                {
                    // Log4NetConfFileName
                    XmlConfigurator.Configure(new System.IO.FileInfo(path));
                }
#endif
                // this for DOT NET 2.0
                XmlConfigurator.Configure(new FileInfo(Log4NetConfFileName));
            }

#if DEBUG
            LogManager.GetRepository().Threshold = log4net.Core.Level.Debug;
#else
            // set min level INFO
            LogManager.GetRepository().Threshold = log4net.Core.Level.Info;
#endif

            //((log4net.Repository.Hierarchy.Hierarchy) LogManager.GetRepository()).Root.Level = log4net.Core.Level.Info;
            ((log4net.Repository.Hierarchy.Hierarchy)LogManager.GetRepository()).RaiseConfigurationChanged(EventArgs.Empty);
        }

        public static ILog GetLogger()
        {
            if (log == null)
                log = GetLogger("");

            return log;
        }

        public static ILog GetLogger(String loggerName)
        {
            log = LogManager.GetLogger(LoggerName ?? "");
            return log;
        }

        /// <summary>
        /// Shutdown method is essential for WindowCE. Before exit the main application must call 
        /// this shutdown method 
        /// </summary>
        public static void Shutdown()
        {
            try
            {
                LogManager.Shutdown();
            }
            catch { }
        }

        public static void Debug(String msg)
        {
            log.Debug(msg);
        }

        public static void Debug(String msg, Exception ex)
        {
            log.Debug(msg, ex);
        }

        public static void Error(String msg)
        {
            log.Error(msg);
        }

        public static void Error(String msg, Exception ex)
        {
            log.Error(msg, ex);
        }

        public static void Info(String msg)
        {
            log.Info(msg);
        }

        public static void Info(String msg, Exception ex)
        {
            log.Info(msg, ex);
        }

        public static void Warn(String msg)
        {
            log.Warn(msg);
        }

        public static void Warn(String msg, Exception ex)
        {
            log.Warn(msg, ex);
        }

        #region Appender on code 

        static IAppender AddFileAppender()
        {
            var appender = new RollingFileAppender();

            appender.Name = "AppLog";
            appender.File = @"logs\hsm.log";

            appender.AppendToFile = true;
            appender.MaximumFileSize = "2MB";
            appender.MaxSizeRollBackups = 3;
            appender.RollingStyle = RollingFileAppender.RollingMode.Size;

            PatternLayout layout = new PatternLayout();
            layout.ConversionPattern = "[%d{yyyy-MM-dd HH:mm:ss}] [%-5p] %c - %m%n";
            layout.ActivateOptions();

            appender.Layout = layout;
            appender.ActivateOptions();

            return appender;
        }

        static IAppender AddDbAppender()
        {
            var appender = new AdoNetAppender();
            appender.BufferSize = 100;
            appender.ConnectionType = "System.Data.SQLite.SQLiteConnection, System.Data.SQLite, Culture=neutral";
            appender.ConnectionString = "";
            appender.CommandText =
                "INSERT INTO Log (Date, Level, Logger, Message) VALUES (@Date, @Level, @Logger, @Message)";

            appender.AddParameter(new AdoNetAppenderParameter()
            {
                ParameterName = "@Message",
                DbType = DbType.String,
                Layout = new Layout2RawLayoutAdapter(new PatternLayout("%m"))
            });

            return appender;
        }
        #endregion
    }
}
