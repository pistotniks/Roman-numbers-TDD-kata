using System;
using System.Collections.Generic;
using FluentAssertions;
using Xunit;

namespace RomanNumbersTests
{
  public class WhenConvertingToRomanNumber
  {
    [Theory()]
    [InlineData(1, "I")]
    [InlineData(2, "II")]
    [InlineData(3, "III")]
    [InlineData(4, "IV")]
    [InlineData(5, "V")]
    [InlineData(6, "VI")]
    [InlineData(7, "VII")]
    [InlineData(8, "VIII")]
    [InlineData(9, "IX")]
    [InlineData(10, "X")]
    [InlineData(40, "XL")]
    [InlineData(44, "XLIV")]
    [InlineData(50, "L")]
    [InlineData(90, "XC")]
    [InlineData(100, "C")]
    [InlineData(400, "CD")]
    [InlineData(500, "D")]
    [InlineData(900, "CM")]
    [InlineData(1000, "M")]
    [InlineData(846, "DCCCXLVI")]
    [InlineData(1999, "MCMXCIX")]
    [InlineData(2008, "MMVIII")]
    public void ShouldConvertArabicNumber(int arabicNumber, string expectedRomanNumber)
    {
      var converter = new ToRomanNumberConverter();

      var romanNumber = converter.Convert(arabicNumber);

      romanNumber.Should().Be(expectedRomanNumber);
    }
  }

  public class ToRomanNumberConverter
  {
    // Reversed mapping to be able to loop forward and not in reverse order
    public static readonly IDictionary<int, string> ArabicsToRomans = new Dictionary<int, string>
    {
      {1000, "M"},
      {900, "CM"},
      {500, "D"},
      {400, "CD"},
      {100, "C"},
      {90, "XC"},
      {50, "L"},
      {40, "XL"},
      {10, "X"},
      {9, "IX"},
      {5, "V"},
      {4, "IV"},
      {1, "I"},
    };

    public string Convert(int arabicNumber)
    {
      var romanNumber = string.Empty;

      foreach (var (arabicNumeral, romanNumeral) in ArabicsToRomans)
      {
        while (arabicNumber >= arabicNumeral)
        {
          romanNumber += romanNumeral;
          arabicNumber -= arabicNumeral;
        }
      }
      return romanNumber;
    }
  }
}
