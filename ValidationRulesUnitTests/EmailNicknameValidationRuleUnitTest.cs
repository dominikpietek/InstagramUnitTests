using Instagram.Validations;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Instagram.UnitTests.ValidationRulesUnitTests
{
    public class EmailNicknameValidationRuleUnitTest
    {
        [Theory]
        [InlineData("ProBoszcz")]
        [InlineData("1234")]
        [InlineData("aaa")]
        [InlineData("aaaaaaaaaaaaaa")]
        public void ValidationResult_ValidateEmailNickname_ReturnTrue(string emailNickname)
        {
            var validationResultClass = new EmailNicknameValidationRule();
            var validationResult = validationResultClass.Validate(emailNickname, CultureInfo.DefaultThreadCurrentCulture);
            Assert.Equal(true, validationResult.IsValid);
        }
        [Theory]
        [InlineData("aaaaaaaaaaaaaaaa")]
        public void ValidationResult_ValidateEmailNickname_ReturnTooLongEmailNickname(string emailNickname)
        {
            var validationResultClass = new EmailNicknameValidationRule();
            var validationResult = validationResultClass.Validate(emailNickname, CultureInfo.DefaultThreadCurrentCulture);
            Assert.Equal(false, validationResult.IsValid);
            Assert.Equal("Too long!", validationResult.ErrorContent);
        }
        [Theory]
        [InlineData("1")]
        [InlineData("12")]
        public void ValidationResult_ValidateEmailNickname_ReturnTooShortEmailNickname(string emailNickname)
        {
            var validationResultClass = new EmailNicknameValidationRule();
            var validationResult = validationResultClass.Validate(emailNickname, CultureInfo.DefaultThreadCurrentCulture);
            Assert.Equal(false, validationResult.IsValid);
            Assert.Equal("Too short!", validationResult.ErrorContent);
        }
    }
}
