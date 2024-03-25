using Instagram.Validations;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Instagram.UnitTests.ValidationRulesUnitTests
{
    public class DescriptionValidationRuleUnitTest
    {
        [Theory]
        [InlineData("aaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaa")]
        public void ValidationResult_ValidateNickname_ReturnTooLongDescription(string nickname)
        {
            var validationResultClass = new DescriptionValidationRule();
            var validationResult = validationResultClass.Validate(nickname, CultureInfo.DefaultThreadCurrentCulture);
            Assert.Equal(false, validationResult.IsValid);
            Assert.Equal("Description is too long! (max 100 characters)", validationResult.ErrorContent);
        }
        [Theory]
        [InlineData("aaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaa")]
        public void ValidationResult_ValidateNickname_ReturnTrue(string nickname)
        {
            var validationResultClass = new DescriptionValidationRule();
            var validationResult = validationResultClass.Validate(nickname, CultureInfo.DefaultThreadCurrentCulture);
            Assert.Equal(true, validationResult.IsValid);
        }
        [Theory]
        [InlineData("a")]
        [InlineData("aa")]
        [InlineData("aaa")]
        [InlineData("aaaa")]
        [InlineData("aaaaa")]
        public void ValidationResult_ValidateNickname_ReturnTooShortDescription(string nickname)
        {
            var validationResultClass = new DescriptionValidationRule();
            var validationResult = validationResultClass.Validate(nickname, CultureInfo.DefaultThreadCurrentCulture);
            Assert.Equal(false, validationResult.IsValid);
            Assert.Equal("Description is too short! (min 5 characters)", validationResult.ErrorContent);
        }
    }
}
