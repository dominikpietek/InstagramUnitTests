using Instagram.SendingEmails;
using Instagram.Validations;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Instagram.UnitTests.ValidationRulesUnitTests
{
    public class NicknameValidationRuleUnitTest
    {
        [Theory]
        [InlineData("ProBoszcz")]
        [InlineData("1234")]
        [InlineData("aaa")]
        [InlineData("aaaaaaaaaaaaaa")]
        public void ValidationResult_ValidateNickname_ReturnTrue(string nickname)
        {
            var validationResultClass = new NicknameValidationRule();
            var validationResult = validationResultClass.Validate(nickname, CultureInfo.DefaultThreadCurrentCulture);
            Assert.Equal(true, validationResult.IsValid);
        }
        [Theory]
        [InlineData("aaaaaaaaaaaaaaaa")]
        public void ValidationResult_ValidateNickname_ReturnTooLongNickname(string nickname)
        {
            var validationResultClass = new NicknameValidationRule();
            var validationResult = validationResultClass.Validate(nickname, CultureInfo.DefaultThreadCurrentCulture);
            Assert.Equal(false, validationResult.IsValid);
            Assert.Equal("Nickname is too long!", validationResult.ErrorContent);
        }
        [Theory]
        [InlineData("1")]
        [InlineData("12")]
        public void ValidationResult_ValidateNickname_ReturnTooShortNickname(string nickname)
        {
            var validationResultClass = new NicknameValidationRule();
            var validationResult = validationResultClass.Validate(nickname, CultureInfo.DefaultThreadCurrentCulture);
            Assert.Equal(false, validationResult.IsValid);
            Assert.Equal("Nickname is too short!", validationResult.ErrorContent);
        }
        [Theory]
        [InlineData("a$ap")]
        [InlineData("pr8bl%m")]
        [InlineData("email@wp.pl")]
        public void ValidationResult_ValidateNickname_ReturnNicknameCantContainSpecialCharacters(string nickname)
        {
            var validationResultClass = new NicknameValidationRule();
            var validationResult = validationResultClass.Validate(nickname, CultureInfo.DefaultThreadCurrentCulture);
            Assert.Equal(false, validationResult.IsValid);
            Assert.Equal("Nickname can't contain special characters!", validationResult.ErrorContent);
        }
    }
}
