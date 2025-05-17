Console.Clear();

const decimal PrecoPrimeiraHora = 20, PrecoHoraPequeno = 10, PrecoHoraGrande = 20,
PrecoDiariaPequeno = 50, PrecoDiariaGrande = 80,
PrecoLavagemPequeno = 50, PrecoLavagemGrande = 100, tolerancia = 5;

double AdicionalValet = 0.2;

const int 
TempoDiaria = 5 * 60,
TempoPermanencia = 5,
MaxTempoPermanencia = 12 * 60;

int permanencia;
string tamanho;
bool lavagem, valet;
string P, G, S, N;

decimal parcialEstacionamento = 0;
decimal parcialValet = 0;
decimal parcialLavagem = 0;
decimal total = 0;

Console.WriteLine("--- Estacionamento ---");

Console.WriteLine("Tamanho do veículo (P/G)......:");
tamanho = Console.ReadLine()!.Trim().Substring(0, 1).ToUpper();

if (tamanho != "P" && tamanho != "G")
{

    Console.WriteLine("tamanho invalido");
    return;
}

Console.WriteLine("Tempo de permanência (min)...: ");
permanencia = Convert.ToInt32(Console.ReadLine());

if (TempoPermanencia <= 0 || TempoPermanencia > MaxTempoPermanencia)
{
    Console.WriteLine("Tempo de permanência inválido.");
    return;
}

Console.WriteLine("Serviço de valet (S/N)........:");
valet = Console.ReadLine()!.Trim().Substring(0, 1).ToUpper() == "S";

Console.WriteLine("Serviço de lavagem (S/N)......:");
lavagem = Console.ReadLine()!.Trim().Substring(0, 1).ToUpper() == "S";

if (TempoPermanencia >= TempoDiaria)
{
    if (tamanho == "P")
    {
        parcialEstacionamento = PrecoDiariaPequeno;
    }
    else
    {
        parcialEstacionamento = PrecoDiariaGrande;
    }

}
else
{
    int horasPermanencia = (int)(TempoPermanencia / 60);
    int minutosRestantes = TempoPermanencia % 60;

    if (minutosRestantes > TempoPermanencia)

    {
        horasPermanencia++;
    }

    parcialEstacionamento = PrecoPrimeiraHora;
    int horasAdicionais = horasPermanencia - 1;

    if (horasAdicionais > 0)
    {
        if (tamanho == "P")
        {
            parcialEstacionamento += horasAdicionais * PrecoHoraPequeno;
        }
        else
        {
            parcialEstacionamento += horasAdicionais * PrecoHoraGrande;
        }
    }
}
if (valet)
{
    if (tamanho == "P")
    {
        parcialLavagem += PrecoLavagemPequeno;
    }
    else
    {
        parcialLavagem += PrecoLavagemGrande;
    }
}

total = parcialEstacionamento + parcialValet + parcialLavagem;
Console.WriteLine($"\nEstacionamento..: {parcialEstacionamento,0:C}");

Console.WriteLine($"Valet...........: {parcialValet,0:C}");

Console.WriteLine($"Lavagem.........: {parcialLavagem,0:C}");

Console.WriteLine("--------------------------------");

Console.ForegroundColor = ConsoleColor.DarkBlue;
Console.WriteLine($"Total...........: {total,0:C}");
Console.ResetColor();