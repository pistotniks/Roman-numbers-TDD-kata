using System;
using FluentAssertions;
using Xunit;

namespace RomanNumbersTests
{
  public class WhenConvertingToRomanNumber
  {
    [Fact]
    public void ShouldConvertArabicNumber()
    {
      var converter = new ToRomanNumberConverter();
      const int arabicNumber = 1;
      const string expectedRomanNumber = "I";

      var romanNumber = converter.Convert(arabicNumber);

      romanNumber.Should().Be(expectedRomanNumber);
    }
  }

  public class ToRomanNumberConverter
  {
    public string Convert(int arabicNumber)
    {
      return "I";
    }
  }
}
