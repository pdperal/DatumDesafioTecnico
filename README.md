# DatumDesafioTecnico

### Desafio 
Implementar duas Web APIs separadas para calculo de Juros.
A primeira API retorna a taxa de juros fixa em 1% (ou 0.01). Já a segunda API recebe como parâmetro dois valores, sendo eles o tempo em meses e o valor inicial. É realizada uma chamada na primeira API para obter a taxa de juros e assim calcular o juros sobre um valor inicial, considerando o tempo.

Fórmula: Valor Final = Valor Inicial * (1 + juros) ^ Tempo

### Algoritmo utilizado
Existem diversas maneiras de atingir o mesmo objetivo, seja utilizando uma função do namespace Math (como o Math.Pow()), ou utilizando um loop para incrementar o tempo e realizar os cálculos necessários.
No meu caso, optei por utilizar uma função recursiva para realizar os cálculos ao invés de utilizar uma solução já pronta. 
Na função em questão há uma variável responsável por controlar o mês sendo calculado. O critério de saída da função é o mês de controle ser igual ao mês enviado por parâmetro na API.

### Como executar o projeto

Para executar os serviços é necessária a instalação do Docker. Após instalado, navegue até o diretório root do repositório (onde há o arquivo docker-compose) e execute os seguintes comandos no cmd/power shell:
- docker-compose build
  - Este comando irá buildar ambos projetos configurados, baixando também suas dependências externas.
  
Após finalizar o build, execute o seguinte comando:
- docker-compose up
  - Este comando irá levantar ambas as aplicações, cada uma rodando em seu contâiner específico em uma porta específica.


## Bibliotecas e ferramentas utilizadas
Abaixo estão listadas as bibliotecas externas utilizadas e seus motivos.

#### Fluent Validation
Para cálculo de juros, precisamos considerar que o tempo em meses não pode ser Zero ou inferior, o mesmo vale para o valor inicial.
Tendo isto em mente, o fluent validation atua como uma espécie de filter/middleware para as APIs, sendo possível configurar regras para validação das entidades e dados de entrada.
Exemplo implementado neste projeto:
``RuleFor(x => x.ValorInicial).GreaterThan(0).WithMessage("Valor inicial deve ser maior que Zero.");``

#### xUnit
Como o projeto em questão não possui muitas regras ou complexidade envolvida, a escolha por xUnit, NUnit ou o próprio MSTest fica a critério do desenvolvedor, visto que as três opções fornecem os mesmos recursos para o nível exigido neste desafio.
Por opção, utiliza o xUnit por ter familiaridade com a biblioteca.

### Moq
Para mockar os serviços e os retornos dos serviços no âmbito de testes unitários, utilizei a biblioteca Moq.

### docker-compose
Para orquestrar ambos os contâineres, utilizei o docker-compose. Uma ferramenta simples de utilizar (mas que me fez quebrar bastante a cabeça rsrsrs) que me permite buildar e levantar N serviços em conjunto.
