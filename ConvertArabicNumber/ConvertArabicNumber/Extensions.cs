using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ConvertArabicNumber.Core
{
    public static class Extensions
    {
        public static LanguageForNumber FindLang(this string text)
        {
            if (text.Any(c => c >= 0xFB50 && c <= 0xFEFC))
            {
                return LanguageForNumber.Arabic;
            }
            if (text.Any(c => c >= 0x0600 && c <= 0x06FF))
            {
                return LanguageForNumber.Persian;
            }
            if (text.Any(c => c >= 0x20 && c <= 0x7E))
            {
                return LanguageForNumber.English;
            }
            if (text.Any(c => c >= 0x2000 && c <= 0xFA2D))
            {
                return LanguageForNumber.Chinese;
            }

            return LanguageForNumber.English;
        }

        public static int GetArabicNumber(this string text)
        {
            int arabicNumber = 0;
            var lang = text.FindLang();

            if (lang == LanguageForNumber.English)
            {
                int.TryParse(text, out arabicNumber);
            }
            else if (lang == LanguageForNumber.Arabic || lang == LanguageForNumber.Persian)
            {
                arabicNumber = text.GetArabicNumberOfArabicLetter();
            }

            return arabicNumber;
        }

        public static int GetArabicNumberOfArabicLetter(this string text)
        {
            int arabicNumber = 0;
            string values = string.Empty;

            for (int i = 0; i < text.Length; i++)
            {
                if (Char.IsDigit(text[i]))
                {
                    values += char.GetNumericValue(text, i);
                }
                else
                {
                    values += text[i].ToString();
                }
            }
            int.TryParse(values, out arabicNumber);

            return arabicNumber;
        }
    }
}
