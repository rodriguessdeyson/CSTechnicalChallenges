# Questions

### 1. Como você implementou a função que retorna a representação por extenso do número no desafio 1? Quais foram os principais desafios encontrados?

Para o primeiro desafio, a implementação foi realizada utilizando um mapeamento das principais representações por extenso. O valor inserido, limitado a casa dos milhões, é dividio e avaliado para identificação de unidade, dezenas, centenas e milhares recursivamente, sendo a maior complexidade os ajustes dos valores que são flexionados numericamente.

### 2. Como você lidou com a performance na implementação do desafio 2, considerando que o array pode ter até 1 milhão de números?

O algorítmo foi implementado para que um vetor, acima de 10 mil elementos, tenha seus itens somados de forma paralela, utilizando mais threads. Isso permite o vetor ser divido em pedações *chuncks* para iterar paralelamente nesse conjunto. A implementação também utiliza uma técnica de acesso atómico com o intuito de se evitar condições de corrida. Sendo assim, o algorítmo permite uma soma de até 1 milhão de números inteiros com alto desempenho.
Esta implementação também foi realizada como um método extensão para o tipo long[], portanto, seguindo os principíos de *Open-Closed Principle* do SOLID.

### 3. Como você lidou com os possíveis erros de entrada na implementação do desafio 3, como uma divisão por zero ou uma expressão inválida?
Utilizando o algoritmo de Dijkstra, *Shunting Yard Algorithm*, para conversão de notação infixa para pósfixadas, pôde-se realizar algumas validações como formato incorreto da expressão e a divisão por zero. Nesses casos, o algorítmo gera uma exceção notificando argumento incorreto (FormatException) e divisão por zero (DivideByZeroException).

### 4. Como você implementou a função que remove objetos repetidos na implementação do desafio 4? Quais foram os principais desafios encontrados?
Para a avaliação de uma lista de objetos tipo T, foi o utilizado o método .Distinct() do framework .NET, extensão LINQ. O método retorna uma nova lista, com os itens únicos. Para que esta funcionalidade seja efetiva para tipos personalizados, é necessário realizar a implementação do IIEquatable<T> na classe genérica utilizada, neste caso a classe UserMockModel(), e sobreescrevendo o método GetHashCode() para avaliação das propriedades que a compõem.

### Referências:

- Shunting Yard Algorithm - https://www.geeksforgeeks.org/java-program-to-implement-shunting-yard-algorithm/
- Array Sum - https://stackoverflow.com/questions/65777074/sum-of-the-element-of-an-array-in-parallel