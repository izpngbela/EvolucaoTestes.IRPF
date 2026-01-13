

namespace EvolucaoTestes.IRPF;

public static class INSSCalculator
{
    // Cálculo do INSS com alíquotas progressivas
    public static decimal CalcularINSS(decimal salarioBruto)
    {
        decimal inss = 0;

        if (salarioBruto <= 1412.00m)
        {
            inss = salarioBruto * 0.075m;
        }
        else if (salarioBruto <= 2666.68m)
        {
            inss = 1412.00m * 0.075m + (salarioBruto - 1412.00m) * 0.09m;
        }
        else if (salarioBruto <= 4000.03m)
        {
            inss = 1412.00m * 0.075m + (2666.68m - 1412.00m) * 0.09m + (salarioBruto - 2666.68m) * 0.12m;
        }
        else if (salarioBruto <= 7786.02m)
        {
            inss = 1412.00m * 0.075m + (2666.68m - 1412.00m) * 0.09m + (4000.03m - 2666.68m) * 0.12m + (salarioBruto - 4000.03m) * 0.14m;
        }
        else
        {
            // Teto do INSS
            inss = 1412.00m * 0.075m + (2666.68m - 1412.00m) * 0.09m + (4000.03m - 2666.68m) * 0.12m + (7786.02m - 4000.03m) * 0.14m;
        }

        return inss;
    }
}