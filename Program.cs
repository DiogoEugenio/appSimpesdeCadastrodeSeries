using System;
namespace DIO.Series
{
    class Program
    {
        static SerieRepositorio repositorio = new SerieRepositorio();
        static void Main(string[] args)
        {
            string opcaoUsuario = ObeterOpcaoUsuario();

            while (opcaoUsuario.ToUpper() != "X")
            {
                switch (opcaoUsuario)
                {
                    case "1":
                        ListarSerie();
                        break;
                    case "2":
                        InserirSerie();
                        break;
                    case "3":
                        AtualizarSerie();
                        break;
                    case "4":
                        ExluirSerie();
                        break;  
                    case "5":
                        VizualizarSerie();
                        break; 
                    case "C":
                        Console.Clear();
                        break;               
                            
                    default:
                        throw new ArgumentOutOfRangeException();        
                }
                opcaoUsuario = ObeterOpcaoUsuario();
                
            } 
            Console.WriteLine("Obrigado por utililizar nossos serviços");
            Console.WriteLine();
        }
        private static void ListarSerie()
        {
            Console.WriteLine("Listar Serie");
            var lista = repositorio.Lista();
            if(lista.Count == 0)
            {
                Console.WriteLine("Nenhuma serie Cadastrada");
                return;
            }
            foreach (var serie in lista)
            {
                var excluido = serie.RetornaExcluido();
                Console.WriteLine("#ID {0}: - {1} - {2}", serie.RetornaId(), serie.RetornaTitulo(), (excluido ? "*Excluido*" : ""));
            }
        }
        private static void InserirSerie()
        {
            Console.WriteLine("Inserir nova Serie");

            foreach (int i in Enum.GetValues(typeof(Genero)))
            {
                Console.WriteLine("{0}-{1}", i ,  Enum.GetName(typeof(Genero), i));
            }
            Console.Write("Digite O um Genero entra as opções acima: ");
            int entradaDeGenero = int.Parse(Console.ReadLine());

            Console.Write("Digite O Titulo da Serie: ");
            string entradaDeTitulo = Console.ReadLine();

            Console.Write("Digite o Ano de inicio da Serie: ");
            int entradaDoAno = int.Parse(Console.ReadLine());

            Console.Write("Digite a descrição da Serie: ");
            string entradaDeDesceicao = Console.ReadLine();

            Serie novaSerie = new Serie(id: repositorio.Proximo(),
                                        genero : (Genero)entradaDeGenero,
                                        titulo : entradaDeTitulo,
                                        ano: entradaDoAno,
                                        descricao: entradaDeDesceicao);
            repositorio.inserir(novaSerie);                            
        }
         private static void  AtualizarSerie()
        {
            Console.WriteLine("Digiteo id da serie");
            int indeceSerie = int.Parse(Console.ReadLine());

            foreach (int i in Enum.GetValues(typeof(Genero)))
            {
                Console.WriteLine("{0}-{1}", i ,  Enum.GetName(typeof(Genero), i));
            }
            Console.Write("Digite O um Gênero entra as opções acima: ");
            int entradaDeGenero = int.Parse(Console.ReadLine());

            Console.Write("Digite O Titulo da Serie: ");
            string entradaDeTitulo = Console.ReadLine();

            Console.Write("Digite o Ano de inicio da Serie: ");
            int entradaDoAno = int.Parse(Console.ReadLine());

            Console.Write("Digite a descrição da Serie: ");
            string entradaDeDesceicao = Console.ReadLine();
            
            Serie atualizarSerie = new Serie(id: indeceSerie,
                                        genero : (Genero)entradaDeGenero,
                                        titulo : entradaDeTitulo,
                                        ano: entradaDoAno,
                                        descricao: entradaDeDesceicao);
            repositorio.Atualizar(indeceSerie, atualizarSerie);                           
        }
        private static void ExluirSerie()
        {
            Console.WriteLine("Digite o ID da serie: ");
            int indeceSerie = int.Parse(Console.ReadLine());

            repositorio.Exclui(indeceSerie);

        }
         private static void  VizualizarSerie()
        {
            Console.WriteLine("Digite o ID da serie: ");
            int indeceSerie = int.Parse(Console.ReadLine());

            var serie = repositorio.RetornarPorId(indeceSerie);

            Console.WriteLine(serie);

        }
        private static string ObeterOpcaoUsuario()
        {
            Console.WriteLine();
            Console.WriteLine("DIO series!");
            Console.WriteLine("Escolha uma opção a baixo...");

            Console.WriteLine("1- Lista de Series");
            Console.WriteLine("2- Inserir nova serie");
            Console.WriteLine("3- Atualizar Serie");
            Console.WriteLine("4- Excuir Serie");
            Console.WriteLine("5- Visualizar Serie");
            Console.WriteLine("C- Limpar tela");
            Console.WriteLine("X- Sair");
            Console.WriteLine();
            
            string opcaoUsuario = Console.ReadLine(). ToUpper();
            Console.WriteLine();
            return opcaoUsuario;
        }
    }
}