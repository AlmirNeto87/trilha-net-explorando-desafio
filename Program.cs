using System.Text;
using DesafioProjetoHospedagem.Models;

Console.OutputEncoding = Encoding.UTF8;

//// Cria os modelos de hóspedes e cadastra na lista de hóspedes
//List<Pessoa> listaHospedes = new List<Pessoa>();

//Pessoa p1 = new Pessoa(nome: "Hóspede 1");
//Pessoa p2 = new Pessoa(nome: "Hóspede 2");

//listaHospedes.Add(p1);
//listaHospedes.Add(p2);

//// Cria a suíte
//Suite suite = new Suite(tipoSuite: "Premium", capacidade: 2, valorDiaria: 30);

//// Cria uma nova reserva, passando a suíte e os hóspedes
//Reserva reserva = new Reserva(diasReservados: 5);
//reserva.CadastrarSuite(suite);
//reserva.CadastrarHospedes(listaHospedes);

//// Exibe a quantidade de hóspedes e o valor da diária
//Console.WriteLine($"Hóspedes: {reserva.ObterQuantidadeHospedes()}");
//Console.WriteLine($"Valor diária: {reserva.CalcularValorDiaria()}");


bool continuar = true;
List<Pessoa> listaHospedes = new List<Pessoa>();
List<Suite> listaSuites = new List<Suite>();
List<Reserva> listaReservas = new List<Reserva>();

while (continuar)
{
    Console.WriteLine("********************************");
    Console.WriteLine("Bem vindo ao sistema de Reservas do Hotel");
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
            listaHospedes.Add(novoHospede);
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
            listaSuites.Add(novaSuite);
            break;

        case "3":
            try
            {

                Console.WriteLine("Digite a quantidade de dias para a reserva:");
                int diasReservados = int.Parse(Console.ReadLine());
                Reserva reserva = new Reserva(diasReservados);

                Console.WriteLine("Escolha uma suíte cadastrada:");
                for (int i = 0; i < listaSuites.Count; i++)
                {
                    Console.WriteLine($"{i + 1} - {listaSuites[i].TipoSuite} (Capacidade: {listaSuites[i].Capacidade}, Valor Diária: {listaSuites[i].ValorDiaria})");
                }
                int escolhaSuite = int.Parse(Console.ReadLine());
                Suite suiteEscolhida = listaSuites[escolhaSuite - 1];
                reserva.CadastrarSuite(suiteEscolhida);

                // Lista local de hóspedes da reserva
                List<Pessoa> hospedesNaReserva = new List<Pessoa>();

                while (true)
                {
                    Console.WriteLine("Digite o número do hóspede para adicionar à reserva (ou 0 para finalizar):");
                    for (int i = 0; i < listaHospedes.Count; i++)
                    {
                        Console.WriteLine($"{i + 1} - {listaHospedes[i].Nome}");
                    }

                    int escolhaHospede = int.Parse(Console.ReadLine());

                    if (escolhaHospede == 0)
                    {
                        break;
                    }

                    if (escolhaHospede < 1 || escolhaHospede > listaHospedes.Count)
                    {
                        Console.WriteLine("Opção inválida. Tente novamente.");
                        continue;
                    }

                    Pessoa hospedeEscolhido = listaHospedes[escolhaHospede - 1];

                    if (hospedesNaReserva.Contains(hospedeEscolhido))
                    {
                        Console.WriteLine("Hóspede já adicionado à reserva. Tente novamente.");
                        continue;
                    }

                    // Verificação de capacidade da suíte
                    if (hospedesNaReserva.Count >= suiteEscolhida.Capacidade)
                    {
                        Console.WriteLine("A suíte já atingiu a capacidade máxima de hóspedes.");
                        break;
                    }

                    hospedesNaReserva.Add(hospedeEscolhido);
                    Console.WriteLine($"Hóspede {hospedeEscolhido.Nome} adicionado à reserva.");
                }

                reserva.CadastrarHospedes(hospedesNaReserva);
                Console.WriteLine("Reserva feita com sucesso!");
                listaReservas.Add(reserva);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Erro ao fazer reserva: {ex.Message}");
            }


            break;

        case "4":

            Console.WriteLine("Hóspedes na Reserva:");
            for (var index = 0; index < listaReservas.Count; index++)
            {
                Console.WriteLine($"Reserva {index + 1}:");
                foreach (var hospede in listaReservas[index].Hospedes)
                {
                    Console.WriteLine($"- {hospede.Nome}");
                }
                Console.WriteLine();
            }
            break;

        case "5":

            Console.WriteLine("Valores das listaReservas:");
            for (var index = 0; index < listaReservas.Count; index++)
            {
                Console.WriteLine($"Reserva {index + 1}:");
                Console.WriteLine($"Reserva de {listaReservas[index].DiasReservados} dias na suíte {listaReservas[index].Suite.TipoSuite}: R$ {listaReservas[index].CalcularValorDiaria()}");
                Console.WriteLine();
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
    Console.WriteLine();
}
