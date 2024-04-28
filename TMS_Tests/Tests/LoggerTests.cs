using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TMS_Tests.Tests
{
    public class LoggerTests : BaseTest
    {
        [Test]
        public void Logger()
        {
            logger.Trace("Log Trace");
            logger.Debug("Log Debug");
            logger.Info("Log Info");
            logger.Error("Log Error");
            logger.Fatal("Log Fatal");
        }
    }
}
