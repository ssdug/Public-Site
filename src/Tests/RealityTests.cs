using NUnit.Framework;

namespace SSDNUG.Tests
{
    [TestFixture]
    public class RealityTests
    {
        [Test]
        public void true_should_always_be_true()
        {
            Assert.That(true, Is.True);
        }
    }
}
