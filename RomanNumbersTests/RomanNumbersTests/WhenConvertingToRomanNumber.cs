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
    };

    public string Convert(int arabicNumber)
    {
      if (RomanNumbers.ContainsKey(arabicNumber))
      {
        return RomanNumbers[arabicNumber];
      }
      return RomanNumbers[1] + Convert(arabicNumber - 1);
    }
  }
}
