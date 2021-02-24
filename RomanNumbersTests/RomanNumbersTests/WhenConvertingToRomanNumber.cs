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
    public void ShouldConvertArabicNumber(int arabicNumber, string expectedRomanNumber)
    {
      var converter = new ToRomanNumberConverter();

      var romanNumber = converter.Convert(arabicNumber);

      romanNumber.Should().Be(expectedRomanNumber);
    }
  }

  public class ToRomanNumberConverter
  {
    public static readonly IDictionary<int, string> RomanNumbers = new Dictionary<int, string>
    {
      {1, "I"},
      {4, "IV"},
      {5, "V"},
      {9, "IX"},
      {10, "X"},
      {40, "XL"},
    };

    public string Convert(int arabicNumber)
    {
      if (RomanNumbers.ContainsKey(arabicNumber))
      {
        return RomanNumbers[arabicNumber];
      }

      string romanNumber = string.Empty;

      while (arabicNumber >= 40)
      {
        romanNumber += "XL";
        arabicNumber -= 40;
      }
      while (arabicNumber >= 10)
      {
        romanNumber += "X";
        arabicNumber -= 10;
      }
      while (arabicNumber >= 5)
      {
        romanNumber += "V";
        arabicNumber -= 5;
      }
      while (arabicNumber >= 4)
      {
        romanNumber += "IV";
        arabicNumber -= 4;
      }
      while (arabicNumber >= 1)
      {
        romanNumber += "I";
        arabicNumber -= 1;
      }
      return romanNumber;
    }
  }
}
