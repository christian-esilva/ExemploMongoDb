using Microsoft.Extensions.Configuration;
using MongoDB.Driver;

namespace APICatalogo.Context
{
    public class CatalogoContext
    {
        private readonly IConfiguration _config;

        public CatalogoContext(IConfiguration config)
        {
            _config = config;
        }

        public T GetItems<T>(string codigo)
        {
            MongoClient client = new MongoClient(_config.GetSection("MongoDB:ConexaoCatalogo").Value);

            IMongoDatabase db = client.GetDatabase("DbCatalogo");

            var filter = Builders<T>.Filter.Eq("Codigo", codigo);

            return db.GetCollection<T>("Catalogo").Find(filter).FirstOrDefault();
        }
    }
}
