using System;
using System.Reflection;
using Intelligencia.UrlRewriter.Logging;
using log4net;

namespace Rewrite.Test
{
    /// <summary>
    /// Wrapper class for the UrlRewriters Logging Interface, to write logs into log4net.
    /// </summary>
    public class Log4NetRewriteLogger : IRewriteLogger
    {
        private static readonly ILog log = LogManager.GetLogger(MethodBase.GetCurrentMethod().DeclaringType);


        ///<summary>
        ///
        ///            Writes a debug message.
        ///            
        ///</summary>
        ///
        ///<param name="message">The message to write.</param>
        public void Debug(object message)
        {
            log.Debug(message);
        }

        ///<summary>
        ///
        ///            Writes an informational message.
        ///            
        ///</summary>
        ///
        ///<param name="message">The message to write.</param>
        public void Info(object message)
        {
            log.Info(message);
        }

        ///<summary>
        ///
        ///            Writes a warning message.
        ///            
        ///</summary>
        ///
        ///<param name="message">The message to write.</param>
        public void Warn(object message)
        {
            log.Warn(message);
        }

        ///<summary>
        ///
        ///            Writes an error.
        ///            
        ///</summary>
        ///
        ///<param name="message">The message to write.</param>
        public void Error(object message)
        {
            log.Error(message);
        }

        ///<summary>
        ///
        ///            Writes an error.
        ///            
        ///</summary>
        ///
        ///<param name="message">The message to write.</param>
        ///<param name="exception">The exception</param>
        public void Error(object message, Exception exception)
        {
            log.Error(message, exception);
        }

        ///<summary>
        ///
        ///            Writes a fatal error.
        ///            
        ///</summary>
        ///
        ///<param name="message">The message to write.</param>
        ///<param name="exception">The exception</param>
        public void Fatal(object message, Exception exception)
        {
            log.Fatal(message, exception);
        }
    }
}