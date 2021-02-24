using System;
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
    public void ShouldConvertArabicNumber(int arabicNumber, string expectedRomanNumber)
    {
      var converter = new ToRomanNumberConverter();

      var romanNumber = converter.Convert(arabicNumber);

      romanNumber.Should().Be(expectedRomanNumber);
    }
  }

  public class ToRomanNumberConverter
  {
    public string Convert(int arabicNumber)
    {
      string romanNumber = "I";

      if (arabicNumber > 1)
      {
        romanNumber += "I";
      }

      if (arabicNumber > 2)
      {
        romanNumber += "I";
      }

      return romanNumber;
    }
  }
}
