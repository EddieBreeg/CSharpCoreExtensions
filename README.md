# CoreExtensions
CoreExtensions is a library which extends the core features of C#, using existing namespaces like System or System.Linq.

**Version:** 1.0.0 prerelease

## Features List

1. [System.Core](#core)
- [System.Core.SplitRange(System.Int32,System.Int32,System.Int32)](#splitrange)
- [System.Core.Range(System.Int32)](#range)
- [System.Core.Range(System.Int32,System.Int32)](#range)
- [System.Core.Range(System.Int32,System.Int32,System.Int32)](#range)

2. [System.NumericalStringComparer](#numericalstringcomparer)
- [System.NumericalStringComparer.Compare(System.String,System.String)](#compare)

3. [System.Linq.ListExtensions](#listextensions)
- [System.Linq.ListExtensions.Split(System.Collections.Generic.List, System.Int32)](#splitlist)

4. [System.InputHandler](#inputhandler)
- [System.InputHandler.KeyInput(System.String,System.Char)](#keyinput)
- [System.InputHandler.KeyInput(System.String,System.Char[],System.Char)](#keyinput)
- [System.InputHandler.LineInput(System.String,System.String)](#lineinput)
- [System.InputHandler.LineInput(System.String,System.String[],System.String)](#lineinput)
- [System.InputHandler.IntInput(System.String,System.Int32)](#intinput)
- [System.InputHandler.DoubleInput(System.String,System.Double)](#doubleinput)
- [System.InputHandler.ListInput(System.String,System.Collections.Generic.List{System.String},System.Func{System.Collections.Generic.List{System.String},System.Boolean})](#listinput)
- [System.InputHandler.IntListInput(System.String,System.Collections.Generic.List{System.Int32},System.Func{System.Collections.Generic.List{System.Int32},System.Boolean})](#intlistinput)

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

### ListExtensions

A collection of extension methods for List objects

#### SplitList

```csharp
SplitList(List lst, int count)
```

Splits the list into `count` sublists

- count:

Returns:

### InputHandler

A static class which contains useful methods to handle user inputs

#### KeyInput

```csharp
KeyInput(string str, char[] choices, char defaultValue)
```

Prompts the user to press a key

- str: The string to print out

- defaultValue: Defines what will be returned if the user presses Enter

Returns: A char object representing the key

#### KeyInput

```csharp
KeyInput(string str, char[] choices, char defaultValue='\0')
```

- choices: The different options the user can choose from

#### LineInput

```csharp
LineInput(string str, string defaultValue = "")
```

Prompts the user to enter a string of text

- str: The string to print out

- defaultValue: The value to return if the user hits enter

Returns: The string entered by the user

#### LineInput

```csharp
LineInput(string str, string[] choices, string defaultValue)
```

Lets the user choose a string from a set of default values

- choices: An array containing the options the user can choose from

#### IntInput

```csharp
IntInput(string str, int defaultValue = 0)
```

Prompts the user to enter an integer

- str: The string to print out

- defaultValue: What the function returns if the user hits Enter

Returns: The integer the user entered

#### DoubleInput

```csharp
IntInput(string str, int defaultValue = 0)
```

Prompts the user to enter a double

- str: The string to print out

- defaultValue: What the function returns if the user hits Enter

Returns: The double the user entered

#### ListInput

```csharp
ListInput(string str, List defaultValue = null, Func condition = null)
```

Prompts the user to enter a list of text strings

- str: The string to print out

- defaultValue: The list to return if the user hits Enter

- condition: The condition the resulting list must satisfy

Returns: The user input as a List object

Remarks: The values entered by the user should be separated by a ' '

#### IntListInput

```csharp
IntListInput(string str, List defaultValue = null, Func condition = null)
```

Prompts the user to enter a list of integers

- str: The string to print out

- defaultValue: The list to return if the user hits Enter

- condition: The condition the resulting list must satisfy

Returns: The user input as a List object

Remarks: The values entered by the user should be separated by a ' '
