using LuftbornTask.Models;
using MongoDB.Driver;
using System;

namespace LuftbornTask.Repositories
{
    public class VikingRepository : IVikingRepository
    {
        private readonly IMongoCollection<Viking> _vikings;

        public VikingRepository(IMongoClient client)
        {
            var database = client.GetDatabase("LuftbornTaskDb");
            _vikings = database.GetCollection<Viking>("Vikings");
        }

        public async Task<List<Viking>> GetAllAsync()
        {
            try { return await _vikings.Find(_ => true).ToListAsync(); }
            catch (Exception ex) { throw new Exception("Error fetching all vikings", ex); }
        }
        public async Task<Viking> GetByIdAsync(string id)
        {
            try { return await _vikings.Find(v => v.Id == id).FirstOrDefaultAsync(); }
            catch (Exception ex) { throw new Exception($"Error fetching viking with id {id}", ex); }
        }
        public async Task CreateAsync(Viking viking)
        {
            try { await _vikings.InsertOneAsync(viking); }
            catch (Exception ex) { throw new Exception("Error creating viking", ex); }
        }
        public async Task UpdateAsync(string id, Viking viking)
        {
            try { await _vikings.ReplaceOneAsync(v => v.Id == id, viking); }
            catch (Exception ex) { throw new Exception($"Error updating viking with id {id}", ex); }
        }
        public async Task DeleteAsync(string id)
        {
            try { await _vikings.DeleteOneAsync(v => v.Id == id); }
            catch (Exception ex) { throw new Exception($"Error deleting viking with id {id}", ex); }
        }
    }
}
