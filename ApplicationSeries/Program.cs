using System;
using System.Collections.Generic;


namespace ApplicationSeries
{
    class Program
    {
        static RepositorioSeries repositorioSeries = new RepositorioSeries();
        static void Main(string[] args)
        {
            string opcaoUsuario = ObterOpcaoUsuario();

            while(opcaoUsuario.ToUpper() != "X")
            {
                switch (opcaoUsuario)
                {
                    case "1":
                        try
                        {
                            InserirSerie();
                            Console.WriteLine("\nSérie inserida com sucesso:\n");
                        }
                        catch(Exception ex)
                        {
                            Console.WriteLine(ex.Message);
                        }
                        break;

                    case "2":
                        try
                        {
                            ListarSerie();
                        }
                        catch(Exception ex)
                        {
                            Console.WriteLine(ex.Message);
                        }
                        break;

                    case "3":
                        try
                        {
                            AtualizarSerie();
                        }
                        catch (Exception ex)
                        {
                            Console.WriteLine(ex.Message);
                        }
                        break;

                    case "4":
                        try
                        {
                            ExcluirSerie();
                            Console.WriteLine("\nSérie excluida com sucesso:\n ");
                        }
                        catch (Exception ex)
                        {
                            Console.WriteLine(ex.Message);
                        }
                        break;

                    case "5":
                        try
                        {
                            VisualizarSerie();
                        }
                        catch (Exception ex)
                        {
                            Console.WriteLine(ex.Message);
                        }
                        break;

                    case "C":
                        try
                        {
                            Console.Clear();
                        }
                        catch (Exception ex)
                        {
                            Console.WriteLine(ex.Message);
                        }
                        break;
                        
                       
                }
                opcaoUsuario = ObterOpcaoUsuario();

            }

            Console.WriteLine("Obrigado Por Usar Nossos Serviços");
            Console.ReadLine();

        }

        private static void InserirSerie()
        {
            Console.WriteLine("\nInserir nova série\n");

            foreach (int i in Enum.GetValues(typeof(Genero)))
            {
                Console.WriteLine("{0}-{1}", i, Enum.GetName(typeof(Genero), i));
            }
            Console.Write("\nDigite o gênero entre as opções acima:\n ");
            int entradaGenero = int.Parse(Console.ReadLine());

            Console.Write("\nDigite o Título da Série:\n ");
            string entradaTitulo = Console.ReadLine();

            Console.Write("\nDigite o Ano de Início da Série:\n ");
            int entradaAno = int.Parse(Console.ReadLine());

            Console.Write("\nDigite a Descrição da Série:\n ");
            string entradaDescricao = Console.ReadLine();

            Series novaSerie = new Series(id: repositorioSeries.ProximoId(),
                genero: (Genero)entradaGenero,
                titulo: entradaTitulo,
                ano: entradaAno,
                descricao: entradaDescricao);

            repositorioSeries.Insere(novaSerie);

        }

        private static void ListarSerie()
        {
            Console.WriteLine("\nListar séries\n");

            var lista = repositorioSeries.Lista();

            if (lista.Count == 0)
            {
                Console.WriteLine("\nNenhuma série cadastrada.\n");
                return;
            }

            foreach (var serie in lista)
            {
                var excluido = serie.retornaExcluido();

                Console.WriteLine("#ID {0}: - {1} {2}", serie.retornaId(), serie.retornaTitulo(), (excluido ? "*Excluído*" : ""));
            }

        }

        private static void AtualizarSerie()
        {
            Console.Write("\nDigite o id da série:\n ");
            int indiceSerie = int.Parse(Console.ReadLine());

         
            foreach (int i in Enum.GetValues(typeof(Genero)))
            {
                Console.WriteLine("{0}-{1}", i, Enum.GetName(typeof(Genero), i));
            }

            Console.Write("\nDigite o gênero entre as opções acima: \n");
            int entradaGenero = int.Parse(Console.ReadLine());

            Console.Write("\nDigite o Título da Série:\n ");
            string entradaTitulo = Console.ReadLine();

            Console.Write("\nDigite o Ano de Início da Série:\n ");
            int entradaAno = int.Parse(Console.ReadLine());

            Console.Write("\nDigite a Descrição da Série:\n ");
            string entradaDescricao = Console.ReadLine();

            Series atualizaSerie = new Series(id: indiceSerie,
                genero: (Genero)entradaGenero,
                titulo: entradaTitulo,
                ano: entradaAno,
                descricao: entradaDescricao);

            repositorioSeries.Atualizar(indiceSerie, atualizaSerie);

        }

        private static void ExcluirSerie()
        {
            Console.Write("\nDigite o id da série:\n ");
            int indiceSerie = int.Parse(Console.ReadLine());

            repositorioSeries.Exclui(indiceSerie);

        }

        private static void VisualizarSerie()
        {
            Console.Write("\nDigite o id da série:\n ");
            int indiceSerie = int.Parse(Console.ReadLine());

            var serie = repositorioSeries.RetornaPorId(indiceSerie);

            Console.WriteLine(serie);


        }


        private static string ObterOpcaoUsuario()
        {
            Console.WriteLine("\nAqui Você Encontra As Melhores Séries!!!\n");
            Console.WriteLine("Informe a opção desejada:\n");

            Console.WriteLine("\n1- Inserir Nova Série");
            Console.WriteLine("\n2- Listar Série");
            Console.WriteLine("\n3- Atualizar Série");
            Console.WriteLine("\n4- Excluir Série");
            Console.WriteLine("\n5- Visualizar Série");
            Console.WriteLine("\nC- Limpar Tela");
            Console.WriteLine("\nX- Sair\n");
            

            string opcaoUsuario = Console.ReadLine().ToUpper();
            Console.WriteLine();
            return opcaoUsuario;
        }
    }


}
