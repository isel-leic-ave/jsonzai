# Enunciado do Trabalho 1

**Data limite de entrega: 22 de Outubro**

Use como base do seu projecto a solução Visual Studio do repositório Jsonzai.

Pretende-se desenvolver a biblioteca **Jsonzai** para processamento de dados em
formato JSON (https://www.json.org/). Esta biblioteca disponibiliza uma classe
`JsonParser` que pode ser usada para transformação de uma _string_ JSON numa instância
de uma classe compatível (e.g. `Student`) conforme ilustrado no exemplo seguinte:

```csharp
string src = "{name: \"Ze Manel\", nr: 6512, group: 11}";
Student std = (Student) JsonParser.Parse(src, typeof(Student));
Assert.AreEqual("Ze Manel", std.Name);
Assert.AreEqual(6512, std.Nr);
Assert.AreEqual(11, std.Group);
```

A class `JsonParser` usa uma instância de uma classe auxiliar `JsonTokens` para 
percorrer os elementos da _String_ JSON fonte.
O algoritmo de `JsonParser` é recursivo, criando instâncias de classes ou arrays e 
preenchendo respectivamente os seus campos ou elementos com valores primitivos ou
instâncias de outras classes ou arrays e assim sucessivamente.
Ambas as classes são fornecidas na solução Visual Studio `Jsonzai`.

## Parte 1

Complete **apenas** os métodos `ParsePrimitive`, `FillObject` e `ParseArray` de modo a ter o
comportamento desejado e satisfazer os testes unitários disponibilizados na
solução Jsonzai. Pode adicionar novos métodos auxiliares.

A classe `JsonTokens` não deve ser modificada.

**Nota**: o nome das propriedades JSON pode ser definido indiferentemente em
maiúsculas ou minúsculas. A classe correspondente não pode ter propriedades com
nomes que se distingam entre si apenas por terem letras maiúsculas ou
minúsculas.

Implemente uma _cache_ de modo a que o trabalho de leitura de metadata via Replexão
não seja repetido. Por exemplo, no parsing de um array de `Student` as propriedades
a serem afectadas só devem ser procuradas 1 vez.

Utilize a abordagem de _cache_ também na parte 3.

## Parte 2

Implemente mais testes unitários incluindo por exemplo entidades de domínio como:

*  `Classroom` que agrega um conjunto de instâncias de `Student`
* `Account` com um saldo (_balance_) e um conjunto de movimentos de conta (_transactions_)
* Um outro exemplo ao seu critério.

Utilize uma biblioteca auxiliar (e.g. JSON.net, `JavaScriptSerializer`,
Newtonsoft ou outra) para transformar instâncias destas classes em Json e
posteriormente reconstrua essas instâncias usando a sua implementação de
`JsonParser`.

## Parte 3

Pretende-se que as propriedades da classe destino possam ter nomes distintos dos
nomes usados na representação em JSON. Por exemplo, uma propriedade em JSON pode
ter o nome `birth_date`  e em C# `BirthDate`. Para resolver a correspondência
entre propriedades de nome distinto implemente uma anotação `JsonProperty` que
possa ser usada sobre propriedades de uma classe em C# indicando o nome
correspondente em JSON (e.g. `[JsonProperty(“birth_date”)`]). Altere
`JsonParser` para implementar o comportamento especificado e valide com testes
unitários.

Algumas classes como `DateTime`, `Gui` ou `Uri` não podem ser inicializadas
através das suas propriedades. Para tal, deve disponibilizar uma anotação
`JsonConvert` que permita estabelecer de que forma o `JsonParser` deve
instanciar estas classes. Por exemplo uma propriedade `DueDate` do tipo
`DateTime` pode ter uma classe associada `JsonToDateTime` que sabe criar uma
instância de `DateTime` a partir da sua representação em _string_. Para tal a
propriedade `DueDate` pode indicar essa correspondência através da seguinte
anotação:

```csharp
[JsonConvert(typeof(JsonToDateTime))] DateTime DueDate { get; set; }
```

Implemente uma forma de poder associar através da anotação `JsonConvert` um
conversor para qualquer tipo de classe. `JsonParser` deve passar a ter em
consideração esta anotação na inicialização das respectivas propriedades.

Valide a sua implementação com testes unitários adicionais criando nas entidades
de domínio casos de propriedades de tipo `DateTime`, `Gui` e `Uri`.
