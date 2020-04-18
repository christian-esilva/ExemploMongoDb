using MongoDB.Bson;

namespace CargaCatalogo
{
    public class Produto
    {
        public ObjectId _id { get; set; }
        public string Codigo { get; set; }
        public string Nome { get; set; }
        public string Tipo { get; set; }
        public decimal Preco { get; set; }
        public Fornecedor Fornecedor { get; set; }
    }
}
