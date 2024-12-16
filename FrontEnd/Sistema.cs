using Core._03_Entidades.DTO.Carrinhos;
using FrontEnd.UseCases;

namespace FrontEnd;
public class Sistema
{
    private static Usuario UsuarioLogado { get; set; }
    private readonly UsuarioUC _usuarioUC;
    private readonly ProdutoUC _produtoUC;
    private readonly CarrinhoUC _carrinhoUC;
    private readonly EnderecoUC _enderecoUC;
    private readonly VendaUC _vendaUC;

    public Sistema(HttpClient cliente)
    {
        _usuarioUC = new UsuarioUC(cliente);
        _produtoUC = new ProdutoUC(cliente);
        _carrinhoUC = new CarrinhoUC(cliente);
        _enderecoUC = new EnderecoUC(cliente);
        _vendaUC = new VendaUC(cliente);
    }

    public void IniciarSistema()
    {
        int resposta = -1;
        while (resposta != 0)
        {
            if (UsuarioLogado == null)
            {
                resposta = ExibirLogin();

                if (resposta == 1)
                {
                    FazerLogin();
                }
                else if (resposta == 2)
                {
                    Usuario usuario = CriarUsuario();
                    _usuarioUC.CadastrarUsuario(usuario);
                    Console.WriteLine("Cadastro realizado com sucesso.");
                }
                else if (resposta == 3)
                {
                    List<Usuario> usuarios = _usuarioUC.ListarUsuarios();
                    foreach (Usuario u in usuarios)
                    {
                        Console.WriteLine(u.ToString());
                    }
                }
            }
            else
            {
                ExibirMenuPrincipal();
            }
        }
    }

    public int ExibirLogin()
    {
        Console.WriteLine("--------- Acesso ao Sistema ---------");
        Console.WriteLine("1 - Entrar na conta");
        Console.WriteLine("2 - Criar uma nova conta");
        Console.WriteLine("3 - Visualizar usuários cadastrados");
        return int.Parse(Console.ReadLine());
    }

    public Usuario CriarUsuario()
    {
        Usuario usuario = new Usuario();
        Console.WriteLine("Informe seu nome: ");
        usuario.Nome = Console.ReadLine();
        Console.WriteLine("Informe seu nome de usuário: ");
        usuario.Username = Console.ReadLine();
        Console.WriteLine("Informe sua senha: ");
        usuario.Senha = Console.ReadLine();
        Console.WriteLine("Informe seu e-mail: ");
        usuario.Email = Console.ReadLine();
        return usuario;
    }

    public Produto CriarProduto()
    {
        Produto produto = new Produto();
        Console.WriteLine("Informe o nome do produto: ");
        produto.Nome = Console.ReadLine();
        Console.WriteLine("Informe o preço do produto: ");
        produto.Preco = double.Parse(Console.ReadLine());
        return produto;
    }

    public Endereco CriarEndereco()
    {
        Endereco endereco = new Endereco();
        Console.WriteLine("Informe a rua do endereço: ");
        endereco.Rua = Console.ReadLine();
        Console.WriteLine("Informe o bairro do endereço: ");
        endereco.Bairro = Console.ReadLine();
        Console.WriteLine("Informe o número da residência: ");
        endereco.Numero = int.Parse(Console.ReadLine());
        endereco.UsuarioId = UsuarioLogado.Id;
        return endereco;
    }

    public void FazerLogin()
    {
        Console.WriteLine("Digite seu nome de usuário: ");
        string username = Console.ReadLine();
        Console.WriteLine("Digite sua senha: ");
        string senha = Console.ReadLine();
        UsuarioLoginDTO usuDTO = new UsuarioLoginDTO
        {
            Username = username,
            Senha = senha
        };
        Usuario usuario = _usuarioUC.FazerLogin(usuDTO);
        if (usuario == null)
        {
            Console.WriteLine("Credenciais inválidas!");
        }
        else
        {
            UsuarioLogado = usuario;
        }
    }

