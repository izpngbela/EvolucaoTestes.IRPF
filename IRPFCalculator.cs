namespace EvolucaoTestes.IRPF;

public static class IRPFCalculator
{
    public static decimal CalcularDesconto(decimal salarioBruto)
    {
        decimal desconto;

        if (salarioBruto <= 1903.98m)
            desconto = 0;
        else if (salarioBruto <= 2826.65m)
            desconto = salarioBruto * 0.075m - 142.80m;
        else if (salarioBruto <= 3751.05m)
            desconto = salarioBruto * 0.15m - 354.80m;
        else if (salarioBruto <= 4664.68m)
            desconto = salarioBruto * 0.225m - 636.13m;
        else
            desconto = salarioBruto * 0.275m - 869.36m;

        return desconto < 0 ? 0 : desconto;
    }
}
