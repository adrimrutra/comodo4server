using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using LoggerContracts;
using MongoDB.Driver;
using RepositoryContract;

namespace Repository
{
    public class RepositoryBase<T>: IRepositoryBase<T> where T : class
    {
        private readonly ILoggerManager _logger;
        private readonly IMongoCollection<T> _collection;

        public RepositoryBase(IMongoCollection<T> collection, ILoggerManager logger)
        {
            _collection = collection;
            _logger = logger;
        }
        public async Task<IEnumerable<T>> GetAll(int page, int size)
        {
            try
            {
                return await _collection.Find(_ => true).Skip((page - 1) * size).Limit(size).ToListAsync();
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
                throw;
            }
        }

        public async Task<long> GetCount()
        {
            try
            {
                return await _collection.Find(_ => true).CountDocumentsAsync();
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
                throw;
            }
        }

        public async Task<T> Get(string id)
        {
            var filter = Builders<T>.Filter.Eq("Id", id);
            try
            {
                return await _collection.Find(filter).FirstOrDefaultAsync();
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
                throw;
            }
        }

        public async Task Create(T entity)
        {
            try
            {
                await _collection.InsertOneAsync(entity);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
                throw;
            }
        }

        public async Task<ReplaceOneResult> Update(string id, T entity)
        {
            try
            {
                ReplaceOneResult updateResult =
                await _collection
                       .ReplaceOneAsync(Builders<T>.Filter.Eq("Id", id), replacement: entity);
                return updateResult;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
                throw;
            }
        }

        public async Task<DeleteResult> Delete(string id)
        {
            try
            {
                return await _collection.DeleteOneAsync(Builders<T>.Filter.Eq("Id", id));
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
                throw;
            }
        }
    }
}
