﻿using MongoDB.Bson;

namespace APICatalogo.Models
{
    public class Servico
    {
        public ObjectId _id { get; set; }
        public string Codigo { get; set; }
        public string Nome { get; set; }
        public decimal ValorHora { get; set; }
    }
}
