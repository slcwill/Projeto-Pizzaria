namespace ProjetoPizzaria.Models
{
    public class Pedido
    {
        public string Cliente { get; set; }
        public string Telefone { get; set; }
        public List<Pizza> EscolhaPizzas { get; set; } = new List<Pizza>();
        public double Total { get; set; }
        public static List<Pedido> ListaDePedidos = new List<Pedido>();
        public bool Pago { get; set; } = false;
        private static List<string> formasPagamento = new List<string>();
        private static double valorPagoTotal = 0;

        public static void CriarPedido()
        {

            Console.WriteLine("CRIAR PEDIDO");

            var Pedido = new Pedido();

            Console.WriteLine("Informe o nome do cliente?");
            Pedido.Cliente = Console.ReadLine();
            Console.WriteLine("Informe o telefone do cliente?");
            Pedido.Telefone = Console.ReadLine();

            int escolha, resposta;

            do
            {
                Console.WriteLine("ESCOLHA UMA PIZZA PARA ADICIONAR: ");

                for (int i = 0; i < Pizza.ListaDePizzas.Count; i++)
                {
                    Console.WriteLine($"{i + 1}: {Pizza.ListaDePizzas[i].Nome} - R$ {Pizza.ListaDePizzas[i].Preco:F2}");
                }

                escolha = int.Parse(Console.ReadLine());
                Pedido.EscolhaPizzas.Add(Pizza.ListaDePizzas[escolha - 1]);

                Console.WriteLine("Deseja acrescentar mais uma pizza? (1 - SIM | 2 - NÃO)");
                resposta = int.Parse(Console.ReadLine());

                } while (resposta == 1);

            double totalPedido = 0;

            foreach (var pizza in Pedido.EscolhaPizzas)
            {
                totalPedido += pizza.Preco;
            }

            Pedido.Total = totalPedido;

            Console.WriteLine("PEDIDO CRIADO COM SUCESSO");
            Console.WriteLine($"Total: R$ {totalPedido:F2}");
            ListaDePedidos.Add(Pedido);

            Console.WriteLine("PRESSIONE QUALQUER TECLA PARA SAIR.");
            Console.ReadKey();
            }

            public static void ListarPedidos()
            {
                Console.WriteLine("LISTA DE PEDIDOS: ");

                for (int i = 0; i < ListaDePedidos.Count; i++)
                {
                    Console.WriteLine($"Número do Pedido: {i + 1}");
                    Console.WriteLine("Cliente: " + ListaDePedidos[i].Cliente);
                    Console.WriteLine("Telefone: " + ListaDePedidos[i].Telefone);
                    Console.WriteLine("Pizzas do Pedido:");
                    foreach (var pizza in ListaDePedidos[i].EscolhaPizzas)
                {
                    Console.WriteLine($"Nome da pizza: {pizza.Nome}, Sabor da pizza: {pizza.Sabores}, Preço: R$ {pizza.Preco:F2}");
                }

                if (ListaDePedidos[i].Pago)
                Console.WriteLine("Status do pagamento: Pago");
                else
                Console.WriteLine("Status do pagamento: Pagamento pendente");

                Console.WriteLine();
            }
                Console.WriteLine("PRESSIONE QUALQUER TECLA PARA SAIR.");
                Console.ReadKey();
        }

        public static void RealizarPagamento()
        {
            Console.WriteLine("REALIZAR PAGAMENTO DO PEDIDO");
            Console.WriteLine("Qual o numero do pedido");

            for (int i = 0; i < ListaDePedidos.Count; i++)
            {
                if (!ListaDePedidos[i].Pago)
                    Console.WriteLine($"{i + 1}: Cliente - {ListaDePedidos[i].Cliente}, Total - R$ {ListaDePedidos[i].Total:F2}");
            }

            int numeroPedido;
            while (!int.TryParse(Console.ReadLine(), out numeroPedido) || numeroPedido < 1 || numeroPedido > ListaDePedidos.Count || ListaDePedidos[numeroPedido - 1].Pago)
            {
                Console.WriteLine("Número de pedido INVÁLIDO ou já foi PAGO. Por favor, tente novamente.");
            }   

            var pedidoSelecionado = ListaDePedidos[numeroPedido - 1];

            Console.WriteLine($"Pedido selecionado: Cliente - {pedidoSelecionado.Cliente}, Total - R$ {pedidoSelecionado.Total:F2}");

            Console.WriteLine("ESCOLHA A FORMA DE PAGAMENTO:");
            Console.WriteLine("1. Dinheiro");
            Console.WriteLine("2. Cartão de Débito");
            Console.WriteLine("3. Vale-Refeição");

            while (formasPagamento.Count < 2)
            {
                Console.Write("Opção: ");
                    if (int.TryParse(Console.ReadLine(), out int opcao))
                    {
                        string formaPagamento = "";
                        double valorPago = 0;

                    switch (opcao)
                    {
                        case 1:
                        formaPagamento = "Dinheiro";
                        Console.Write("Valor em dinheiro: R$ ");
                        while (!double.TryParse(Console.ReadLine(), out valorPago) || valorPago < 0)
                        {
                            Console.Write("Valor inválido. Por favor, insira um valor válido: R$ ");
                        }
                        break;

                        case 2:
                        formaPagamento = "Cartão de Débito";
                        valorPago = pedidoSelecionado.Total;
                        break;

                        case 3:
                        formaPagamento = "Vale-Refeição";
                        valorPago = pedidoSelecionado.Total;
                        break;

                        default:
                        Console.WriteLine("Opção inválida. Por favor, escolha uma opção válida.");
                        continue;
                    }

                    if (formasPagamento.Contains(formaPagamento))
                    {  
                        Console.WriteLine("Essa forma de pagamento já foi utilizada para este pedido.");
                        continue;
                    }

                    formasPagamento.Add(formaPagamento);
                    valorPagoTotal += valorPago;

                    Console.WriteLine("Forma de pagamento adicionada com sucesso!!!");
                    }
                    else
                    {
                        Console.WriteLine("Opção inválida. Por favor, escolha uma opção válida.");
                    }

                    Console.WriteLine("Deseja adicionar outra forma de pagamento? (1 - Sim | 2 - Não)");
                    if (int.TryParse(Console.ReadLine(), out int resposta) && resposta == 1)
                    {
                        Console.WriteLine("Escolha umas das opções");
                        Console.WriteLine("1. Dinheiro");
                        Console.WriteLine("2. Cartão de Débito");
                        Console.WriteLine("3. Vale-Refeição");

                        Console.ReadKey();
                    }
            }

            if (valorPagoTotal < pedidoSelecionado.Total)
            {
                Console.WriteLine("Pagamento insuficiente. Operação cancelada.");
                return;
            }

            else if (valorPagoTotal > pedidoSelecionado.Total && formasPagamento.Contains("Dinheiro"))
            {
                Console.WriteLine($"Troco a ser devolvido: R$ {valorPagoTotal - pedidoSelecionado.Total:F2}");
            }


            Console.WriteLine("Pagamento realizado com sucesso!!!");
            Console.ReadKey();

            pedidoSelecionado.Pago = true;
        }
    }
}