    public void ExibirMenuPrincipal()
    {
        Console.WriteLine("1 - Visualizar Produtos");
        Console.WriteLine("2 - Cadastrar Novo Produto");
        Console.WriteLine("3 - Efetuar uma compra");
        Console.WriteLine("Escolha uma opção:");
        int resposta = int.Parse(Console.ReadLine());

        if (resposta == 1)
        {
            ListarProdutos();
        }
        else if (resposta == 2)
        {
            Produto produto = CriarProduto();
            _produtoUC.CadastrarProduto(produto);
            Console.WriteLine("Produto registrado com sucesso.");
        }
        else if (resposta == 3)
        {
            RealizarCompra();
        }
    }

    private void RealizarCompra()
    {
        int opcao = 1;
        while (opcao == 1)
        {
            ListarProdutos();
            Console.WriteLine("Digite o ID do produto desejado:");
            int produtoId = int.Parse(Console.ReadLine());
            Carrinho carrinho = new Carrinho
            {
                ProdutoId = produtoId,
                UsuarioId = UsuarioLogado.Id
            };
            _carrinhoUC.CadastrarCarrinho(carrinho);

            Console.WriteLine("Escolha uma das opções:" +
                "\n1 - Adicionar mais itens ao carrinho" +
                "\n2 - Finalizar compra");
            opcao = int.Parse(Console.ReadLine());
        }

        List<ReadCarrinhoDTO> carrinhosDTO = _carrinhoUC.ListarCarrinhoUsuarioLogado(UsuarioLogado.Id);
        foreach (ReadCarrinhoDTO car in carrinhosDTO)
        {
            Console.WriteLine(car.ToString());
        }

        RealizarEntrega();
    }

    private void RealizarEntrega()
    {
        int idEndereco = 0;
        Console.WriteLine("Selecione a forma de entrega: \n 1 - Retirada na loja \n 2 - Entrega no endereço");
        int alternativa = int.Parse(Console.ReadLine());
        if (alternativa == 1)
        {
            Console.WriteLine("Sua compra poderá ser retirada na loja dentro de 7 dias.");
        }
        else if (alternativa == 2)
        {
            Console.WriteLine("Escolha uma das opções: \n 1 - Visualizar Endereços cadastrados \n 2 - Cadastrar novo endereço");
            int opcao = int.Parse(Console.ReadLine());
            if (opcao == 1)
            {
                List<Endereco> enderecos = _enderecoUC.ListarEnderecosDoUsuario(UsuarioLogado.Id);
                foreach (Endereco end in enderecos)
                {
                    Console.WriteLine(end.ToString());
                }
                Console.WriteLine("Digite o ID do endereço para entrega:");
                idEndereco = int.Parse(Console.ReadLine());
            }
            else
            {
                Endereco endereco = CriarEndereco();
                endereco = _enderecoUC.CadastrarEndereco(endereco);
                idEndereco = endereco.Id;
            }
            FinalizarVenda(idEndereco);
        }
    }

    private void FinalizarVenda(int idEndereco)
    {
        Venda venda = CriarVenda(idEndereco);
        venda = _vendaUC.CadastrarVenda(venda);
        ReadVendaReciboDTO recibo = _vendaUC.BuscarVendaPorId(venda.Id);
        Console.WriteLine(recibo.ToString());
    }

    private Venda CriarVenda(int idEndereco)
    {
        Venda venda = new Venda();

        Console.WriteLine("Escolha o método de pagamento:" +
            "\n1 - PIX" +
            "\n2 - Débito" +
            "\n3 - Crédito");

        int opcaoSelecionada = int.Parse(Console.ReadLine());
        venda.MetodoPagamento = venda.GetMetodoPagamentoById(opcaoSelecionada);
        venda.EnderecoId = idEndereco;
        venda.ValorFinal = SomaValores();

        return venda;
    }

    public double SomaValores()
    {
        double valor = 0;
        List<ReadCarrinhoDTO> carrinhosDTO = _carrinhoUC.ListarCarrinhoUsuarioLogado(UsuarioLogado.Id);
        foreach (ReadCarrinhoDTO car in carrinhosDTO)
        {
            if (car.Produto != null)
            {
                valor += car.Produto.Preco;
            }
        }
        return valor;
    }

    private void ListarProdutos()
    {
        List<Produto> produtos = _produtoUC.ListarProduto();
        foreach (Produto produto in produtos)
        {
            Console.WriteLine(produto.ToString());
        }
    }
}
