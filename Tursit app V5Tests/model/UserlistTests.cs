using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tursit_app_V5.model;
using Microsoft.VisualStudio.TestPlatform.UnitTestFramework;
namespace Tursit_app_V5.model.Tests
{
    [TestClass()]
    public class UserlistTests
    {
        private Userlist userlist = Userlist.UserlistInstance;
        private User testUser = new User("Test", "Mand", "1234", DateTimeOffset.Parse("01/01/1993"), 0, "Single");

        [TestMethod()]
        public void CheckTest()
        {
            userlist.ListOfUsers.Add(testUser);
            bool checkstatus = userlist.Check("Test", "1234");
            Assert.IsTrue(checkstatus);
        }

        [TestMethod()]
        public void CheckTest2()
        {
            userlist.ListOfUsers.Add(testUser);
            bool checkstatus = userlist.Check("Test", "12345");
            Assert.IsFalse(checkstatus);
        }

        [TestMethod()]
        public void CheckTest3()
        {
            userlist.ListOfUsers.Add(testUser);
            bool checkstatus = userlist.Check("Test", "123");
            Assert.IsFalse(checkstatus);
        }

        [TestMethod()]
        public void CheckTest4()
        {
            userlist.ListOfUsers.Add(testUser);
            bool checkstatus = userlist.Check("Teste", "1234");
            Assert.IsFalse(checkstatus);
        }

        [TestMethod()]
        public void CheckTest5()
        {
            userlist.ListOfUsers.Add(testUser);
            bool checkstatus = userlist.Check("Tes", "1234");
            Assert.IsFalse(checkstatus);
        }
    }
}
