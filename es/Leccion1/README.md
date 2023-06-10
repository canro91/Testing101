# Lección 1: Escribe tus primeros units tests

Para aprender mejor acerca del unit testing, escribe algunos units tests para Stringie, una librería para transformar cadenas. Encontrarás una solución de Stringie [aquí](../../Lesson1/Stringie).

Los desarrolladores de Stringie escucharon acerca del unit testing y escribieron algo parecido a un unit test. Escribieron un proyecto de consola, para validar un solo método. Echa un vistazo a `TestProject` en la solución de Stringie, para revisar qué hicieron.

Tu misión Jim, si decides aceptarla, es escribir al menos tres unit tests para uno de los métodos de Stringie. Encontrarás las instrucciones a continuación junto con la lista de los métodos de Stringie. Este mensaje se autodestruirá en cinco segundos. Buena suerte, Jim.

### Instrucciones

1. Clona este repositorio 
2. Crea un proyecto de unit testing 
	* Utiliza un nombre apropiado
3. Agrega Stringie como proyecto de referencia a tu proyecto de testing
4. Elige uno de los métodos de Stringie 
	* `Insert`
	* `Remove`
	* `RemoveVowels`
	* `RemoveChars`
	* `IsEmpty`, `OrWhiteSpace`
	* `IndexesOf`
5. Escribe por lo menos tres unit tests para el método que elegiste
	* Usa un nombre apropiado para tus archivos de testing
	* Sigue una convención de nombres: una oración, PuntoDeEntrada_Escenario_Resultado, DadoCuandoEntonces
	* Sigue Arrange/Act/Assert
	* Elige la cadena más sencilla para hacer el test 
	* Piensa en casos particulares 
		* Cadenas vacías 
		* Posiciones fuera de la longitud de una cadena 
		* Subcadenas repetidas 
	* Usa métodos de aserción apropiados
6. (opcional) Usa una librería de aserción como [FluentAssertions](https://fluentassertions.com/introduction) o [Shouldly](https://github.com/shouldly/shouldly) para escribir tus aserciones.

### Stringie

Stringie es una librería con un amplio conjunto de utilidades para transformar cadenas usando una interface "fluent".

### Ejemplos

#### Insertar

Algo sencillo para comenzar:

```csharp
string transformed = "<-- some string will be inserted here".Insert("I am inserted!");
// "I am inserted!<-- some string will be inserted here"
```

Cambia la posición:

```csharp
string transformed = "Some string will be inserted here -->".Insert("I am inserted!").To(The.End);
// "Some string will be inserted here -->I am inserted!"
```

Y simplemente coloca algo en la posición deseada:

```csharp
string transformed = "Start of the sentence <-- some string will be inserted here".Insert("I am inserted!").At(22);
// "Start of the sentence I am inserted!<-- some string will be inserted here"
```

Combinando marcadores:

```csharp
string transformed = "MARKER, another maRKer and... marker <-- some string will be inserted here"
                      .Insert("I am inserted!").After("marker ");
// "MARKER, another maRKer and... marker I am inserted!<-- some string will be inserted here"
```

Incluso ignorando mayúsculas y minúsculas:

```csharp
string transformed = "Marker1, another maRKer2 and... marker <-- some string will be inserted here"
                     .Insert("I am inserted").After("MARKER ").IgnoringCase();
// "Marker1, another maRKer2 and... marker I am inserted<-- some string will be inserted here"
```

Aplicando todos los métodos:

```csharp
string t = "Some string will be inserted before this second 'some' word, but not before this 'some'"
           .Insert("I am inserted! ").Before(2, "some").IgnoringCase().From(The.Beginning);
t.Should().Be("Some string will be inserted before this second 'I am inserted! some' word, but not before this 'some'"
```

#### Eliminar

Eliminando todo:

```csharp
string transformed = "Some string".Remove();
// ""
```

O parte…

```csharp
string transformed = "THIS part of string will be removed".Remove("THIS");
// " part of string will be removed"
```

Por parte…

```csharp
string transformed = "THIS <- this string will be left, but this will be removed -> THIS".Remove("THIS").From(The.End);
// "THIS <- this string will be left, but this will be removed -> "
```

Contando marcadores:

```csharp
string transformed = "String will be removed ->TEST and this will be removed also ->TEST, except this ->TEST"
                     .Remove(2, "TEST");
// "String will be removed -> and this will be removed also ->, except this ->TEST"
```

O todos al mismo tiempo:

```csharp
string transformed = "TEST string will be removed from both sides TEST".RemoveAll("tESt").IgnoringCase();
// " string will be removed from both sides "
```

Empezando desde alguna posición:

```csharp
string transformed = "Some very long string".Remove().Starting(position: 7).From(The.End);
// " string"
```

O desde algún marcador:

```csharp
string transformed = "Some very VERY long string with very VERY long string at the end".Remove()
                     .To(The.EndOf, 3, of: "vERy").IgnoringCase().From(The.End);
// " long string with very VERY long string at the end"
```

Y comenzando desde algunas posiciones:

```csharp
string transformed = "Some very long string".Remove().Starting(position: 9).To(position: 0);
// "Slong string"
```

#### Elimina operaciones por caracteres

Creando efectos:

```csharp
string transformed = "Vowels will be removed from this string".RemoveVowels();
// "Vwls wll b rmvd frm ths strng"
```

O especificando caracteres explícitamente:

```csharp
string transformed = "Some very long string".RemoveChars('e', 'L', 'G').IgnoringCase();
// "Som vry on strin"
```

#### Utilidades

Un mejor enfoque para los bien conocidos:

```csharp
bool isEmpty = "".IsEmpty();
// true
```

Incluso para casos nulos:

```csharp
string sample = null;
bool isEmpty = sample.IsEmpty();
// true
```

Y continuando con los espacios en blanco:

```csharp
bool isEmptyOrWhiteSpace = "  ".IsEmpty().OrWhiteSpace();
// true
```

Ampliando métodos básicos:

```csharp
var indexes = "marker with another text marker and another text marker marker".IndexesOf("marker");
// 0, 25, 49, 56
```

Rompiendo las restricciones:

```csharp
var indexes = "Some text MARKER another text MarKer marker".IndexesOf("mArkEr").IgnoringCase();
// 10, 30, 37
```

Y cambiando el orden claramente:

```csharp
var indexes = "marker with another text marker and another text marker marker".IndexesOf("marker").From(The.End);
// 56, 49, 25, 0
```

## Créditos

Stringie fue creada sólo con propósitos de aprendizaje. Los métodos de Stringie fueron tomados de [FluentStrings](https://github.com/MSayfullin/FluentStrings).
