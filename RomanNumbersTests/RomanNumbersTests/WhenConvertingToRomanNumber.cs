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
    };

    public string Convert(int arabicNumber)
    {
      if (RomanNumbers.ContainsKey(arabicNumber))
      {
        return RomanNumbers[arabicNumber];
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
