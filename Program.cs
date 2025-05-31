using System.Drawing;
using System.Globalization;
using System.Text;
using DesafioProjetoHospedagem.Models;

Console.OutputEncoding = Encoding.UTF8;
try
{
    // Cria os modelos de hóspedes e cadastra na lista de hóspedes
    
    RegraDesconto regraDesconto = new RegraDesconto(10,10m);
    List<Pessoa> hospedesPremium = new List<Pessoa>();
    List<Pessoa> hospedes = new List<Pessoa>();
    List<Pessoa> hospedes2 = new List<Pessoa>();

    Pessoa jose = new Pessoa(nome: "Jose da Silva Sauro");
    Pessoa fulano = new Pessoa(nome: "Fulana de Tal");

    Pessoa mariaGasolina = new Pessoa(nome: "Maria Gasolina");
    Pessoa mariaChuteira = new Pessoa(nome: "Maria Chuteira");
    Pessoa pedroCafundo = new Pessoa(nome: "Pedro do Cafundo dos Judas");
    Pessoa joaoTeimoso = new Pessoa(nome: "João da Silva Teimoso");
    Pessoa judasOOutro = new Pessoa(nome: "Judas o Outro");

    hospedesPremium.Add(jose);
    hospedesPremium.Add(fulano);

    hospedes.Add(pedroCafundo);
    hospedes.Add(joaoTeimoso);
    hospedes.Add(judasOOutro);

    // Cria a suíte
    Suite suitePremium = new Suite(tipoSuite: "Premium", capacidade: 3, valorDiaria: 80);
    Suite suiteNormal = new Suite(tipoSuite: "Normal", capacidade: 2, valorDiaria: 30);

    // Cria uma nova reserva, passando a suíte e os hóspedes
    Reserva premium = new Reserva(diasReservados: 5);
    premium.RegraDesconto = regraDesconto;
    premium.CadastrarSuite(suitePremium);
    premium.CadastrarHospedes(hospedesPremium);

    pulaLinha();
    mostrarTracos();
    exibeMensagem(premium, "1");
    exibeMensagemDesconto(premium.MensagemSobreDesconto());
    mesagemSucesso();
    mostrarTracos();
    pulaLinha();


    hospedes2.Add(mariaChuteira);
    hospedes2.Add(mariaGasolina);

    Reserva normal2 = new Reserva(diasReservados: 10);
    normal2.RegraDesconto = regraDesconto;
    normal2.CadastrarSuite(suiteNormal);
    normal2.CadastrarHospedes(hospedes2);
    pulaLinha();
    mostrarTracos();
    exibeMensagem(normal2, "2");
    exibeMensagemDesconto(normal2.MensagemSobreDesconto());
    mesagemSucesso();
    mostrarTracos();
    pulaLinha();

    Reserva normal = new Reserva(diasReservados: 5);
    normal.RegraDesconto = regraDesconto;
    normal.CadastrarSuite(suiteNormal);
    normal.CadastrarHospedes(hospedes);
    pulaLinha();
    mostrarTracos();
    exibeMensagem(normal, "3");
    exibeMensagemDesconto(normal.MensagemSobreDesconto());
    mesagemSucesso();
    mostrarTracos();
    pulaLinha();

}
catch (Exception Exception)
{
    mostrarTracos();
    Console.ForegroundColor = ConsoleColor.Red;
    Console.WriteLine("Houve um erro!");
    pulaLinha();    
    Console.WriteLine(Exception.Message);
    Console.ResetColor();
    mostrarTracos();
    
}


static void pulaLinha()
{
    Console.WriteLine("\n\n");
}

static void mostrarTracos()
{
    Console.WriteLine("=================================================================================================================================\n");
}

static void exibeMensagem(Reserva reserva, string numero)
{
    // Exibe a quantidade de hóspedes e o valor da diária
    var cultura = new CultureInfo("pt-BR");
    Console.WriteLine($"A quantidade de hóspedes da reserva {numero} é: {reserva.ObterQuantidadeHospedes()}");
    Console.WriteLine($"A suite é : {reserva.Suite.TipoSuite}");
    Console.WriteLine($"Valor diária: {reserva.CalcularValorDiaria().ToString("C", cultura)}\n");
}

static void mesagemSucesso()
{
    Console.ForegroundColor= ConsoleColor.Green;
    Console.WriteLine("Reserva realizada com sucesso!");
    Console.ResetColor();
}

static void exibeMensagemDesconto(string Mensagem)
{
    if (string.IsNullOrEmpty(Mensagem))
    {
        return;
    }
    Console.WriteLine(Mensagem);
}
