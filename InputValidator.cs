namespace EvolucaoTestes.IRPF;

public static class InputValidator
{
    public static bool TryParseNumeroContribuintes(string input, out int numero)
    {
        return int.TryParse(input, out numero) && numero > 0;
    }

    public static bool TryParseSalario(string input, out decimal salario)
    {
        //Valida se o texto pode ser convertido para decimal E valida se não é negativo
        return decimal.TryParse(input, out salario) && salario >= 0;
    }

    public static bool ValidarNome(string nome)
    {
        //Se o nome não é nulo, vazio ou só espaços em branco
        return !string.IsNullOrWhiteSpace(nome);
    }
}
