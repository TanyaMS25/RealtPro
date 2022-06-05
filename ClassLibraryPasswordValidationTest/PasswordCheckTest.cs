using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using ClassLibraryPasswordValidation;

namespace ClassLibraryPasswordValidationTest
{
    [TestClass]
    public class PasswordCheckTest
    {
        [TestMethod]
        public void NegativePassOnlyNumbers()
        {
            string pass = "12345678";
            bool expected = false;

            bool actual = PasswordCheck.CheckPassword(pass);
            Assert.AreEqual(expected, actual);
        }
        [TestMethod]
        public void NegativePassOnlyLetters()
        {
            string pass = "aaabbbccc";

            bool actual = PasswordCheck.CheckPassword(pass);
            Assert.IsFalse(actual);
        }
        [TestMethod]
        public void NegativePassLessThan6()
        {
            string pass = "12ab";

            bool actual = PasswordCheck.CheckPassword(pass);
            Assert.IsFalse(actual);
        }
        [TestMethod]
        public void NegativePassOver50()
        {
            string pass = "1234567891234567891234567891234567891234567891234abcde";

            bool actual = PasswordCheck.CheckPassword(pass);
            Assert.IsFalse(actual);
        }
        [TestMethod]
        public void NegativePassForbiddenSymbols()
        {
            string pass = "ASDqwe1#$";

            bool actual = PasswordCheck.CheckPassword(pass);
            Assert.IsFalse(actual);
        }
        [TestMethod]
        public void PositivePassCorrect()
        {

            string pass = "ASDqwe1";
            bool expected = true;

            bool actual = PasswordCheck.CheckPassword(pass);
            Assert.AreEqual(expected, actual);
        }
    }
}
