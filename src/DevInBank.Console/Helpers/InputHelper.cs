using DevInBank.classes.Models;

public class InputHelper
{
    public static decimal ObterValorDecimal()
    {
        decimal valor = 0;
        bool valorInformadoValido = false;

        while (!valorInformadoValido)
        {
            var valorDigitadoString = Console.ReadLine();
            valorInformadoValido = decimal.TryParse(valorDigitadoString, out valor);

            if (!valorInformadoValido)
            {
                Console.WriteLine("Valor informado não é válido. Tente de novo.");
                continue;
            }
        }

        return valor;
    }

    public static float ObterValorFloat()
    {
        float valor = 0;
        var valorInformadoValido = false;

        while (!valorInformadoValido)
        {
            var valorDigitadoString = Console.ReadLine();
            valorInformadoValido = float.TryParse(valorDigitadoString, out valor);

            if (!valorInformadoValido)
            {
                Console.WriteLine("Valor informado não é válido. Tente de novo.");
                continue;
            }
        }

        return valor;
    }

    public static int ObterValorInt()
    {
        int valor = 0;
        var valorInformadoValido = false;

        while (!valorInformadoValido)
        {
            var valorDigitadoString = Console.ReadLine();
            valorInformadoValido = int.TryParse(valorDigitadoString, out valor);

            if (!valorInformadoValido)
            {
                Console.WriteLine("Valor informado não é válido. Tente de novo.");
                continue;
            }
        }

        return valor;
    }

    public static long ObterCpfValido()
    {

        long valorCpf = 0;
        var valorInformadoValido = false;

        while (!valorInformadoValido)
        {          
            var valorDigitadoString = Console.ReadLine();
            valorInformadoValido = long.TryParse(valorDigitadoString, out valorCpf) && valorDigitadoString.Length == 11;

            if (!valorInformadoValido)
            {
                Console.WriteLine("Valor informado não é válido. Tente de novo.");
                continue;
            }
        }
        return valorCpf;
    }
}