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

      if (arabicNumber > 40)
      {
        const string result = "XL";
        return result + Convert(arabicNumber - 40);
      }
      if (arabicNumber > 10)
      {
        const string result = "X";
        return result + Convert(arabicNumber - 10);
      }

      if (arabicNumber > 5)
      {
        const string result = "V";
        return result + Convert(arabicNumber - 5);
      }
      return RomanNumbers[1] + Convert(arabicNumber - 1);
    }
  }
}
