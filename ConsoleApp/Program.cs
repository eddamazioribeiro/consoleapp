using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace ConsoleApp
{
    class Program
    {
        static void Main(string[] args)
        {


            //Classes.Cliente cli2 = new Classes.Cliente(3);
            //cli2.Dispose();
            // using: chama automaticamente o método Disposable
            try
            {
                Classes.Cliente cli = new Classes.Cliente();
                cli.Codigo = 3;
                cli.Nome = "eduardo".LetraInicialMaiuscula(true);
                cli.Tipo = 1;
                cli.DataCadastro = new DateTime(2018, 12, 4);
                cli.Dispose();
            }
            catch (ConsoleApp.Excecoes.ValidacaoException ex)
            {

                Console.WriteLine(ex.Message);
                Console.ReadLine();
                throw;

            }

            using (Classes.Cliente cli_banco = new Classes.Cliente(3))
            {
                try
                {
                    Console.WriteLine(cli_banco.Nome);
                    Console.ReadLine();
                }
                catch (Exception)
                {

                    throw;
                }

            }

            /*
            using (Classes.Cliente cli2 = new Classes.Cliente(5))
            {
                cli2.Nome = "João";
            }
            */

            /*
            double CodMetade = cli.Codigo.RetornaMetade();
            Console.WriteLine(CodMetade);

            // Contato 1
            Classes.Contato contato1 = new Classes.Contato();
            contato1.Codigo = 1;
            contato1.DadosContato = "99360-1202";
            contato1.Tipo = "Telefone";

            // Contato 2
            Classes.Contato contato2 = new Classes.Contato();
            contato2.Codigo = 2;
            contato2.DadosContato = "ed.damazioribeiro@gmail.com";
            contato2.Tipo = "E-mail";

            cli.Contatos = new List<Classes.Contato>();

            cli.Contatos.Add(contato1);
            cli.Contatos.Add(contato2);

            // Expressão Lambda
            Classes.Contato contatoBusca = cli.Contatos.FirstOrDefault(x => x.Tipo == "E-mail");

            /* Usando FOR
            foreach (Classes.Contato cont in cli.Contatos) {
                Console.WriteLine(cont.DadosContato + " (" + cont.Tipo + ") ");
            }
            
            // Expressão Lambda com FOREACH
            cli.Contatos.ForEach(cont => Console.WriteLine(cont.DadosContato + " (" + cont.Tipo + ") "));

            */
            /*
            Console.WriteLine(cli.Nome);
            Console.WriteLine(contatoBusca.DadosContato + " (" + contatoBusca.Tipo + ")");
            Console.ReadLine();*/
        }
    }
}
