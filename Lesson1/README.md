# Lesson 1: Let's write our first unit tests

To learn about unit testing, let's write some unit tests for Stringie, a library to transform strings. You will find Stringie solution, next to this file.

Stringie developers heard about unit testing and started to write "something" like a unit test. They wrote a console project to validate a single method. Check the `TestProject` in Stringie solution to see what they did.

Your mission, Jim, should you decide to accept it, is to write at least three unit tests for one of the Stringie methods. You will find the instructions to proceed and the list of Stringie methods below. This repo will self-destruct in five seconds. Good luck, Jim.

### How-to

1. Clone this repo
2. Create a unit test project
	* Use an appropiate name
3. Add Stringie as a project reference to your test project
4. Pick one of the Stringie methods
	* `Insert`
	* `Remove`
	* `RemoveVowels`
	* `RemoveChars`
	* `IsEmpty`, `OrWhiteSpace`
	* `IndexesOf`
5. Write at least three unit tests for the method you picked
	* Use an appropiate name for your test files
	* Follow a naming convention: sentence, UnitOfWork_Scenario_Result, GivenWhenThen
	* Follow Arrange/Act/Assert
	* Use the simplest string to test
	* Think of edge cases:
		* Empty strings
		* Positions outside of a string length
		* Repeated substrings
	* Use proper assertion methods
6. (Optional) Use an assertion library like [FluentAssertions](https://fluentassertions.com/introduction) or [Shouldly](https://github.com/shouldly/shouldly) to write your assertions

### Stringie

Stringie is a library with a powerful set of utilities to transform strings using a fluent interface.

### Examples

#### Insert operations

Something simple at the beginning:

```csharp
string transformed = "<-- some string will be inserted here".Insert("I am inserted!");
// "I am inserted!<-- some string will be inserted here"
```

Let's change the position:

```csharp
string transformed = "Some string will be inserted here -->".Insert("I am inserted!").To(The.End);
// "Some string will be inserted here -->I am inserted!"
```

And simply put something at the position we want:

```csharp
string transformed = "Start of the sentence <-- some string will be inserted here".Insert("I am inserted!").At(22);
// "Start of the sentence I am inserted!<-- some string will be inserted here"
```

Mixing up with markers:

```csharp
string transformed = "MARKER, another maRKer and... marker <-- some string will be inserted here"
                      .Insert("I am inserted!").After("marker ");
// "MARKER, another maRKer and... marker I am inserted!<-- some string will be inserted here"
```

Even ignoring case:

```csharp
string transformed = "Marker1, another maRKer2 and... marker <-- some string will be inserted here"
                     .Insert("I am inserted").After("MARKER ").IgnoringCase();
// "Marker1, another maRKer2 and... marker I am inserted<-- some string will be inserted here"
```

And applying all the power:

```csharp
string t = "Some string will be inserted before this second 'some' word, but not before this 'some'"
           .Insert("I am inserted! ").Before(2, "some").IgnoringCase().From(The.Beginning);
t.Should().Be("Some string will be inserted before this second 'I am inserted! some' word, but not before this 'some'"
```

#### Remove operations

Eliminating totally:

```csharp
string transformed = "Some string".Remove();
// ""
```

Or part...

```csharp
string transformed = "THIS part of string will be removed".Remove("THIS");
// " part of string will be removed"
```

...by part:

```csharp
string transformed = "THIS <- this string will be left, but this will be removed -> THIS".Remove("THIS").From(The.End);
// "THIS <- this string will be left, but this will be removed -> "
```

By counting markers:

```csharp
string transformed = "String will be removed ->TEST and this will be removed also ->TEST, except this ->TEST"
                     .Remove(2, "TEST");
// "String will be removed -> and this will be removed also ->, except this ->TEST"
```

Or all of them at once:

```csharp
string transformed = "TEST string will be removed from both sides TEST".RemoveAll("tESt").IgnoringCase();
// " string will be removed from both sides "
```

Starting some position:

```csharp
string transformed = "Some very long string".Remove().Starting(position: 7).From(The.End);
// " string"
```

Or to some marker:

```csharp
string transformed = "Some very VERY long string with very VERY long string at the end".Remove()
                     .To(The.EndOf, 3, of: "vERy").IgnoringCase().From(The.End);
// " long string with very VERY long string at the end"
```

And starting to some positions:

```csharp
string transformed = "Some very long string".Remove().Starting(position: 9).To(position: 0);
// "Slong string"
```

#### Remove operations for chars

Creating cool effects:

```csharp
string transformed = "Vowels will be removed from this string".RemoveVowels();
// "Vwls wll b rmvd frm ths strng"
```

Or by specifying chars explicitly:

```csharp
string transformed = "Some very long string".RemoveChars('e', 'L', 'G').IgnoringCase();
// "Som vry on strin"
```

#### Utility operations

Better approach for well known:

```csharp
bool isEmpty = "".IsEmpty();
// true
```

Even for `null` case:

```csharp
string sample = null;
bool isEmpty = sample.IsEmpty();
// true
```

And continuing for white spaces:

```csharp
bool isEmptyOrWhiteSpace = "  ".IsEmpty().OrWhiteSpace();
// true
```

Extending the basics:

```csharp
var indexes = "marker with another text marker and another text marker marker".IndexesOf("marker");
// 0, 25, 49, 56
```

Breaking restrictions:

```csharp
var indexes = "Some text MARKER another text MarKer marker".IndexesOf("mArkEr").IgnoringCase();
// 10, 30, 37
```

And plainly reverse the order:

```csharp
var indexes = "marker with another text marker and another text marker marker".IndexesOf("marker").From(The.End);
// 56, 49, 25, 0
```

## Credits

Stringie is intended for learning purposes only. Stringie methods were taken from [FluentStrings](https://github.com/MSayfullin/FluentStrings).
