using Microsoft.Extensions.Options;
using MongoDB.Driver;
using PortalAGR.Domain.Contextos.Agentes.Entities;
using PortalAGR.Shared.Configurations;
using System;

namespace PortalAGR.Infrastructure.ContextosDeDados
{
    public class ContextoDeDados : IContextoDeDados
    {
        private readonly Conexoes _Conexoes;
        public IMongoDatabase MongoConnection { get; private set; }

        public ContextoDeDados(IOptionsSnapshot<Conexoes> options)
        {
            _Conexoes = options.Value;
            Conectar();
        }


        public void Conectar() => ConfigureConnections();

        private void ConfigureConnections()
        {
            var configurations = MongoClientSettings.FromConnectionString(_Conexoes.StringConexaoBancoDeDados);
            configurations.MaxConnectionIdleTime = TimeSpan.FromSeconds(30);
            configurations.UseTls = false;
            configurations.RetryWrites = false;

            var client = new MongoClient(configurations);

            MongoConnection = client.GetDatabase(_Conexoes.NomeBanco);//"despensa_db";
        }

        #region Coleções

        public IMongoCollection<Agente> Agentes => MongoConnection.GetCollection<Agente>("Agentes");
        //public IMongoCollection<UnidadeDeMedida> UnidadesDeMedida => ConexaoMongo.GetCollection<UnidadeDeMedida>("UnidadesDeMedida");
        //public IMongoCollection<DetalhesDoProblema> DetalhesDoProblema => ConexaoMongo.GetCollection<DetalhesDoProblema>("DetalhesDoProblema");

        #endregion
    }
}
