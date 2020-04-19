using ConvertArabicNumber.Core;
using System;
using Xunit;

namespace ConvertArabicNumber.Test
{
    public class ExtensionTest
    {
        [Fact]
        public void Test1()
        {

        }

        [Theory]
        [InlineData("١٢٣٠")]
        public void FindLang_When_Text_Is_Arabic_Or_Persian_ShouldReturn_Arabic_Or_Persian(string text)
        {
            var result = text.FindLang();

            Assert.Equal(result.ToString(), LanguageForNumber.Persian.ToString());
        }

        [Theory]
        [InlineData("123")]
        public void FindLang_When_Text_Is_Arabic_Or_Persian_Should_Return_English(string text)
        {
            var result = text.FindLang();

            Assert.Equal(result.ToString(), LanguageForNumber.English.ToString());
        }

        [Theory]
        [InlineData("١٢٣٠", 1230)]
        [InlineData("123", 123)]
        public void GetArabicNumber_When_Text_Is_Arabic_Or_Persian_Should_Return_Arabic_Equality_Of_Text(string text, int expected)
        {
            var result = text.GetArabicNumber();

            Assert.Equal(expected, result);

        }

        [Theory]
        [InlineData("١٢٣٠١٢٣١", 12301231)]
        [InlineData("1234444", 1234444)]
        public void GetArabicNumber_When_Text_Is_Arabic_Or_Persian(string text, int expected)
        {
            var result = text.GetArabicNumber();

            Assert.Equal(expected, result);

        }
    }
}
