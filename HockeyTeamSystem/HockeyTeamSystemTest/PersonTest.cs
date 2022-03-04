using Microsoft.VisualStudio.TestTools.UnitTesting;
using HockeyTeamSystem; //Menually add
using System;

namespace HockeyTeamSystemTest
{
    [TestClass]
    public class PersonTest
    {
        [TestMethod]
        [DataRow("Connor McDavid")]  //DataRow provide test data to Test method
        [DataRow("Ryan Nugent-Hopkins")]
        public void FullName_VaildValue_NoErrors(string fullName)
        {
            Person person1 = new Person(fullName);
            Assert.AreEqual(fullName, person1.FullName);
        }
        [TestMethod]
        [DataRow(null)] //null
        [DataRow("")] //empty
        [DataRow("   \n\t")] //whitespace
        public void FullName_NoName_ThrowException(string fullname)
        {
            ArgumentNullException exception = Assert.ThrowsException<ArgumentNullException>(() => {
                Person person1 = new Person(fullname);
            });
            Assert.IsNotNull(exception);
            //Assert.AreEqual("FullName", exception.ParamName);
            //Assert.IsTrue(exception.Message.Contains("FullName is required.")); 
            // 前后一致的意思，前内容与Person中Throw
            // Exception 内容一致， 举例见下乘法
            // Assert.AreEqual(8, 2 * 4);
            Assert.AreEqual("Person FullName is required", exception.ParamName);
        }
        [TestMethod]
        [DataRow("A")]
        [DataRow("AB")]
        [DataRow("A B")]
        public void FullName_InvalidNameLength_ThrowException(string fullname)
        {
            ArgumentException exception = Assert.ThrowsException<ArgumentException>(() =>
            {
                Person person1 = new Person(fullname);
            });
            Assert.IsNotNull(exception);
            Assert.AreEqual("Person FullName must contain at least 5 characters.", exception.Message);

        }
    }
}