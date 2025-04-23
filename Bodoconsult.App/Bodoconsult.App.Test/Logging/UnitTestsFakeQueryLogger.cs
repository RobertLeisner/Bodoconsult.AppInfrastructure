// Copyright (c) Bodoconsult EDV-Dienstleistungen GmbH. All rights reserved.

//using Microsoft.Extensions.Logging;
//using NUnit.Framework;

//namespace XXX.Tests.Logging
//{
//    [TestFixture]
//    internal class UnitTestsFakeAppLogger: BaseFakeLoggerTests
//    {

//        [SetUp]
//        public void Setup()
//        {
//            LoggedMessages.Clear();
//        }


//        [Test]
//        public void TestCreateLogger()
//        {
//            // Arrange 
//            var query = new FakeAppLoggerFactory
//            {
//                FakeLogDelegate = FakeLogDelegate
//            };

//            // Act
//            Assert.That(query);

//            var factory = query.Create();

//            Assert.That(factory);

//            var fake = (FakeLogger)factory.CreateLogger("TestCategrory");

//            Assert.That(fake);
           
//            logger = fake;
//            logger.Log(LogLevel.Critical, "Hallo");

//            // Assert
//            Assert.That(LoggedMessages.Count == 1);

//        }
//    }
//}