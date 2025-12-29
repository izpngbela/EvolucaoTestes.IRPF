using Xunit;
using EvolucaoTestes.IRPF;

namespace EvolucaoTestes.IRPF.Tests;

public class IRPFCalculatorTests
{
    [Fact]
    public void Deve_Retornar_Zero_Quando_Salario_For_Isento()
    {
        decimal salarioBruto = 1500.00m;
        decimal desconto = IRPFCalculator.CalcularDesconto(salarioBruto);
        Assert.Equal(0m, desconto);
    }

    [Fact]
    public void Deve_Ser_Isento_No_Limite_Exato()
    {
        decimal salario = 1903.99m;
        decimal desconto = IRPFCalculator.CalcularDesconto(salario);
        Assert.Equal(0m, desconto);
    }


    [Fact]
    public void Deve_Calcular_Desconto_Faixa_75()
    {
        decimal salario = 2000m;
        decimal desconto = IRPFCalculator.CalcularDesconto(salario);
        decimal esperado = salario * 0.075m - 142.80m;
        Assert.Equal(esperado, desconto);
    }

    [Fact]
    public void Deve_Calcular_Desconto_Faixa_275()
    {
        decimal salario = 5000m;
        decimal desconto = IRPFCalculator.CalcularDesconto(salario);
        Assert.Equal(salario * 0.275m - 869.36m, desconto);
    }

}
