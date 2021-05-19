using NUnit.Framework;

namespace NUnitTest
{
    /// <summary>
    /// The default test suite with test cases
    /// </summary>
    [TestFixture]
    public class DefaultTestSuite
    {
        /// <summary>
        /// The test case #1
        /// </summary>
        [Test]
        public void TestCase1()
        {
        }

        /// <summary>
        /// The test case #2
        /// </summary>
        [Test]
        public void TestCase2()
        {
        }
    }

    /// <summary>
    /// The test suite with "before" and "after" test cases
    /// </summary>
    [TestFixture]
    public class TestSuite1
    {
        /// <summary>
        /// The test case executed before running all tests from the whole TestSuite1 class
        /// </summary>
        [SetUp]
        public void BeforeTest()
        {
        }

        /// <summary>
        /// The test case executed after running all test from the whole TestSuite1 class
        /// </summary>
        [TearDown]
        public void AfterTest()
        {
        }
    }

    /// <summary>
    /// The main test suite with "before" and "after" test cases
    /// </summary>
    [SetUpFixture]
    public class SetUpClass
    {
        /// <summary>
        /// The test case executed before running all test suites
        /// </summary>
        [SetUp]
        public void RunBeforeAllTests()
        {
        }

        /// <summary>
        /// The test case executed after running all test suites
        /// </summary>
        [TearDown]
        public void RunAfterAllTests()
        {
        }
    }
}