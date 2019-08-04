using LoggerContracts;
using Microsoft.Extensions.Options;
using MongoDB.Driver;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using Entities.Converters;

namespace Entities
{
    public class AppDbContext
    {
        private readonly ILoggerManager _logger;
        public IMongoDatabase Db { get; private set; }
        public AppDbContext(IOptions<Settings> options, IMongoClient client, ILoggerManager logger)
        {
            _logger = logger;
            try
            {
                var _serializerSettings = new JsonSerializerSettings()
                {
                    Converters = new List<JsonConverter> { new ObjectIdConverter(), new GuidConverter() }
                };
                Db = client.GetDatabase(options.Value.Database);
            }
            catch (Exception ex)
            {
                _logger.LogInfo($"Could not open connection to DB: {ex.Message}");
                throw;
            }
        }
    }
}
