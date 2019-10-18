# Enunciado do Trabalho 2

**Data limite de entrega: 11 de Novembro**

**Objectivos**: Análise e manipulação programática de código intermédio com API
de `System.Reflection.Emit`.

No seguimento do Trabalho 1 desenvolvido na biblioteca **Jsonzai** pretende-se
desenvolver uma nova classe `JsonParsemit` com o mesmo comportamento de
`JsonParser`, mas que **NÃO usa reflexão na atribuição de valores às
propriedades**. Note, que **continuará a ser usada reflexão na leitura** da
_metadata_, deixando apenas de ser usada reflexão em operações como
`<property>.SetValue(…)`.  A atribuição de valores a propriedades passa a ser
realizada directamente com base em código IL emitido em tempo de execução
através da API de `System.Reflection.Emit`. 

Para tal, `JsonParsemit` deve gerar em tempo de execução
implementações de classes, em que **cada classe** tem a capacidade de fazer a
**atribuição de um valor a uma determinada propriedade**.

Além de testes unitários que validem o correcto funcionamento de `JsonParsemit`
implemente também uma aplicação consola num outro projecto **JsonzaiBenchmark**
para comparar o desempenho do método `Parse()` entre as classes `JsonParsemit` e
`JsonParser`.

Para as medições de desempenho **use a abordagem apresentada nas aulas**
(**atenção que testes de desempenho não são testes unitários**). Registe e
comente os desempenhos obtidos entre as duas abordagens. 

## Abordagem de desenvolvimento de `JsonParsemit`

Como suporte ao desenvolvimento de `JsonParsemit` deve usar as ferramentas:
  * `ildasm`
  * `peverify`

Deve desenvolver em C# uma classe _dummy_ num projecto aparte com uma
implementação semelhante aquela que pretende que seja gerada através da API de
`System.Reflection.Emit`. 
Compile a classe _dummy_ e use a ferramenta `ildasm` para visualizar as instruções
IL que servem de base ao que será emitido através da API de `System.Reflection.Emit`. 

Use a ferramenta `peverify` para despistar os erros/excepções ocorridas na utilização
das classes geradas.
Grave numa DLL as classes geradas pelo `JsonParsemit` e valide através da ferramenta 
`peverify` a correcção do código IL.