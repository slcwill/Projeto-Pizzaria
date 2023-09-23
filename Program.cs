using ProjetoPizzaria.Models;

Console.WriteLine("Olá seja bem-vindo(a) a Pizzaria:)\n");

Console.WriteLine("PRESSIONE QUALQUER TECLA PARA CONTINUAR");
Console.ReadKey();

int opcao;

static void Menu()
{
        Console.Clear();
        Console.WriteLine("ESCOLHA UMA OPÇÃO: ");
        Console.WriteLine("1 - ADICIONAR PIZZA");
        Console.WriteLine("2 - LISTAR AS PIZZAS");
        Console.WriteLine("3 - CRIAR NOVO PEDIDO");
        Console.WriteLine("4 - LISTAR PEDIDOS");
        Console.WriteLine("5 - REALIZAR PAGAMENTO");
        Console.WriteLine("0 - SAIR\n");
        Console.WriteLine("DIGITE SUA OPÇÃO: ");
}

do
{
    Menu();
    opcao = int.Parse(Console.ReadLine()); 

    switch (opcao)
    {
        case 1:
                Pizza.AdicionarPizza();
        break;
        case 2:
                Pizza.ListarPizza();
        break;
        case 3:
                Pedido.CriarPedido();
        break;
        case 4:
                Pedido.ListarPedidos();
        break;
        case 5:
                Pedido.RealizarPagamento();
        break;
    }

} while (opcao != 0);