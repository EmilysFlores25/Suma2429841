using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SQLite;
namespace Suma2429841
{
    public class LocalDbService
    {
        private const string DB_Emily = "demo_suma_db3";
        private readonly SQLiteAsyncConnection _connection;

        public LocalDbService()
        {
            _connection = new SQLiteAsyncConnection(Path.Combine(FileSystem.AppDataDirectory, DB_Emily));

            _connection.CreateTableAsync<Resultado>();
        }

        public async Task<List<Resultado>> GetResultados()
        {
            return await _connection.Table<Resultado>().ToListAsync();
        }

        public async Task<Resultado> GetById(int id)
        {
            return await _connection.Table<Resultado>().Where(x => x.Id == id).FirstOrDefaultAsync();
        }

        public  async Task Create (Resultado resultado)
        {
            await _connection.InsertAsync(resultado);
        }

        public async  Task Update(Resultado resultado)
        {
            await _connection.UpdateAsync(resultado);
        }

        public async Task Delete(Resultado resultado)
        {
            await _connection.DeleteAsync(resultado);
        }
    }
}
