using ApiCatalogoJogos.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ApiCatalogoJogos.Repositories
{
    public class JogoRepository : IJogoRepository
    {
        private static Dictionary<Guid, Jogo> jogos = new Dictionary<Guid, Jogo>()
        {
            {Guid.Parse("f244a8d4-1da7-46d5-9a50-db5442db9415"), new Jogo{Id = Guid.Parse("f244a8d4-1da7-46d5-9a50-db5442db9415"), Nome = "Jogo 1", Produtora = "Produtora 1" , Preco = 20.00} },
            {Guid.Parse("52bb1b38-e983-4b18-8658-a97b69debea0"), new Jogo{Id = Guid.Parse("52bb1b38-e983-4b18-8658-a97b69debea0"), Nome = "Jogo 2", Produtora = "Produtora 2" , Preco = 20.00} },
            {Guid.Parse("0e3f3208-daa1-4884-a553-59223e8b84d1"), new Jogo{Id = Guid.Parse("0e3f3208-daa1-4884-a553-59223e8b84d1"), Nome = "Jogo 3", Produtora = "Produtora 3" , Preco = 20.00} },
            {Guid.Parse("0757a55a-0d89-4d68-9a35-24c5c157fc49"), new Jogo{Id = Guid.Parse("0757a55a-0d89-4d68-9a35-24c5c157fc49"), Nome = "Jogo 4", Produtora = "Produtora 4" , Preco = 20.00} },
            {Guid.Parse("4731b53c-ab6c-4842-9675-e670197f4af1"), new Jogo{Id = Guid.Parse("4731b53c-ab6c-4842-9675-e670197f4af1"), Nome = "Jogo 5", Produtora = "Produtora 5" , Preco = 20.00} },
            {Guid.Parse("49077d29-8624-4ae7-a1cd-a4318b593740"), new Jogo{Id = Guid.Parse("49077d29-8624-4ae7-a1cd-a4318b593740"), Nome = "Jogo 6", Produtora = "Produtora 6" , Preco = 20.00} }

        };


        public Task<List<Jogo>> Obter(int pagina, int quantidade)
        {
            return Task.FromResult(jogos.Values.Skip((pagina - 1) * quantidade).Take(quantidade).ToList());
        }

        public Task<Jogo> Obter(Guid id)
        {

            if (!jogos.ContainsKey(id))
            {
                return null;
            }

            return Task.FromResult(jogos[id]);

        }


        public Task<List<Jogo>> Obter(string nome, string produtora)
        {
            return Task.FromResult(jogos.Values.Where(jogo => jogo.Nome.Equals(nome) && jogo.Produtora.Equals(produtora)).ToList());
        }

        public Task Inserir(Jogo jogo)
        {
            jogos.Add(jogo.Id, jogo);
            return Task.CompletedTask;
        }

        public Task Atualizar(Jogo jogo)
        {
            jogos[jogo.Id] = jogo;
            return Task.CompletedTask;
        }

        public Task Remover (Guid id)
        {
            jogos.Remove(id);
            return Task.CompletedTask;
        }

        public void Dispose()
        {
            // fechar conexão.
        }

        



    }
}
