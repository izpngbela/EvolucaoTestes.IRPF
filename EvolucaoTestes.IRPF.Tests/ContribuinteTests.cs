using Xunit;
using EvolucaoTestes.IRPF;

namespace EvolucaoTestes.IRPF.Tests;

public class ContribuinteTests
{
    [Fact]
    public void Contribuinte_Deve_Calcular_Desconto_Automaticamente()
    {
        var contribuinte = new Contribuinte("João Silva", 2000m);

        decimal descontoEsperado = 2000m * 0.075m - 142.80m;
        Assert.Equal(descontoEsperado, contribuinte.Desconto);
    }

    [Fact]
    public void Contribuinte_Deve_Calcular_Salario_Liquido_Automaticamente()
    {
        var contribuinte = new Contribuinte("Maria Santos", 5000m);

        decimal descontoEsperado = 5000m * 0.275m - 869.36m;
        decimal salarioLiquidoEsperado = 5000m - descontoEsperado;
        Assert.Equal(salarioLiquidoEsperado, contribuinte.SalarioLiquido);
    }

    [Fact]
    public void Contribuinte_Com_Salario_Isento_Deve_Ter_Desconto_Zero()
    {
        var contribuinte = new Contribuinte("Pedro Costa", 1500m);

        Assert.Equal(0m, contribuinte.Desconto);
        Assert.Equal(1500m, contribuinte.SalarioLiquido);
    }

    [Fact]
    public void Contribuinte_Deve_Armazenar_Nome_Corretamente()
    {
        var contribuinte = new Contribuinte("Ana Paula", 3000m);

        Assert.Equal("Ana Paula", contribuinte.Nome);
    }

    [Fact]
    public void Contribuinte_Deve_Armazenar_Salario_Bruto_Corretamente()
    {
        var contribuinte = new Contribuinte("Carlos Eduardo", 4500m);

        Assert.Equal(4500m, contribuinte.SalarioBruto);
    }

    [Fact]
    public void Contribuinte_No_Limite_Primeira_Faixa_Deve_Ter_Desconto_Zero()
    {
        var contribuinte = new Contribuinte("Teste", 1903.98m);

        Assert.Equal(0m, contribuinte.Desconto);
    }

    [Fact]
    public void Contribuinte_Na_Segunda_Faixa_Deve_Calcular_Corretamente()
    {
        decimal salario = 2500m;
        decimal descontoEsperado = salario * 0.075m - 142.80m;

        var contribuinte = new Contribuinte("Teste", salario);

        Assert.Equal(descontoEsperado, contribuinte.Desconto);
        Assert.Equal(salario - descontoEsperado, contribuinte.SalarioLiquido);
    }

    [Fact]
    public void Contribuinte_Na_Terceira_Faixa_Deve_Calcular_Corretamente()
    {
        decimal salario = 3500m;
        decimal descontoEsperado = salario * 0.15m - 354.80m;

        var contribuinte = new Contribuinte("Teste", salario);

        Assert.Equal(descontoEsperado, contribuinte.Desconto);
        Assert.Equal(salario - descontoEsperado, contribuinte.SalarioLiquido);
    }

    [Fact]
    public void Contribuinte_Na_Quarta_Faixa_Deve_Calcular_Corretamente()
    {
        decimal salario = 4000m;
        decimal descontoEsperado = salario * 0.225m - 636.13m;

        var contribuinte = new Contribuinte("Teste", salario);

        Assert.Equal(descontoEsperado, contribuinte.Desconto);
        Assert.Equal(salario - descontoEsperado, contribuinte.SalarioLiquido);
    }

    [Fact]
    public void Contribuinte_Na_Quinta_Faixa_Deve_Calcular_Corretamente()
    {
        decimal salario = 10000m;
        decimal descontoEsperado = salario * 0.275m - 869.36m;

        var contribuinte = new Contribuinte("Teste", salario);

        Assert.Equal(descontoEsperado, contribuinte.Desconto);
        Assert.Equal(salario - descontoEsperado, contribuinte.SalarioLiquido);
    }
}
