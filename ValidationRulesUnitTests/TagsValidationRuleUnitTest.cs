using Instagram.Validations;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Instagram.UnitTests.ValidationRulesUnitTests
{
    public class TagsValidationRuleUnitTest
    {
        [Theory]
        [InlineData("polish boy")]
        [InlineData("Polish Boy")]
        [InlineData("France pris")]
        [InlineData("on the beach in dubai vacations")]
        public void ValidationResult_ValidateTags_ReturnTrue(string tags)
        {
            var validationResultClass = new TagsValidationRule();
            var validationResult = validationResultClass.Validate(tags, CultureInfo.DefaultThreadCurrentCulture);
            Assert.Equal(true, validationResult.IsValid);
        }
        [Theory]
        [InlineData("polish b0y")]
        [InlineData("Polish B%oy")]
        [InlineData("Fran#ce pris")]
        [InlineData("on th#e b9each in dubai vacations")]
        public void ValidationResult_ValidateTags_ReturnOnlyLettersAndSpaces(string tags)
        {
            var validationResultClass = new TagsValidationRule();
            var validationResult = validationResultClass.Validate(tags, CultureInfo.DefaultThreadCurrentCulture);
            Assert.Equal(false, validationResult.IsValid);
            Assert.Equal("Tags can contain only letters ans spaces!", validationResult.ErrorContent);
        }
        [Theory]
        [InlineData("aaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaa")]
        public void ValidationResult_ValidateTags_ReturnTooLongTags(string tags)
        {
            var validationResultClass = new TagsValidationRule();
            var validationResult = validationResultClass.Validate(tags, CultureInfo.DefaultThreadCurrentCulture);
            Assert.Equal(false, validationResult.IsValid);
            Assert.Equal("Tags are too long!", validationResult.ErrorContent);
        }
    }
}
