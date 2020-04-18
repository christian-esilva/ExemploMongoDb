using System;
using MongoDB.Driver;
using Microsoft.Extensions.Configuration;
using System.IO;

namespace CargaCatalogo
{
    class Program
    {
        static void Main(string[] args)
        {
            var builder = new ConfigurationBuilder()
                .SetBasePath(AppContext.BaseDirectory)
                .AddJsonFile("appsettings.json");

            var configuration = builder.Build();

            MongoClient client = new MongoClient(configuration.GetConnectionString("ConexaoCatalogo"));

            IMongoDatabase db = client.GetDatabase("DbCatalogo");

            Console.WriteLine("Incluindo produtos...");
            var catalogoProd = db.GetCollection<Produto>("Catalogo");

            Produto p1 = new Produto
            {
                Codigo = "p001",
                Nome = "The Last Of Us 2",
                Tipo = "Jogos",
                Preco = 200,                
            };
            p1.Fornecedor = new Fornecedor();
            p1.Fornecedor.Codigo = "f001";
            p1.Fornecedor.Nome = "NaughtyDog";

            catalogoProd.InsertOne(p1);

            Produto p2 = new Produto
            {
                Codigo = "p002",
                Nome = "The Witcher 3",
                Tipo = "Jogos",
                Preco = 100,
            };
            p2.Fornecedor = new Fornecedor();
            p2.Fornecedor.Codigo = "f002";
            p2.Fornecedor.Nome = "CD Project Red";

            catalogoProd.InsertOne(p2);

            Console.WriteLine("Incluindo serviços...");
            var catalogoServ = db.GetCollection<Servico>("Catalogo");

            Servico s1 = new Servico
            {
                Codigo = "s001",
                Nome = "dev react",
                ValorHora = 150
            };
            catalogoServ.InsertOne(s1);

            Servico s2 = new Servico
            {
                Codigo = "s002",
                Nome = "devops",
                ValorHora = 180
            };
            catalogoServ.InsertOne(s2);

            Console.WriteLine("Finalizado...");
            Console.ReadKey();
        }
    }
}
