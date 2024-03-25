using Instagram.Validations;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Instagram.UnitTests.ValidationRulesUnitTests
{
    public class PasswordValidationRuleUnitTest
    {
        [Theory]
        [InlineData("123Admin")]
        [InlineData("187Adamek")]
        [InlineData("Pro3bl3emik")]
        [InlineData("Papi3ezyk")]
        [InlineData("P4assWOrd")]
        [InlineData("147S-289O-pak0")]
        public void ValidationResult_ValidatePassword_ReturnTrue(string password)
        {
            var validationResultClass = new PasswordValidationRule();
            var validationResult = validationResultClass.Validate(password, CultureInfo.DefaultThreadCurrentCulture);
            Assert.Equal(true, validationResult.IsValid);
        }
        [Theory]
        [InlineData("P")]
        [InlineData("P4")]
        [InlineData("P4s")]
        [InlineData("P4ss")]
        [InlineData("P4ssw")]
        [InlineData("P4sswo")]
        [InlineData("P4sswor")]
        public void ValidationResult_ValidatePassword_ReturnTooShortPassword(string password)
        {
            var validationResultClass = new PasswordValidationRule();
            var validationResult = validationResultClass.Validate(password, CultureInfo.DefaultThreadCurrentCulture);
            Assert.Equal(false, validationResult.IsValid);
            Assert.Equal("Password has to contain minimum 8 characters!", validationResult.ErrorContent);
        }
        [Theory]
        [InlineData("pasSword")]
        [InlineData("longPassowrd")]
        [InlineData("PasswordWithoutDigits")]
        public void ValidationResult_ValidatePassword_ReturnPasswordWithoutDigits(string password)
        {
            var validationResultClass = new PasswordValidationRule();
            var validationResult = validationResultClass.Validate(password, CultureInfo.DefaultThreadCurrentCulture);
            Assert.Equal(false, validationResult.IsValid);
            Assert.Equal("Password has to contain digit!", validationResult.ErrorContent);
        }
        [Theory]
        [InlineData("12345678")]
        [InlineData("1@#%12304789")]
        [InlineData("^&*#---12349")]
        public void ValidationResult_ValidatePassword_ReturnPasswordWithoutLetters(string password)
        {
            var validationResultClass = new PasswordValidationRule();
            var validationResult = validationResultClass.Validate(password, CultureInfo.DefaultThreadCurrentCulture);
            Assert.Equal(false, validationResult.IsValid);
            Assert.Equal("Password has to contain letter!", validationResult.ErrorContent);
        }
        [Theory]
        [InlineData("p4ssword")]
        [InlineData("d3tonar0r")]
        public void ValidationResult_ValidatePassword_ReturnPasswordWithoutCapitalLetters(string password)
        {
            var validationResultClass = new PasswordValidationRule();
            var validationResult = validationResultClass.Validate(password, CultureInfo.DefaultThreadCurrentCulture);
            Assert.Equal(false, validationResult.IsValid);
            Assert.Equal("Password has to contain capital letter!", validationResult.ErrorContent);
        }
    }
}
