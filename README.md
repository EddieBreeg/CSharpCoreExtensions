# CoreExtensions

CoreExtensions is a library which extends the core features of C#, using existing namespaces like System or System.Linq.

# Features list
1. [System.Core](#core-class)
- [SplitRange](#splitrange-method)
- [Range](#range-method)

2. [System.InputHandler](#inputhandler-class)
- [KeyInput](#keyinput-method)
- [LineInput](#lineinput-method)
- [NumberInput](#numberinput-method)
- [ListInput](#listinput-method)

3. [System.NumericalStringComparer](#numericalstringcomparer-class)

4. [System.Linq.ListModules<T>](#listmodules-class)
- [SplitList](#splitlist-method)
- [Sorted](#sorted-method)
- [DeepCopy](#deepcopy-method)
- [WithoutIndex](#withoutindex-method)
- [Permute](#permute-method)

5. [System.Linq.ListExtensions](#listextensions-class)
- [IsPermutation](#ispermutation-method)
- [FlipPermutation](#flippermutation-method)
- [CompareTo](#compareto-method)

6. [System.Linq.StringExtensions](#stringextensions-class)
- [FindNumbers](#findnumbers-method)
- [ToIntEnumerable](#tointenumerable-method)
- [CompareNumerically](#comparenumerically-method)

7. [System.Linq.IntExtensions](#intextensions-class)
- [Sign method](#sign-method)


# Documentation

## Core Class
### SplitRange method

```csharp
public static int[] SplitRange(int min, int max, int divider);
```
### Range method

```csharp
public static List<int> Range(int limit);
public static List<int> Range(int start, int limit);
public static List<int> Range(int start, int limit, int step);
```

## InputHandler Class
### KeyInput method

```csharp
public static char KeyInput(string str, char[] choices, char defaultValue);
```
### LineInput method

```csharp
public static string LineInput(string str, string[] choices, string defaultValue);
public static string LineInput(string str, string defaultValue = null);
```
### NumberInput method

```csharp
public static int NumberInput(string str, int? defaultValue = null);
```
### ListInput method

```csharp
public static List<int> ListInput(string str, List<int> defaultValue=null, Func<List<int>, bool> condition=null);
public static List<string> ListInput(string str, List<string> defaultValue = null, Func<List<string>, bool> condition = null);
```

## NumericalStringComparer Class

## ListModules Class

### SplitList method

```csharp
public static List<List<T>> SplitList(List<T> lst, int count);
```
### Sorted method

```csharp
public static List<T> Sorted(List<T> lst);
```
### DeepCopy method

```csharp
public static List<T> DeepCopy(List<T> lst);

```
### WithoutIndex method

```csharp
public static List<T> WithoutIndex(List<T> lst, int index);

```
### Permute method

```csharp
public static List<T> Permute(List<T> lst, List<int> lut);
```
## System.Linq.ListExtensions Class
### IsPermutation method

```csharp
public static bool IsPermutation(this List<int> lst);
```
### FlipPermutation method

```csharp
public static List<int> FlipPermutation(this List<int> lut);
```
### CompareTo method

```csharp
public static int CompareTo(this int[] a, int[] b);
```

## ListExtensions Class
### IsPermutation method

```csharp
public static bool IsPermutation(this List<int> lst);
```
### FlipPermutation method

```csharp
public static List<int> FlipPermutation(this List<int> lut);
```
### CompareTo method

```csharp
public static int CompareTo(this int[] a, int[] b);
```

## StringExtensions Class
### FindNumbers method

```csharp
public static List<int> FindNumbers(this string str);
```
### ToIntEnumerable method

```csharp
internal static IEnumerable<int> ToIntEnumerable(this string s);
```
### CompareNumerically method

```csharp
public static int CompareNumerically(this string str, string other);
```

## IntExtensions Class
### Sign method
```csharp
public static int? Sign(this int? x);
public static int Sign(this int x);
```
