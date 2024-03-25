using Instagram.Validations;
using System.ComponentModel.DataAnnotations;
using System.Globalization;

namespace Instagram.UnitTests.ValidationRulesUnitTests
{
    public class EmailValidationRuleUnitTest
    {
        public void MethodThatAssertWrongValidations(string email, string feedback)
        {
            var validationResultClass = new EmailValidationRule();
            var validationResult = validationResultClass.Validate(email, CultureInfo.DefaultThreadCurrentCulture);
            Assert.Equal(false, validationResult.IsValid);
            Assert.Equal(feedback, validationResult.ErrorContent);
        }
        [Theory]
        [InlineData("test@gmail.pl")]
        [InlineData("test1@gmail.pl")]
        [InlineData("test1.2@gmail.pl")]
        [InlineData("1test1@gmail.pl")]
        [InlineData("1test1.2@gmail.pl")]
        [InlineData("1@gmail.pl")]
        [InlineData("a@gmail.pl")]
        [InlineData("a.1@gmail.pl")]
        [InlineData("1.0@gmail.pl")]
        [InlineData("test@o.pl")]
        [InlineData("test1@o.pl")]
        [InlineData("test1.2@o.pl")]
        [InlineData("1test1@o.pl")]
        [InlineData("1test1.2@o.pl")]
        [InlineData("1@o.pl")]
        [InlineData("a@o.pl")]
        [InlineData("a.1@o.pl")]
        [InlineData("1.0@o.pl")]
        [InlineData("test@gmail.cda")]
        [InlineData("test1@gmail.cda")]
        [InlineData("test1.2@gmail.cda")]
        [InlineData("1test1@gmail.cda")]
        [InlineData("1test1.2@gmail.cda")]
        [InlineData("1@gmail.cda")]
        [InlineData("a@gmail.cda")]
        [InlineData("a.1@gmail.cda")]
        [InlineData("1.0@gmail.cda")]
        public void ValidationResult_ValidateEmail_ReturnTrue(string email)
        {
            var validationResultClass = new EmailValidationRule();
            var validationResult = validationResultClass.Validate(email, CultureInfo.DefaultThreadCurrentCulture);
            Assert.Equal(true, validationResult.IsValid);
        }
        [Theory]
        [InlineData(".test@gmail.pl")]
        [InlineData("test.@gmail.pl")]
        [InlineData(".test.@gmail.pl")]
        public void ValidationResult_ValidateEmail_ReturnDotError(string email)
        {
            string feedback = "user identificator can't have '.' on start and end";
            MethodThatAssertWrongValidations(email, feedback);
        }
        [Theory]
        [InlineData("testgmail.pl")]
        [InlineData("testo.eu")]
        [InlineData("testonet.cda")]
        public void ValidationResult_ValidateEmail_ReturnNoAtError(string email)
        {
            string feedback = "email has to contain '@'";
            MethodThatAssertWrongValidations(email, feedback);
        }
        [Theory]
        [InlineData("te#st@gmail.pl")]
        [InlineData("tes%t@gmail.pl")]
        [InlineData("&test@gmail.pl")]
        [InlineData("t*est@gmail.pl")]
        [InlineData("te(st@gmail.pl")]
        [InlineData("test)@gmail.pl")]
        [InlineData("te!st@gmail.pl")]
        [InlineData("&&&&@gmail.pl")]
        public void ValidationResult_ValidateEmail_ReturnWrongCharError(string email)
        {
            string feedback = "user identificator can only contain letters, numbers and dots";
            MethodThatAssertWrongValidations(email, feedback);
        }
        [Theory]
        [InlineData("test@gmailpl")]
        [InlineData("test@oppl")]
        [InlineData("test@oneteu")]
        [InlineData("test@gmai.l.pl")]
        [InlineData("test@o.pp.l")]
        [InlineData("test@.onet.eu")]
        public void ValidationResult_ValidateEmail_ReturnDotErrorAfterAt(string email)
        {
            string feedback = "after '@' has to be only one '.'";
            MethodThatAssertWrongValidations(email, feedback);
        }
        [Theory]
        [InlineData("test@gmail.polska")]
        [InlineData("test@gmail.poland")]
        [InlineData("test@gmail.aldksf")]
        [InlineData("test@gmail.plaa")]
        [InlineData("test@gmail.cdaa")]
        [InlineData("test@gmail.adsfadggdfghs")]
        public void ValidationResult_ValidateEmail_ReturnTooLongAfterDot(string email)
        {
            string feedback = "after last '.' can be only 2 to 3 letters";
            MethodThatAssertWrongValidations(email, feedback);
        }
        [Theory]
        [InlineData("test@gmail.^l")]
        [InlineData("test@gmail.p*")]
        [InlineData("test@gm#il.pl")]
        [InlineData("test@gm$il.p(")]
        [InlineData("test@gmail.)l")]
        [InlineData("test@g!ail.pl")]
        public void ValidationResult_ValidateEmail_ReturnOnlyLettersAfterAt(string email)
        {
            string feedback = "after '@' has to be only letters (and one dot)";
            MethodThatAssertWrongValidations(email, feedback);
        }
    }
}