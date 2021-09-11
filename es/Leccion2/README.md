# Lección 2: Corrige algunos tests

Para evitar errores comunes, corrige algunos unit tests que escribieron los desarrolladores de Stringie. Esta vez, convirtieron el proyecto de consola de la [lección 1](../Lesson1/README.md) en un proyecto real de testing, y escribieron algunos unit tests; pero olvidaron seguir una convención de nombres, entre otros errores. Encontrarás la solución con los tests que escribieron [aquí](../../Lesson2/Stringie). 

Tu misión Jim, si decides aceptarla, es corregir los unit test que los desarrolladores de Stringie escribieron erróneamente. Encontrarás las instrucciones a continuación. Este mensaje se autodestruirá en cinco segundos. Buena suerte, Jim.

### Instrucciones

1. Clona este repositorio
2. ¿el proyecto de pruebas compila? ¿Todos los test pasan la prueba? Si no es así, hazlos pasar
3. ¿el test sigue una convención de nombres?
	* ¿el nombre del proyecto de testing tiene sufijos como `Tests` o `UnitTests`?
4. ¿Los tests están organizados en los archivos apropiados?
5. ¿Los nombres de los tests siguen una convención de nombres? Por ejemplo: una oración, PuntoDeEntrada_Escenario_Resultado, DadoCuandoEntonces
6. ¿Los tests sigues Arrange/Act/Assert?
	* ¿El código de cada test está separado por saltos de línea para mostrar cada parte?
7. ¿Los tests usan una librería de aserción? Si no es así, reescribe esos tests para usar MSTest
8. ¿Los tests usas los métodos de aserción adecuados? Por ejemplo: `AreNull()` en lugar de `AreEqual()` con un valor nulo, `Assert.AreEqual()` en lugar de `IsTrue()` con una comparación 
9. ¿Los tests tienen una sola aserción por test? Si no es así, usa tests parametrizados
10. ¿Las aserciones repiten la lógica bajo prueba?

Para más ejemplos de errores al escribir unit tests, revisa [4 common mistakes when writing your first unit tests](https://canro91.github.io/2021/03/29/UnitTestingCommonMistakes/).

Puedes echar un vistazo al archivo README de la [lección 1](../Leccion1/README.md), para revisar todos los métodos de Stringie disponibles.

### Cómo crear tests parametrizados con MSTest

Para escribir un test parametrizado, sigue los pasos a continuación:

* En lugar de usar el atributo `[TestMethod]`, usa `[DataTestMethod]`
* Usa un atributo `[DataRow]` para cada conjunto de valores de prueba 
* Agrega los parámetros adecuados a tu test. Un parámetro para cada valor dentro del atributo `[DataRow]`
* Usa los parámetros de entrada en tus test para seguir Arrange/Act/Assert 

Por ejemplo,

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
