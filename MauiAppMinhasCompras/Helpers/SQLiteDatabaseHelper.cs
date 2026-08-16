using MauiAppMinhasCompras.Models;
using SQLite;

namespace MauiAppMinhasCompras.Helpers
{
    public class SQLiteDatabaseHelper
    {
        readonly SQLiteAsyncConnection _conn;

        public SQLiteDatabaseHelper(string path) 
        {
            _conn = new SQLiteAsyncConnection(path);
            _conn.CreateTableAsync<Produto>().Wait();
        }

        //Inserir produtos na tabela do SQL
        public Task<int> Insert(Produto p) 
        {
            return _conn.InsertAsync(p);
        }

        //Atualizar produtos na tabela SQL
        public Task<List<Produto>> Update(Produto p) 
        {
            string sql = "UPDATE Produto SET Descrocao=?, Quantidade=?, Preco=? WHERE Id=?";

            return _conn.QueryAsync<Produto>(sql, p.Descricao, p.Quantidade, p.Preco, p.Id);
        }

        //Deletar produtos
        public Task<int> Delete(int Id) 
        {
            return _conn.Table<Produto>().DeleteAsync(i => i.Id == Id);
        }


        //Listar produtos na tabela
        public Task<List<Produto>> GetAll() 
        {
            return _conn.Table<Produto>().ToListAsync();
        }

        //Procurar os produtos na tabela
        public Task<List<Produto>> Search(string q) 
        {
            string sql = "SELECT * Produto WHERE Descricao LIKE '%" + q + "%'";

            return _conn.QueryAsync<Produto>(sql);
        }
    }
}
