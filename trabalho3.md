# Enunciado do Trabalho 3

**Data limite de entrega: 20 de Dezembro**

**Objectivos**: Prática com Iteradores _lazy_ (_yield generators_), Genéricos e Delegates.

No seguimento do Trabalho 2 desenvolvido na biblioteca **Jsonzai** pretende-se
dar suporte a tipos genéricos e operações _lazy_.

**Todas as funcionalidades pedidas neste enunciado devem ser suportadas por ambas as classes
`JsonParser` e `JsonParsemit`**

## 1 - Sequências lazy

Implemente o método `IEnumerable SequenceFrom(string filename, Type klass)` que retorna uma 
sequência _lazy_ para os dados JSON contidos no ficheiro `filename`.
Este método assume que o ficheiro fonte tem como elemento raíz um _array_ JSON, dando excepção
caso o elemento raíz seja de outro tipo JSON, como por exemplo um objecto.

Realize um teste unitário que confirme o comportamento lazy deste método.
Por exemplo, actualize o conteúdo do ficheiro fonte após a obtenção da sequência dada por 
`SequenceFrom` e observe o novo conteúdo quando iterar sobre a sequência resultante.

## 2 - Genéricos

Adicione suporte para genéricos passando o método `Parse` a ter a assinatura `T Parse<T>(String source)`.
O método `SequenceFrom` também deve ser actualizado para suporte de genéricos.
Actualize os testes unitários em conformidade.

## 3- _delegates_

As configurações que são suportadas através do _custom attribute_ `JsonConvert` devem poder 
ser adicionadas agora também através de métodos públicos genéricos de `JsonParser`:
* Estes métodos devem ser genéricos em conformidade com o tipo das propriedades e dos conversores.
* A operação de conversão deve ser passada num parâmetro através de um _delegate_.

**Não modifique** a infra-estrutura desenvolvida no Trabalho 1 que suporta esta funcionalidade via
 _custom attribute_ `JsonConvert`. 
A mesma infra-estrutura deve ser partilhada e usada por ambos os meios de configuração de 
conversores.