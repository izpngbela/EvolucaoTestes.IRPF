using Xunit;
using EvolucaoTestes.IRPF;

namespace EvolucaoTestes.IRPF.Tests;

public class INSSCalculatorTests
{
    [Fact]
    public void Deve_Calcular_INSS_Primeira_Faixa()
    {
        // Salário até 1412.00 = 7,5%
        decimal salarioBruto = 1412.00m;
        decimal inss = INSSCalculator.CalcularINSS(salarioBruto);
        decimal esperado = 1412.00m * 0.075m;
        Assert.Equal(esperado, inss);
    }

    [Fact]
    public void Deve_Calcular_INSS_Primeira_Faixa_Valor_Menor()
    {
        // Salário abaixo do limite = 7,5%
        decimal salarioBruto = 1000.00m;
        decimal inss = INSSCalculator.CalcularINSS(salarioBruto);
        decimal esperado = 1000.00m * 0.075m;
        Assert.Equal(esperado, inss);
    }

    [Fact]
    public void Deve_Calcular_INSS_Segunda_Faixa()
    {
        // Salário até 2666.68 = 7,5% sobre 1412 + 9% sobre o excedente
        decimal salarioBruto = 2666.68m;
        decimal inss = INSSCalculator.CalcularINSS(salarioBruto);
        decimal esperado = 1412.00m * 0.075m + (2666.68m - 1412.00m) * 0.09m;
        Assert.Equal(esperado, inss, 2); 
    }

    [Fact]
    public void Deve_Calcular_INSS_Terceira_Faixa()
    {
        // Salário até 4000.03 = progressivo com 12% no excedente
        decimal salarioBruto = 3500.00m;
        decimal inss = INSSCalculator.CalcularINSS(salarioBruto);
        decimal esperado = 1412.00m * 0.075m + 
                          (2666.68m - 1412.00m) * 0.09m + 
                          (3500.00m - 2666.68m) * 0.12m;
        Assert.Equal(esperado, inss, 2);
    }

    [Fact]
    public void Deve_Calcular_INSS_Quarta_Faixa()
    {
        // Salário até 7786.02 = progressivo com 14% no excedente
        decimal salarioBruto = 5000.00m;
        decimal inss = INSSCalculator.CalcularINSS(salarioBruto);
        decimal esperado = 1412.00m * 0.075m + 
                          (2666.68m - 1412.00m) * 0.09m + 
                          (4000.03m - 2666.68m) * 0.12m + 
                          (5000.00m - 4000.03m) * 0.14m;
        Assert.Equal(esperado, inss, 2);
    }

    [Fact]
    public void Deve_Aplicar_Teto_INSS()
    {
        // Salário acima de 7786.02 = valor máximo fixo (teto)
        decimal salarioBruto = 10000.00m;
        decimal inss = INSSCalculator.CalcularINSS(salarioBruto);
        decimal tetoINSS = 1412.00m * 0.075m + 
                           (2666.68m - 1412.00m) * 0.09m + 
                           (4000.03m - 2666.68m) * 0.12m + 
                           (7786.02m - 4000.03m) * 0.14m;
        Assert.Equal(tetoINSS, inss, 2);
    }

    [Fact]
    public void Deve_Aplicar_Teto_INSS_No_Limite_Exato()
    {
        // Salário exatamente no teto
        decimal salarioBruto = 7786.02m;
        decimal inss = INSSCalculator.CalcularINSS(salarioBruto);
        decimal esperado = 1412.00m * 0.075m + 
                          (2666.68m - 1412.00m) * 0.09m + 
                          (4000.03m - 2666.68m) * 0.12m + 
                          (7786.02m - 4000.03m) * 0.14m;
        Assert.Equal(esperado, inss, 2);
    }

    [Theory]
    [InlineData(1000.00, 75.00)]
    [InlineData(1412.00, 105.90)]
    [InlineData(2000.00, 158.82)]
    [InlineData(3000.00, 281.94)]
    [InlineData(5000.00, 461.98)]
    [InlineData(8000.00, 908.85)]
    public void Deve_Calcular_INSS_Para_Diversos_Salarios(decimal salarioBruto, decimal inssEsperado)
    {
        decimal inss = INSSCalculator.CalcularINSS(salarioBruto);
        Assert.Equal(inssEsperado, inss, 2);
    }
}
