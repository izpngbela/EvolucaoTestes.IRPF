namespace EvolucaoTestes.IRPF;
using System;

class Program
{
    public static void Main(string[] args)
    {
        Console.WriteLine("Bem-vindo ao sistema de cálculo de IRPF!");
        Console.WriteLine();

        Console.Write("Informe o número de contribuintes: ");
        string input = Console.ReadLine();

        if (!int.TryParse(input, out int numContribuintes) || numContribuintes <= 0)
        {
            Console.WriteLine("Valor inválido. Deve ser um número maior que zero.");
            return;
        }

        for (int i = 1; i <= numContribuintes; i++)
        {
            Console.WriteLine($"\nContribuinte {i}:");

            Console.Write("Nome: ");
            string nome = Console.ReadLine();

            Console.Write("Salário Bruto: ");
            string salarioInput = Console.ReadLine();

            if (!decimal.TryParse(salarioInput, out decimal salarioBruto) || salarioBruto < 0)
            {
                Console.WriteLine("Valor inválido. O salário deve ser positivo.");
                i--;
                continue;
            }

            decimal desconto = IRPFCalculator.CalcularDesconto(salarioBruto);
            decimal salarioLiquido = salarioBruto - desconto;

            Console.WriteLine("\n--- Resultado ---");
            Console.WriteLine($"Contribuinte: {nome}");
            Console.WriteLine($"Salário Bruto: {salarioBruto:C}");
            Console.WriteLine($"Desconto IRPF: {desconto:C}");
            Console.WriteLine($"Salário Líquido: {salarioLiquido:C}");
            Console.WriteLine("---------------------------");
        }

        Console.WriteLine("\nCálculo finalizado.");
    }  

    // formula: desconto = salárioBruto * percentual da alíquota - valor da dedução
    public static decimal CalcularDescontoIRPF(decimal salarioBruto)
    {
        decimal desconto;

        if (salarioBruto <= 1903.99m)
            desconto = 0;
        else if (salarioBruto <= 2826.65m)
            desconto = salarioBruto * 0.075m - 142.80m;
        else if (salarioBruto <= 3751.05m)
            desconto = salarioBruto * 0.15m - 354.80m;
        else if (salarioBruto <= 4664.68m)
            desconto = salarioBruto * 0.225m - 636.13m;
        else
            desconto = salarioBruto * 0.275m - 869.36m;

        if (desconto < 0)
            desconto = 0;

        return desconto;
    }
}
