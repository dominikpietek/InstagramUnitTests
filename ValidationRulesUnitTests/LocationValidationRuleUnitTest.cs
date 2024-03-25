using Instagram.Validations;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Instagram.UnitTests.ValidationRulesUnitTests
{
    public class LocationValidationRuleUnitTest
    {
        [Theory]
        [InlineData("New york")]
        [InlineData("Warsaw")]
        [InlineData("Dublin")]
        [InlineData("London")]
        [InlineData("Nowhere")]
        public void ValidationResult_ValidateLocation_ReturnTrue(string location)
        {
            var validationResultClass = new LocationValidationRule();
            var validationResult = validationResultClass.Validate(location, CultureInfo.DefaultThreadCurrentCulture);
            Assert.Equal(true, validationResult.IsValid);
        }
        [Theory]
        [InlineData("aaaaaaaaaaaaaaaaaaaaa")]
        public void ValidationResult_ValidateLocation_ReturnTooLongLocation(string location)
        {
            var validationResultClass = new LocationValidationRule();
            var validationResult = validationResultClass.Validate(location, CultureInfo.DefaultThreadCurrentCulture);
            Assert.Equal(false, validationResult.IsValid);
            Assert.Equal("Location is too long!", validationResult.ErrorContent);
        }
        [Theory]
        [InlineData("1")]
        [InlineData("a")]
        public void ValidationResult_ValidateLocation_ReturnTooShortLocation(string location)
        {
            var validationResultClass = new LocationValidationRule();
            var validationResult = validationResultClass.Validate(location, CultureInfo.DefaultThreadCurrentCulture);
            Assert.Equal(false, validationResult.IsValid);
            Assert.Equal("Location is too short!", validationResult.ErrorContent);
        }
    }
}
