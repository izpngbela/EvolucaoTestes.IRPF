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

            // Valida se o salário digitado é um número decimal válido e positivo; se não for, exibe erro e repete a entrada
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
        Console.ReadLine();
    }  

}
