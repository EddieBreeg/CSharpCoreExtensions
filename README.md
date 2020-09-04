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

3. [System.Linq.EnumerableExtensions](#listextensions)
- [System.Linq.EnumerableExtensions.Split``1(System.Collections.Generic.List{``0},System.Int32)](#split)
- [System.Linq.EnumerableExtensions.WithoutIndex``1(System.Collections.Generic.List{``0},System.Int32)](#withoutindex)
- [System.Linq.EnumerableExtensions.Sorted``1(System.Collections.Generic.List{``0},System.Collections.Generic.IComparer{``0})](#sorted)
- [System.Linq.EnumerableExtensions.IsPermutation(System.Collections.Generic.List{System.Int32})](#ispermutation)
- [System.Linq.EnumerableExtensions.Permute``1(System.Collections.Generic.List{``0},System.Collections.Generic.List{System.Int32})](#permute)
- [System.Linq.EnumerableExtensions.FlipPermutation(System.Collections.Generic.List{System.Int32})](#flippermutation)

4. [System.Linq.StringExtensions](#stringextensions)
- [System.Linq.StringExtensions.FindNumbers(System.String)](#findnumbers)
- [System.Linq.StringExtensions.ToIntEnumerable(System.String)](#tointenumerable)
- [System.Linq.StringExtensions.CompareNumerically(System.String,System.String)](#comparenumerically)

5. [System.Linq.ObjectExtensions](#objectextensions)
- [System.Linq.ObjectExtensions.DeepCopy``1(``0)](#deepcopy(this-t-obj))

6. [System.InputHandler](#inputhandler)
- [System.InputHandler.KeyInput(System.String,System.Char)](#keyinput)
- [System.InputHandler.KeyInput(System.String,System.Char[],System.Char)](#keyinput)
- [System.InputHandler.LineInput(System.String,System.String)](#lineinput)
- [System.InputHandler.LineInput(System.String,System.String[],System.String)](#lineinput)
- [System.InputHandler.IntInput(System.String,System.Int32)](#intinput)
- [System.InputHandler.DoubleInput(System.String,System.Double)](#doubleinput)
- [System.InputHandler.ListInput(System.String,System.Collections.Generic.List{System.String},System.Func{System.Collections.Generic.List{System.String},System.Boolean})](#listinput)
- [System.InputHandler.IntListInput(System.String,System.Collections.Generic.List{System.Int32},System.Func{System.Collections.Generic.List{System.Int32},System.Boolean})](#intlistinput)

## Doc


### *Core*
A class containing basic core features


### *SplitRange*
```csharp
SplitRange(int min, int max, int divider)
```
- min: The inferiour boundry of the interval to split

- max: The superior boundry of the interval to split

- divider: The number of subintervals to compute

Creates an even subdivision of the interval [min;max]


Returns: An array containing the boundries of the subdivision

### *Range*
```csharp
Range(int limit)
```
- limit: The extreme value at which the sequence stops

Generates a sequence from 0 to limit (excluded)


Returns: The sequence into a List object

### *Range*
```csharp
Range(int start, int limit)
```
- start: The integer from which the sequence starts

- limit: The extreme value at which the sequence stops

Generates a sequence from start to limit (excluded)


Returns: The sequence into a List object

### *Range*
```csharp
Range(int start, int limit, int step)
```
- start: The integer from which the sequence starts

- limit: The extreme value at which the sequence stops

- step: The increment

Generates a sequence from start to limit (excluded), incrementng by step


Returns: The sequence into a List object

### *NumericalStringComparer*
An IComparer class to compare to numerical strings


### *Compare*

Returns: a.CompareNumerically(b);

Remarks: See the doc of the CompareNumerically
            extension method for more details

### *ListExtensions*
A collection of extension methods for List objects


### *Split*
```csharp
Split(List lst, int count)
```
Splits the list into `count` sublists

- count: The number of sublists to create

- lst: The list object to split


Returns: 

### *WithoutIndex*
```csharp
WithoutIndex(this List lst, int index)
```
Generates a version of the list without item at `index`

- Type parameter T: The type of List object
- lst: The List to remove the item from

- index: The index of the item to remove


Returns: `lst` in which item at `index` has been removed

### *Sorted*
```csharp
Sorted(this List lst, IComparer comparer=null)
```
Returns the sorted version of `lst` using either the default comparer, or the comparer passed as an argument

- lst: The List to sort

- comparer: IComparer object for the sort algorithm to use


Returns: The sorted version of `lst`

### *IsPermutation*
```csharp
IsPermutation(this List lst)
```
Tests if `lst` represents a mathematical permutation of the integers from 0 to `lst.Count-1`

- lst: The List of integers to test

Example:
{1, 2, 0, 4, 3} is a permutation, but {2,3,1} and {1,2,4} are not

Returns: The boolean result of the test

### *Permute*
```csharp
List Permute(this List lst, List lut)
```
Applies the permutation represented by `lut` to `lst`

- Type parameter T: The type of the List to permute
- lst: The List to permute

- lut: The lookup table to use for the permutation


Returns: The permuted version of the list

Remarks: If `lut.IsPermutation!=true || lut.Count != lst.Count`, a FormatException will be thrown

### *FlipPermutation*
```csharp
FlipPermutation(this List lut)
```
Flips the permutation represented by `lut` 
            (which corresponds to doing `lut.Permute(lut)`

- lut: The List object representing the permutation


Returns: The flipped version of `lut`

Remarks: If `lut.IsPermutation == false`, a FormatException will be thrown

### *StringExtensions*
A collection of extension methods for string objects


### *FindNumbers*
```csharp
FindNumbers(this string str)
```
Searches all the numrical values in `str`

- str: The string to search in


Returns: An int[] containing all the values

### *ToIntEnumerable*
```csharp
ToIntEnumerable(this string s)
```
Converts the string to a set of integers by converting each char to its numerical value 
            and evaluating any potential number

Example:
"foo1".ToIntEnumerable() = {102, 111, 111, 1}
- s: The string to iterate through


Returns: An IEnumerable object generating the values

Remarks: This method is internal and shouldn't be used directly. It is only there to be used by the 
            CompareNumerically method

### *CompareNumerically*
```csharp
CompareNumerically(this string str, string other)
```
Compares strings which might contain numbers and returns an indication of their relative values

- str: This instance

- other: The string to compare to


Returns: A signed integer indicating the relative values of `this` and `other`:
            -1 if `this` is smaller than `other`, 1 if `this` is greater than `other`, 0 if they're equal

### *ObjectExtensions*
A collection of extension methods for any type of object


### *DeepCopy(this T obj)*
Creates a copy of `obj`

- Type parameter T: The actual type of `obj`
- obj: The object to be copied


Returns: A `T` object copy of `obj`

Remarks: The `T` class has to be marked as [Serializable] for this function to work

### *InputHandler*
A static class which contains useful methods to handle user inputs


### *KeyInput*
```csharp
KeyInput(string str, char defaultValue)
```
Prompts the user to press a key

- str: The string to print out

- defaultValue: Defines what will be returned if the user presses Enter


Returns: A char object representing the key

### *KeyInput*
```csharp
KeyInput(string str, char[] choices, char defaultValue='\0')
```
- str: The string to print out

- choices: The different options the user can choose from


### *LineInput*
```csharp
LineInput(string str, string defaultValue = "")
```
Prompts the user to enter a string of text

- str: The string to print out

- defaultValue: The value to return if the user hits enter


Returns: The string entered by the user

### *LineInput*
```csharp
LineInput(string str, string[] choices, string defaultValue)
```
Lets the user choose a string from a set of default values

- str: The string to print out

- choices: An array containing the options the user can choose from

- defaultValue: The value to return if the user hits Enter


Returns: The string entered by the user

### *IntInput*
```csharp
IntInput(string str, int defaultValue = 0)
```
Prompts the user to enter an integer

- str: The string to print out

- defaultValue: What the function returns if the user hits Enter


Returns: The integer the user entered

### *DoubleInput*
```csharp
IntInput(string str, int defaultValue = 0)
```
Prompts the user to enter a double

- str: The string to print out

- defaultValue: What the function returns if the user hits Enter


Returns: The double the user entered

### *ListInput*
```csharp
ListInput(string str, List defaultValue = null, Func condition = null)
```
Prompts the user to enter a list of text strings

- str: The string to print out

- defaultValue: The list to return if the user hits Enter

- condition: The condition the resulting list must satisfy


Returns: The user input as a List object

Remarks: The values entered by the user should be separated by a ' '

### *IntListInput*
```csharp
IntListInput(string str, List defaultValue = null, Func condition = null)
```
Prompts the user to enter a list of integers

- str: The string to print out

- defaultValue: The list to return if the user hits Enter

- condition: The condition the resulting list must satisfy


Returns: The user input as a List object

Remarks: The values entered by the user should be separated by a ' '
