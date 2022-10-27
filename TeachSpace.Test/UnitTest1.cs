using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using TeachSpace.Web.Controllers;
using System.Web.Http;

namespace TeachSpace.UnitTest
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void TestGetUsersEmail()
        {
            var controller = new ScheduleController();
            var getuseremail = controller.GetUsersEmail();
            Assert.IsNotNull(getuseremail);
        }


        [TestMethod]
        public void TestGetTopicName()
        {
            var controller = new ScheduleController();
            var gettopicname = controller.GetTopicName();
            Assert.IsNotNull(gettopicname);
        }

        [TestMethod]
        public void TestGetSchedule()
        {
            var controller = new ScheduleController();
            var getschedule = controller.GetTopicName();
            Assert.IsNotNull(getschedule);
        }

    }
}
