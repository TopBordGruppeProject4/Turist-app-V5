using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TursitAppV4.Model;
using Microsoft.VisualStudio.TestPlatform.UnitTestFramework;
using Tursit_app_V5.model;

namespace TursitAppV4.Model.Tests
{
    [TestClass()]
    public class FileHandlerTests
    {
        ObservableCollection<User> _userlist = new ObservableCollection<User>();
        User testUser = new User("Test", "Mand", "1234", DateTimeOffset.Parse("01/01/1993"), 0, "Single");

        [TestMethod()]
        public async void SaveTest()
        {
            _userlist.Add(testUser);
            FileHandler.Save(_userlist);

            var filedata = await FileHandler.Load();

            Assert.IsNotNull(filedata);
        }

        [TestMethod()]
        public async void LoadTest()
        {
            var filedata = await FileHandler.Load();
            Assert.IsNotNull(filedata);
        }
    }
}
