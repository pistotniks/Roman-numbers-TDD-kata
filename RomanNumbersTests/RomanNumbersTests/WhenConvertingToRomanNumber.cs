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
    // Reversed mapping to be able to loop forward and not in reverse order
    public static readonly IDictionary<int, string> RomanNumbers = new Dictionary<int, string>
    {
      {40, "XL"},
      {10, "X"},
      {9, "IX"},
      {5, "V"},
      {4, "IV"},
      {1, "I"},
    };

    public string Convert(int arabicNumber)
    {
      string romanNumber = string.Empty;

      using var mappings = RomanNumbers.GetEnumerator();
      while (mappings.MoveNext())
      {
        var map = mappings.Current;
        while (arabicNumber >= map.Key)
        {
          romanNumber += map.Value;
          arabicNumber -= map.Key;
        }
      }

      return romanNumber;
    }
  }
}
