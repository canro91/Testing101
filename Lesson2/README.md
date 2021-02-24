# Lesson 2: Let's fix some tests

To avoid making common mistakes, let's fix some unit tests Stringie developers wrote. This time, they turned the Console project from lesson 1 into a real test project and wrote some unit tests. But, they forgot to follow naming conventions and make other mistakes along the way. You will find the solution with the tests they wrote, next to this file.

Your mission, Jim, should you decide to accept it, is to fix the unit test Stringie developers wrote. You will find the instructions to proceed and the list of Stringie methods below. This repo will self-destruct in five seconds. Good luck, Jim.

### How-to

1. Clone this repo
2. Does the project compile? Are all tests passing? If that's not the case, make them pass
3. Does the test project follow a naming convention?
  * Does the test project name have a `Tests` or `UnitTests` suffix?
4. Are the tests organized in the appropiate files? 
5. Do the test names follow a naming convention? For example: sentence, UnitOfWork_Scenario_Result, GivenWhenThen
6. Do the tests follow Arrange/Act/Assert?
	* Does the code inside each test separated with line breaks to show each part?
7. Do the tests use an Assertion library? If that's not the case, rewrite those test to use MsTests
8. Do the tests use the appropiate Assert methods? For example: `AreEqual`, `AreNull`, `IsTrue`
9. Do the tests have a single assertion? It that's not the case, use Parameterized tests
10. Do the assertions repeat the logic under test?
	
You can take a look at the README file from lesson 1 to check all the Stringie avialable methods.

### How to create Parameterized tests with MsTests

To write a parameterized test, follow these steps:

* Instead of using `TestMethod` attribute, use `DataTestMethod`
* Use a `DataRow` attribute for each set of test values
* Add the appropriate parameters to your test. One paramater for each value inside the `DataRow` attribute
* Use the input parameters in your tests to arrange, act or assert

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
