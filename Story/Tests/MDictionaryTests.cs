using NUnit.Framework;
using System.Collections.Generic;
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
                        
            // Expectations
            MDictionary<string, string> dict1 = new MDictionary<string, string>();
            dict1.Add("1", "start");
            dict1.Add("2", "start");

            MDictionary<string, string> dict2 = new MDictionary<string, string>();
            dict2.Add("1", "start");
            dict2.Add("2", "start");

            // Test and Assert
            Assert.AreEqual(dict1, dict2);
        }

        [Test]
        public void testMDictionariesEqual_differentOrder()
        {
            // Data setup
                        
            // Expectations
            MDictionary<string, string> dict1 = new MDictionary<string, string>();
            dict1.Add("1", "start");
            dict1.Add("2", "node1");

            MDictionary<string, string> dict2 = new MDictionary<string, string>();
            dict2.Add("2", "node1");
            dict2.Add("1", "start");

            // Test and Assert
            Assert.AreEqual(dict1, dict2);
        }

        [Test]
        public void testMDictionariesNotEqual_differentNumberOfElements()
        {
            // Data setup
                        
            // Expectations
            MDictionary<string, string> dict1 = new MDictionary<string, string>();
            dict1.Add("1", "start");
            dict1.Add("2", "node1");

            MDictionary<string, string> dict2 = new MDictionary<string, string>();
            dict2.Add("2", "node1");
            dict2.Add("1", "start");
            dict2.Add("3", "node2");

            // Test and Assert
            Assert.IsFalse(dict1.Equals(dict2));
        }
    }
}