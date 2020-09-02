# CoreExtensions

## Features List

1. [System.Core](#core)
- [System.Core.SplitRange(System.Int32,System.Int32,System.Int32)](#splitrange)
- [System.Core.Range(System.Int32)](#range)
- [System.Core.Range(System.Int32,System.Int32)](#range)
- [System.Core.Range(System.Int32,System.Int32,System.Int32)](#range)

2. [System.NumericalStringComparer](#numericalstringcomparer)
- [System.NumericalStringComparer.Compare(System.String,System.String)](#compare)

3. [System.Linq.ListModules`1](#listmodules-class)

## Doc

### Core
A class containing basic core features

#### SplitRange
```csharp
SplitRange(int min, int max, int divider)
```

- min: The inferiour boundry of the interval to split

- max: The superior boundry of the interval to split

- divider: The number of subintervals to compute

Creates an even subdivision of the interval [min;max]

Returns: An array containing the boundries of the subdivision

#### Range
```csharp
Range(int limit)
```

- limit: The extreme value at which the sequence stops

Generates a sequence from 0 to limit (excluded)

Returns: The sequence into a List object

#### Range
```csharp
Range(int start, int limit)
```

- start: The integer from which the sequence starts

- limit: The extreme value at which the sequence stops

Generates a sequence from start to limit (excluded)

Returns: The sequence into a List object

#### Range
```csharp
Range(int start, int limit, int step)
```

- start: The integer from which the sequence starts

- limit: The extreme value at which the sequence stops

- step: The increment

Generates a sequence from start to limit (excluded), incrementng by step

Returns: The sequence into a List object

### NumericalStringComparer
An IComparer class to compare to numerical strings

#### Compare
Returns: a.CompareNumerically(b);

Remarks: See the doc of the CompareNumerically
            extension method for more details

### ListModules Class
A static class containing various generic List utilities
            

- Type parameter T: The type of List object 
