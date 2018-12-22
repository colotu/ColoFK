using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using Maticsoft.Payment.Core;

namespace TestProject
{


    /// <summary>
    ///这是 GlobalsTest 的测试类，旨在
    ///包含所有 GlobalsTest 单元测试
    ///</summary>
    [TestClass()]
    public class GlobalsTest
    {


        private TestContext testContextInstance;

        /// <summary>
        ///获取或设置测试上下文，上下文提供
        ///有关当前测试运行及其功能的信息。
        ///</summary>
        public TestContext TestContext
        {
            get
            {
                return testContextInstance;
            }
            set
            {
                testContextInstance = value;
            }
        }

        #region 附加测试特性
        // 
        //编写测试时，还可使用以下特性:
        //
        //使用 ClassInitialize 在运行类中的第一个测试前先运行代码
        //[ClassInitialize()]
        //public static void MyClassInitialize(TestContext testContext)
        //{
        //}
        //
        //使用 ClassCleanup 在运行完类中的所有测试后再运行代码
        //[ClassCleanup()]
        //public static void MyClassCleanup()
        //{
        //}
        //
        //使用 TestInitialize 在运行每个测试前先运行代码
        //[TestInitialize()]
        //public void MyTestInitialize()
        //{
        //}
        //
        //使用 TestCleanup 在运行完每个测试后运行代码
        //[TestCleanup()]
        //public void MyTestCleanup()
        //{
        //}
        //
        #endregion


        /// <summary>
        ///GetTopLevelDomain 的测试
        ///</summary>
        [TestMethod()]
        public void GetTopLevelDomainTest()
        {
            string domain = "192.168.1.25:8050";
            string expected = "192.168.1.25"; // TODO: 初始化为适当的值
            string actual;
            //actual = Globals.GetTopLevelDomain(domain);
            //Assert.AreEqual(expected, actual);
        }

        /// <summary>
        ///EncodeData4Url 的测试
        ///</summary>
        [TestMethod()]
        public void EncodeData4UrlTest()
        {
            string normalString = "http://shop1.maticsoft.com/Download/201401151524527220.stl"; // TODO: 初始化为适当的值
            string expected = string.Empty; // TODO: 初始化为适当的值
            string actual;
            actual = Maticsoft.Common.DEncrypt.Base64.Encode(normalString);
            expected = Maticsoft.Common.DEncrypt.Base64.Decode(actual);
            Assert.AreEqual(expected, normalString);
            Assert.Inconclusive("验证此测试方法的正确性。");
        }

        /// <summary>
        ///DecodeData4Url 的测试
        ///</summary>
        [TestMethod()]
        public void DecodeData4UrlTest()
        {
            string base64String = string.Empty; // TODO: 初始化为适当的值
            string expected = string.Empty; // TODO: 初始化为适当的值
            string actual;
            actual = Globals.DecodeData4Url(base64String);
            Assert.AreEqual(expected, actual);
            Assert.Inconclusive("验证此测试方法的正确性。");
        }
    }
}
