using System.Text;
using DesafioProjetoHospedagem.Models;

Console.OutputEncoding = Encoding.UTF8;

//// Cria os modelos de hóspedes e cadastra na lista de hóspedes
//List<Pessoa> hospedes = new List<Pessoa>();

//Pessoa p1 = new Pessoa(nome: "Hóspede 1");
//Pessoa p2 = new Pessoa(nome: "Hóspede 2");

//hospedes.Add(p1);
//hospedes.Add(p2);

//// Cria a suíte
//Suite suite = new Suite(tipoSuite: "Premium", capacidade: 2, valorDiaria: 30);

//// Cria uma nova reserva, passando a suíte e os hóspedes
//Reserva reserva = new Reserva(diasReservados: 5);
//reserva.CadastrarSuite(suite);
//reserva.CadastrarHospedes(hospedes);

//// Exibe a quantidade de hóspedes e o valor da diária
//Console.WriteLine($"Hóspedes: {reserva.ObterQuantidadeHospedes()}");
//Console.WriteLine($"Valor diária: {reserva.CalcularValorDiaria()}");


bool continuar = true;
List<Pessoa> hospedes = new List<Pessoa>();
List<Suite> suites = new List<Suite>();
List<Reserva> reservas = new List<Reserva>();

while (continuar)
{
    Console.WriteLine("********************************");
    Console.WriteLine("Bem vindo ao sistema de reservas do Hotel");
    Console.WriteLine("********************************");
    Console.WriteLine("Escolha uma opção:");
    Console.WriteLine("1 - Cadastrar Hóspedes");
    Console.WriteLine("2 - Cadastrar Suíte");
    Console.WriteLine("3 - Fazer Reserva");
    Console.WriteLine("4 - Listar Hóspedes na Reserva");
    Console.WriteLine("5 - Exibir Valor da Reserva");
    Console.WriteLine("6 - Sair do Sistema");
    
    string opcao = Console.ReadLine();

    switch (opcao)
    {
        case "1":
            Console.WriteLine("Digite o nome do hóspede:");
            string nomeHospede = Console.ReadLine();
            Pessoa novoHospede = new Pessoa(nomeHospede);

            hospedes.Add(novoHospede);
            Console.WriteLine($"Hóspede {nomeHospede} cadastrado com sucesso!");
            break;
        case "2":
            Console.WriteLine("Digite o tipo da suíte:");
            string tipoSuite = Console.ReadLine();
            Console.WriteLine("Digite a capacidade da suíte:");
            int capacidadeSuite = int.Parse(Console.ReadLine());
            Console.WriteLine("Digite o valor da diária:");
            decimal valorDiaria = decimal.Parse(Console.ReadLine());
            Suite novaSuite = new Suite(tipoSuite, capacidadeSuite, valorDiaria);
            Console.WriteLine($"Suíte {tipoSuite} cadastrada com sucesso!");
            suites.Add(novaSuite);
            break;
        case "3":
            try
            {
                Console.WriteLine("Digite a quantidade de dias para a reserva:");
                int diasReservados = int.Parse(Console.ReadLine());
                Reserva reserva = new Reserva(diasReservados);
                reservas.Add(reserva);
                Console.WriteLine("Escolha uma suíte cadastrada:");
                for (int i = 0; i < suites.Count; i++)
                {
                    Console.WriteLine($"{i + 1} - {suites[i].TipoSuite} (Capacidade: {suites[i].Capacidade}, Valor Diária: {suites[i].ValorDiaria})");
                }
                int escolhaSuite = int.Parse(Console.ReadLine());
                Suite suiteEscolhida = suites[escolhaSuite - 1];
                reserva.CadastrarSuite(suiteEscolhida);
                reserva.CadastrarHospedes(hospedes);
                Console.WriteLine("Reserva feita com sucesso!");
                
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Erro ao fazer reserva: {ex.Message}");
            }
            break;
        case "4":
                Console.WriteLine("Hóspedes na Reserva:");
                foreach (var reserva in reservas)
                {
                    foreach (var hospede in reserva.Hospedes)
                    {
                        Console.WriteLine($"- {hospede.Nome}");
                    }
                }
            break;
        case "5":
        
            Console.WriteLine("Valores das Reservas:");
            foreach (var reserva in reservas)
            {
                Console.WriteLine($"Reserva de {reserva.DiasReservados} dias na suíte {reserva.Suite.TipoSuite}: R$ {reserva.CalcularValorDiaria()}");
            }

            break;
        case "6":

            continuar = false;
            Console.WriteLine("Saindo do sistema. Até logo!");
            break;

        default:
            Console.WriteLine("Opção inválida. Tente novamente.");
            break;
    }









}
