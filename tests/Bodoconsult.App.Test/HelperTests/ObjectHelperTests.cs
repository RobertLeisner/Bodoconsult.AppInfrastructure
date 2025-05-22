// Copyright (c) Bodoconsult EDV-Dienstleistungen GmbH. All rights reserved.
// Licence MIT

using System.Collections;
using Bodoconsult.App.Helpers;

namespace Bodoconsult.App.Test.HelperTests
{
    [TestFixture]
    internal class ObjectHelperTests
    {
        [Test]
        [TestCaseSource(nameof(GetTestData))]
        public void TestCheckIfValuesAreEqual(object value1, object value2, bool areEqual)
        {
            // Arrange

            // Act
            var result = ObjectHelper.CheckIfValuesAreEqual(value1, value2);

            // Assert
            Assert.That(result == areEqual);
        }


        
        /// <summary>
        /// Load data directly here or load it from a ressource like a file
        /// </summary>
        /// <returns></returns>
        internal static IEnumerable GetTestData()
        {
            IList<object> data = new List<object>();

            data.Add(new TestCaseData("Test", "Test", true));
            data.Add(new TestCaseData("Test", "NoTest", false));
            data.Add(new TestCaseData((decimal)4.0, (decimal)4.0, true));
            data.Add(new TestCaseData((decimal)4.5, (decimal)4.0, false));
            data.Add(new TestCaseData((decimal)4.0, (decimal)4.5, false));

            data.Add(new TestCaseData(4.0, 4.0, true));
            data.Add(new TestCaseData(4.5, 4.0, false));
            data.Add(new TestCaseData(4.0, 4.5, false));

            data.Add(new TestCaseData(88.88, 88.88, true));
            data.Add(new TestCaseData(88.88, 99.99, false));
            data.Add(new TestCaseData(99.99, 88.88, false));

            data.Add(new TestCaseData(true, true, true));
            data.Add(new TestCaseData(false, true, false));
            data.Add(new TestCaseData(true, false, false));

            data.Add(new TestCaseData(99.88, 99.88, true));
            //data.Add(new TestCaseData((double)88.88, (double)99.99, false));
            //data.Add(new TestCaseData((double)99.99, (double)88.88, false));


            // // DateTime TestCaseData do not run for an unknown reason
            // Datetime
            //var date1 = DateTime.Now;
            //var date2 = DateTime.Now.AddDays(-5);

            //data.Add(new object[] { (DateTime)date1, (DateTime)date1, true });
            //data.Add(new TestCaseData((DateTime)date1, (DateTime)date2, false));
            //data.Add(new TestCaseData((DateTime)date2, (DateTime)date1, false));

            // Null
            data.Add(new TestCaseData(null, null, true));
            data.Add(new TestCaseData(4.5, null, false));
            data.Add(new TestCaseData(null, 4.5, false));

            data.Add(new TestCaseData(1, 1, true));
            data.Add(new TestCaseData(1, 2, false));
            data.Add(new TestCaseData(2, 1, false));

            foreach (var item in data)
            {
                yield return item;
            }
        }


        [Test]
        public void TestCheckIfValuesAreEqual_DateTime()
        {

            var date1 = DateTime.Now;
            var date2 = date1.AddDays(-5);

            // Act
            TestCheckIfValuesAreEqual(date1, date1, true);

            TestCheckIfValuesAreEqual(date2, date2, true);

            TestCheckIfValuesAreEqual(date1, date2, false);

            TestCheckIfValuesAreEqual(date2, date1, false);

        }

        //[Test]
        //public void TestJsonSerializeToFile()
        //{
        //    // Arrange
        //    var fileName = Path.Combine(FileHelper.GetOutputPath(), @"\test.json");


        //    var data = new CommonConfigSettings();

        //    if (File.Exists(fileName))
        //    {
        //        File.Delete(fileName);
        //    }

        //    Assert.IsFalse(File.Exists(fileName));

        //    // Act
        //    JsonHelper.JsonSerialize(data, fileName);

        //    // Assert
        //    Assert.IsTrue(File.Exists(fileName));

        //    var result = JsonHelper.JsonDeserialize<CommonConfigSettings>(File.ReadAllText(fileName));

        //    Assert.IsNotNull(result);
        //}


        //[Test]
        //public void TestJsonSerializeToString()
        //{
        //    // Arrange
        //    var data = new CommonConfigSettings();

        //    // Act
        //    var json = JsonHelper.JsonSerialize(data);

        //    // Assert
        //    var result = JsonHelper.JsonDeserialize<CommonConfigSettings>(json);

        //    Assert.IsNotNull(result);
        //}

        //[Test]
        //public void TestJsonSerializeNiceToFile()
        //{
        //    // Arrange
        //    var fileName = Path.Combine(FileHelper.GetOutputPath(), @"\test.json");

        //    var data = new CommonConfigSettings();

        //    if (File.Exists(fileName))
        //    {
        //        File.Delete(fileName);
        //    }

        //    Assert.IsFalse(File.Exists(fileName));

        //    // Act
        //    JsonHelper.JsonSerializeNice(data, fileName);

        //    // Assert
        //    Assert.IsTrue(File.Exists(fileName));

        //    var result = JsonHelper.JsonDeserialize<CommonConfigSettings>(File.ReadAllText(fileName));

        //    Assert.IsNotNull(result);
        //}

        //[Test]
        //public void TestJsonSerializeNiceToString()
        //{
        //    // Arrange
        //    var data = new CommonConfigSettings();

        //    // Act
        //    var json = JsonHelper.JsonSerializeNice(data);

        //    // Assert
        //    var result = JsonHelper.JsonDeserialize<CommonConfigSettings>(json);

        //    Assert.IsNotNull(result);
        //}
    }
}
