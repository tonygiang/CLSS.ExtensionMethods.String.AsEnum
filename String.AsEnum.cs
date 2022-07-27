// A part of the C# Language Syntactic Sugar suite.

using System;

namespace CLSS
{
  public static partial class StringAsEnum
  {
    /// <summary>
    /// Converts the string representation of the name or numeric value of one
    /// or more enumerated constants specified by <typeparamref name="TEnum"/>
    /// to an equivalent enumerated object. A parameter specifies whether the
    /// operation is case-insensitive.
    /// </summary>
    /// <typeparam name="TEnum">An enumeration type.</typeparam>
    /// <param name="source">A string containing the name or value to convert.
    /// </param>
    /// <param name="ignoreCase">true to ignore case; false to regard case.
    /// </param>
    /// <returns>An object of type <typeparamref name="TEnum"/> whose value is
    /// represented by <paramref name="source"/>.</returns>
    public static TEnum AsEnum<TEnum>(this string source,
      bool ignoreCase = false)
      where TEnum : Enum
    { return (TEnum)Enum.Parse(typeof(TEnum), source, ignoreCase); }
  }
}
