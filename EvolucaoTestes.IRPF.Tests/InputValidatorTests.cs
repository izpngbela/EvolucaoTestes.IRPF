using Xunit;
using EvolucaoTestes.IRPF;

namespace EvolucaoTestes.IRPF.Tests;

public class InputValidatorTests
{
    [Fact]
    public void TryParseNumeroContribuintes_Deve_Retornar_True_Para_Numero_Valido()
    {
        string input = "5";

        bool resultado = InputValidator.TryParseNumeroContribuintes(input, out int numero);

        Assert.True(resultado);
        Assert.Equal(5, numero);
    }

    [Fact]
    public void TryParseNumeroContribuintes_Deve_Retornar_False_Para_Numero_Zero()
    {
        string input = "0";

        bool resultado = InputValidator.TryParseNumeroContribuintes(input, out int numero);

        Assert.False(resultado);
    }

    [Fact]
    public void TryParseNumeroContribuintes_Deve_Retornar_False_Para_Numero_Negativo()
    {
        string input = "-5";

        bool resultado = InputValidator.TryParseNumeroContribuintes(input, out int numero);

        Assert.False(resultado);
    }

    [Fact]
    public void TryParseNumeroContribuintes_Deve_Retornar_False_Para_Texto_Invalido()
    {
        string input = "abc";

        bool resultado = InputValidator.TryParseNumeroContribuintes(input, out int numero);

        Assert.False(resultado);
    }

    [Fact]
    public void TryParseSalario_Deve_Retornar_True_Para_Salario_Valido()
    {
        string input = "2500.50";

        bool resultado = InputValidator.TryParseSalario(input, out decimal salario);

        Assert.True(resultado);
        Assert.Equal(2500.50m, salario);
    }

    [Fact]
    public void TryParseSalario_Deve_Retornar_True_Para_Salario_Zero()
    {
        string input = "0";

        bool resultado = InputValidator.TryParseSalario(input, out decimal salario);

        Assert.True(resultado);
        Assert.Equal(0m, salario);
    }

    [Fact]
    public void TryParseSalario_Deve_Retornar_False_Para_Salario_Negativo()
    {
        string input = "-1000";

        bool resultado = InputValidator.TryParseSalario(input, out decimal salario);

        Assert.False(resultado);
    }

    [Fact]
    public void TryParseSalario_Deve_Retornar_False_Para_Texto_Invalido()
    {
        string input = "texto";

        bool resultado = InputValidator.TryParseSalario(input, out decimal salario);

        Assert.False(resultado);
    }

    [Fact]
    public void ValidarNome_Deve_Retornar_True_Para_Nome_Valido()
    {
        string nome = "Izabela Santos";

        bool resultado = InputValidator.ValidarNome(nome);

        Assert.True(resultado);
    }

    [Fact]
    public void ValidarNome_Deve_Retornar_False_Para_Nome_Vazio()
    {
        string nome = "";

        bool resultado = InputValidator.ValidarNome(nome);

        Assert.False(resultado);
    }

    [Fact]
    public void ValidarNome_Deve_Retornar_False_Para_Nome_Null()
    {
        string nome = null;

        bool resultado = InputValidator.ValidarNome(nome);

        Assert.False(resultado);
    }

    [Fact]
    public void ValidarNome_Deve_Retornar_False_Para_Nome_Apenas_Espacos()
    {
        string nome = "   ";

        bool resultado = InputValidator.ValidarNome(nome);

        Assert.False(resultado);
    }
}
