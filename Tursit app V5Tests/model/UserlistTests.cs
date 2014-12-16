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
    }
}
