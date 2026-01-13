namespace EvolucaoTestes.IRPF;
using System;

class Program
{
    public static void Main(string[] args)
    {
        Console.WriteLine("Bem-vindo ao sistema de cálculo de IRPF!");
        Console.WriteLine();

        int numContribuintes = ObterNumeroContribuintes();

        for (int i = 1; i <= numContribuintes; i++)
        {
            Console.WriteLine($"\nContribuinte {i}:");

            string nome = ObterNome();
            decimal salarioBruto = ObterSalarioBruto();

            var contribuinte = new Contribuinte(nome, salarioBruto);
            ExibirResultado(contribuinte);
        }

        Console.WriteLine("\nCálculo finalizado.");
        Console.Write("Quer Continuar? (s/n) ");
        string? resposta = Console.ReadLine();
        if (resposta != null && resposta.Equals("s", StringComparison.OrdinalIgnoreCase))
        {
            Main(args); // Reinicia o programa
        }
    }

    private static int ObterNumeroContribuintes()
    {
        while (true)
        {
            Console.Write("Informe o número de contribuintes: ");
            string? input = Console.ReadLine();

            if (input != null && InputValidator.TryParseNumeroContribuintes(input, out int numero))
                return numero;

            Console.WriteLine("Valor inválido. Deve ser um número maior que zero.");
        }
    }

    private static string ObterNome()
    {
        while (true)
        {
            Console.Write("Nome: ");
            string? nome = Console.ReadLine();

            if (nome != null && InputValidator.ValidarNome(nome))
                return nome;

            Console.WriteLine("Nome inválido. Digite um nome válido.");
        }
    }

    private static decimal ObterSalarioBruto()
    {
        while (true)
        {
            Console.Write("Salário Bruto: ");
            string? input = Console.ReadLine();

            if (input != null && InputValidator.TryParseSalario(input, out decimal salario))
                return salario;

            Console.WriteLine("Valor inválido. O salário deve ser positivo.");
        }
    }

    private static void ExibirResultado(Contribuinte contribuinte)
    {
        Console.WriteLine("\n--- Resultado ---");
        Console.WriteLine($"Contribuinte: {contribuinte.Nome}");
        Console.WriteLine($"Salário Bruto: {contribuinte.SalarioBruto:C}");
        Console.WriteLine($"Desconto INSS: {contribuinte.DescontoINSS:C}");
        Console.WriteLine($"Desconto IRPF: {contribuinte.Desconto:C}");
        Console.WriteLine($"Salário Líquido: {contribuinte.SalarioLiquido:C}");
        Console.WriteLine("---------------------------");
    }
}