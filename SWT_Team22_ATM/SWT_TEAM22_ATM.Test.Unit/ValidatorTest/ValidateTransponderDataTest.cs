using NUnit.Framework;
using SWT_Team22_ATM.Domains;
using SWT_Team22_ATM.Validation;

namespace SWT_TEAM22_ATM.Test.Unit.ValidatorTest
{
    [TestFixture]
    public class ValidateTransponderDataTest
    {
        private ValidateTransponderData _uut;
        private ITrackable _airspace;

        [SetUp]
        public void TestSetUp()
        {
            _airspace = FakeAirspaceGenerator.GetAirspace(0, 0, 0);
            _uut = new ValidateTransponderData(_airspace);
        }
        
    }
}