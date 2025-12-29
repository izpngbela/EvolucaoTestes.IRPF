# Calculadora de IRPF - Projeto de Testes

## Descrição

Este projeto implementa uma calculadora de Imposto de Renda Pessoa Física (IRPF) com base nas faixas de tributação vigentes. O projeto foi desenvolvido com o objetivo de demonstrar boas práticas de desenvolvimento orientado a testes (TDD) utilizando .NET 8 e xUnit.

## Estrutura do Projeto

```
EvolucaoTestes.IRPF/
├── IRPFCalculator.cs           # Classe principal com lógica de cálculo
├── Program.cs                   # Programa console de exemplo
├── EvolucaoTestes.IRPF.csproj  # Arquivo de projeto principal
└── EvolucaoTestes.IRPF.Tests/  # Projeto de testes unitários
    ├── UnitTest1.cs             # Testes unitários
    └── EvolucaoTestes.IRPF.Tests.csproj
```

## Tecnologias Utilizadas

- **.NET 8.0** - Framework de desenvolvimento
- **C#** - Linguagem de programação
- **xUnit** - Framework de testes unitários
- **Visual Studio Code** - Editor de código

## Faixas de Tributação do IRPF

O cálculo do IRPF segue as seguintes faixas:

| Faixa Salarial (R$) | Alíquota | Parcela a Deduzir (R$) |
|---------------------|----------|------------------------|
| Até 1.903,98 | Isento | 0,00 |
| De 1.903,99 até 2.826,65 | 7,5% | 142,80 |
| De 2.826,66 até 3.751,05 | 15% | 354,80 |
| De 3.751,06 até 4.664,68 | 22,5% | 636,13 |
| Acima de 4.664,68 | 27,5% | 869,36 |

## Como Usar

### Pré-requisitos

- .NET 8.0 SDK instalado
- Visual Studio Code (opcional)

### Executar o Projeto

```bash
dotnet run
```

### Executar os Testes

Para rodar todos os testes:

```bash
dotnet test
```

Para rodar apenas os testes do projeto de testes:

```bash
cd EvolucaoTestes.IRPF.Tests
dotnet test
```

### Exemplo de Uso da Calculadora

```csharp
using EvolucaoTestes.IRPF;

decimal salario = 5000m;
decimal desconto = IRPFCalculator.CalcularDesconto(salario);
Console.WriteLine($"Desconto de IRPF: R$ {desconto:F2}");
```

## Testes Implementados

- ✅ **Deve_Retornar_Zero_Quando_Salario_For_Isento** - Verifica se salários até R$ 1.903,98 são isentos
- ✅ **Deve_Ser_Isento_No_Limite_Exato** - Valida o limite exato da isenção
- ✅ **Deve_Calcular_Desconto_Faixa_75** - Testa cálculo na faixa de 7,5%
- ✅ **Deve_Calcular_Desconto_Faixa_275** - Testa cálculo na faixa de 27,5%

## Comandos Úteis

```bash
# Restaurar pacotes
dotnet restore

# Compilar o projeto
dotnet build

# Limpar arquivos de compilação
dotnet clean

# Adicionar pacote NuGet
dotnet add package <nome-do-pacote>
```

## Estrutura de Testes

Os testes seguem o padrão AAA (Arrange-Act-Assert):

```csharp
[Fact]
public void Deve_Retornar_Zero_Quando_Salario_For_Isento()
{
    // Arrange - Preparação
    decimal salarioBruto = 1500.00m;
    
    // Act - Ação
    decimal desconto = IRPFCalculator.CalcularDesconto(salarioBruto);
    
    // Assert - Verificação
    Assert.Equal(0m, desconto);
}
```

## Autor

Projeto desenvolvido @izpngbela com implementação de testes unitários em C#.

## Licença

Este projeto é de uso educacional e livre para estudos.
