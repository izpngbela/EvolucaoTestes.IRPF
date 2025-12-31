namespace EvolucaoTestes.IRPF;

public class Contribuinte
{
    public string Nome { get; set; }
    public decimal SalarioBruto { get; set; }
    public decimal Desconto { get; private set; }
    public decimal SalarioLiquido { get; private set; }

    public Contribuinte(string nome, decimal salarioBruto)
    {
        Nome = nome;
        SalarioBruto = salarioBruto;
        CalcularImposto();
    }

    private void CalcularImposto()
    {
        Desconto = IRPFCalculator.CalcularDesconto(SalarioBruto);
        SalarioLiquido = SalarioBruto - Desconto;
    }
}
