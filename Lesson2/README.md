# Lesson 2: Let's fix some tests

To avoid making common mistakes, let's fix some unit tests Stringie developers wrote. This time, they turned the Console project from [Lesson 1](../Lesson1/README.md) into a real test project and wrote some unit tests. But, they forgot to follow naming conventions and made other mistakes along the way. You will find the solution with the tests they wrote, next to this file.

Your mission, Jim, should you decide to accept it, is to fix the unit test Stringie developers wrote. You will find the instructions to proceed below. This repo will self-destruct in five seconds. Good luck, Jim.

### How-to

1. Clone this repo
2. Does the test project compile? Are all tests passing? If that's not the case, make them pass
3. Does the test project follow a naming convention?
	* Does the test project name have a `Tests` or `UnitTests` suffix?
4. Are the tests organized in the appropiate files? 
5. Do the test names follow a naming convention? For example: sentence, UnitOfWork_Scenario_Result, GivenWhenThen
6. Do the tests follow Arrange/Act/Assert?
	* Is the code inside each test separated with line breaks to show each part?
7. Do the tests use an Assertion library? If that's not the case, rewrite those test to use MSTest
8. Do the tests use the appropiate Assert methods? For example: `AreNull()` instead of `AreEqual()` with a `null` value, `Assert.AreEqual()` instead of `IsTrue()` with a comparison
9. Do the tests have a single assertion per test? It that's not the case, use Parameterized tests
10. Do the assertions repeat the logic under test?

For more examples of mistakes when writing unit tests, check [4 common mistakes when writing your first unit tests](https://canro91.github.io/2021/03/29/UnitTestingCommonMistakes/).

You can take a look at the README file from [Lesson 1](../Lesson1/README.md) to check all the Stringie available methods.

### How to create Parameterized tests with MSTest

To write a parameterized test, follow these steps:

* Instead of using `[TestMethod]` attribute, use `[DataTestMethod]`
* Use a `[DataRow]` attribute for each set of test values
* Add the appropriate parameters to your test. One paramater for each value inside the `[DataRow]` attribute
* Use the input parameters in your tests to Arrange, Act or Assert

For example,

```csharp
[DataTestMethod]
[DataRow("HELLO")]
[DataRow("Hello")]
[DataRow("HeLLo")]
public void Remove_SubstringWithDifferentCase_RemovesSubstring(string substringToRemove)
{
    var str = "Hello, world!";

    var transformed = str.RemoveAll(substringToRemove).IgnoringCase();

    Assert.AreEqual(", world!", transformed);
}
```
