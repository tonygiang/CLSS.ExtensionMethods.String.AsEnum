# CLSS.ExtensionMethods.String.AsEnum

### Problem

For those whose working environment is stuck on .NET versions lower than 6.0, converting `string` to enum is done like this:

```
enum Rarity { Common, Uncommon, Rare }

var r = (Rarity)Enum.Parse(typeof(Rarity), "Uncommon");
```

The enum type name has to be written twice in this syntax.

Furthermore, `Enum.Parse` does not statically check that the type parameter is of type `System.Enum`. It is possible to pass in an type and get no compile-time error, but you will get a runtime exception.

.NET 6.0 introduces a better syntax, but still not very functional-style-friendly:

```
var r = Enum.Parse<Rarity>("Uncommon");
```

The same type safety issue remains because `Enum.Parse<T>` type constraint is `where TEnum : struct`, not `where TEnum : System.Enum`.

### Solution

`AsEnum<T>` is an enum conversion syntax for `string` that is type-safe and friendly to functional style for all .NET versions.

```
using CLSS;

var r = "Uncommon".AsEnum<Rarity>();
```

Trying to pass in a non-enum type will create a compile-time error.

Like `Enum.Parse`, `AsEnum<T>` is case-sensitive by default and takes in an optional argument to ignore case.

```
using CLSS;

var r = "uNCOMMON".AsEnum<Rarity>(true);
```

##### This package is a part of the [C# Language Syntactic Sugar suite](https://github.com/tonygiang/CLSS).