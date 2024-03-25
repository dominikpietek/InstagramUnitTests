using Instagram.Validations;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Instagram.UnitTests.ValidationRulesUnitTests
{
    public class NameValidationRuleUnitTest
    {
        [Theory]
        [InlineData("ProBoszcz")]
        [InlineData("1234")]
        [InlineData("aaa")]
        [InlineData("aaaaaaaaaaaaaa")]
        public void ValidationResult_ValidateName_ReturnTrue(string name)
        {
            var validationResultClass = new NameValidationRule();
            var validationResult = validationResultClass.Validate(name, CultureInfo.DefaultThreadCurrentCulture);
            Assert.Equal(true, validationResult.IsValid);
        }
        [Theory]
        [InlineData("aaaaaaaaaaaaaaaa")]
        public void ValidationResult_ValidateName_ReturnTooLongName(string name)
        {
            var validationResultClass = new NameValidationRule();
            var validationResult = validationResultClass.Validate(name, CultureInfo.DefaultThreadCurrentCulture);
            Assert.Equal(false, validationResult.IsValid);
            Assert.Equal("Name is too long!", validationResult.ErrorContent);
        }
        [Theory]
        [InlineData("1")]
        [InlineData("12")]
        public void ValidationResult_ValidateName_ReturnTooShortName(string name)
        {
            var validationResultClass = new NameValidationRule();
            var validationResult = validationResultClass.Validate(name, CultureInfo.DefaultThreadCurrentCulture);
            Assert.Equal(false, validationResult.IsValid);
            Assert.Equal("Name is too short!", validationResult.ErrorContent);
        }
        [Theory]
        [InlineData("a$ap")]
        [InlineData("pr8bl%m")]
        [InlineData("email@wp.pl")]
        public void ValidationResult_ValidateNickname_ReturnNicknameCantContainSpecialCharacters(string nickname)
        {
            var validationResultClass = new NameValidationRule();
            var validationResult = validationResultClass.Validate(nickname, CultureInfo.DefaultThreadCurrentCulture);
            Assert.Equal(false, validationResult.IsValid);
            Assert.Equal("Name can't contain special characters!", validationResult.ErrorContent);
        }
    }
}
