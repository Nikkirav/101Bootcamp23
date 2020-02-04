using System;
using LibraryCommon;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace LibraryUnitTest
{
    [TestClass]
    public class HashingUnitTest
    {
        [TestMethod]
        public void Additive_Input_foo_Output_324()
        {

            //  arrange
            Hashing hashing = new Hashing();
            string _expected = "324";

            // act
            string _actual = hashing.AdditiveHash("foo");

            // assert
            Assert.AreEqual(_expected, _actual);
        }

        [TestMethod]
        public void Additive_Input_ofo_Output_324()
        {

            //  arrange
            Hashing hashing = new Hashing();
            string _expected = "324";

            // act
            string _actual = hashing.AdditiveHash("ofo");

            // assert
            Assert.AreEqual(_expected, _actual);
        }


        [TestMethod]
        public void Additive_Input_foo_Output_Not_100()
        {

            //  arrange
            Hashing hashing = new Hashing();
            string _expected = "100";

            // act
            string _actual = hashing.AdditiveHash("foo");

            // assert
            Assert.AreNotEqual(_expected, _actual);
        }


        [TestMethod]
        public void NoHashing_Input_foo_Output_foo()
        {

            //  arrange
            Hashing hashing = new Hashing();
            string _expected = "foo";

            // act
            string _actual = hashing.NoHashing("foo");

            // assert
            Assert.AreEqual(_expected, _actual);
        }


        [TestMethod]
        public void SHA256NoSalt_Input_password123_Output_ef92b778bafe771e89245b89ecbc08a44a4e166c06659911881f383d4473e94f()
        {
            //  arrange
            Hashing hashing = new Hashing();

            // ef92b778bafe771e89245b89ecbc08a44a4e166c06659911881f383d4473e94f
            string _expected = "ef92b778bafe771e89245b89ecbc08a44a4e166c06659911881f383d4473e94f";

            // act
            string _actual = hashing.SHA256HashNotSalted("password123");

            // assert
            Assert.AreEqual(_expected, _actual);

        }


        [TestMethod]
        public void SHA256WithSalt_Input_password123_Output_CrazyString()
        {

            //  arrange
            Hashing hashing = new Hashing();

            // 2/4/2020 1:21:46 PM
            // 0<éP_}ò,,~Rga¥ÿ9tUxyÉ>xOd*±~[S
            string _expected = "0‹éPÞ}ò„‚~Rga¥ÿ9tMÙ×yÉ>×Oð*±˜[S";

            // act
            string _actual = hashing.SHA256HashWithSalt("password123", "2/4/2020 1:21:46 PM");

            // assert
            Assert.AreEqual(_expected, _actual);

        }


    }
}
