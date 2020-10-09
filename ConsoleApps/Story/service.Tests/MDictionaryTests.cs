using NUnit.Framework;
using Service.Util;

namespace service.Tests
{
    [TestFixture]
    public class MDictionaryTests
    {

        [Test]
        public void testMDictionariesEqual_SameOrder()
        {
            // Data setup
            MDictionary<string, string> actual = new MDictionary<string, string>();
            actual.Add("1", "start");
            actual.Add("2", "start");
                        
            // Expectations
            MDictionary<string, string> expected = new MDictionary<string, string>();
            expected.Add("1", "start");
            expected.Add("2", "start");

            // Test and Assert
            Assert.AreEqual(actual, expected);
        }

        [Test]
        public void testMDictionariesEqual_differentOrder()
        {
            // Data setup
            MDictionary<string, string> actual = new MDictionary<string, string>();
            actual.Add("1", "start");
            actual.Add("2", "node1");
                        
            // Expectations
            MDictionary<string, string> expected = new MDictionary<string, string>();
            expected.Add("2", "node1");
            expected.Add("1", "start");

            // Test and Assert
            Assert.AreEqual(actual, expected);
        }

        [Test]
        public void testMDictionariesNotEqual_differentNumberOfElements()
        {
            // Data setup
            MDictionary<string, string> actual = new MDictionary<string, string>();
            actual.Add("1", "start");
            actual.Add("2", "node1");
                        
            // Expectations
            MDictionary<string, string> expected = new MDictionary<string, string>();
            expected.Add("2", "node1");
            expected.Add("1", "start");
            expected.Add("3", "node2");

            // Test and Assert
            Assert.IsFalse(actual.Equals(expected));
        }

        [Test]
        public void testMDictionariesNotEqual_differentValues()
        {
            // Data setup
            MDictionary<string, string> actual = new MDictionary<string, string>();
            actual.Add("1", "start");
            actual.Add("2", "node1");
                        
            // Expectations
            MDictionary<string, string> expected = new MDictionary<string, string>();
            expected.Add("1", "node1");
            expected.Add("2", "node2");

            // Test and Assert
            Assert.IsFalse(actual.Equals(expected));
        }
    }
}