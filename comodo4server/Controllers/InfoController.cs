using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Entities;
using LoggerContracts;
using Microsoft.AspNetCore.Mvc;
using RepositoryContract;

namespace ApplicationDevelopment.Controllers
{
    /// <summary>
    /// This is InfoController
    /// </summary>

    [Route("api/[controller]")]
    [ApiController]
    public class InfoController : ControllerBase
    {
        private readonly IInfoRepository _infoRepository;
        private readonly ILoggerManager _logger;

        /// <summary>
        /// This Info Controller
        /// </summary>
        /// <remarks>This is Controller injection.</remarks>
        public InfoController(IInfoRepository infoRepository, ILoggerManager logger)
        {
            _infoRepository = infoRepository;
            _logger = logger;
        }

        // GET api/info
        /// <summary>
        /// GET API info
        /// </summary>
        /// <remarks>This API will get all infos.</remarks>
        [HttpGet("{page}/{size}")]
        public async Task<IEnumerable<Info>> Get(int page, int size)
        {
            try
            {
                _logger.LogInfo("InfoController GetAll(page, size)");
                return await _infoRepository.GetAll(page, size);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
                throw;
            }

        }

        // GET api/info/count
        /// <summary>
        /// GET API info
        /// </summary>
        /// <remarks>This API will get info count.</remarks>
        [HttpGet("count")]
        public async Task<long> Get()
        {
            try
            {
                _logger.LogInfo("InfoController GetCount()");
                return await _infoRepository.GetCount();
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
                throw;
            }
        }

        // GET api/info/5
        /// <summary>
        /// GET API info
        /// </summary>
        /// <remarks>This API will get info by provided id.</remarks>
        /// <param name="id"></param>
        [HttpGet("{id}")]
        public async Task<Info> Get(string id)
        {
            try
            {
                _logger.LogInfo("InfoController Get(id)");
                return await _infoRepository.Get(id);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
                throw;
            }
        }

        // POST api/info
        /// <summary>
        /// POST API info
        /// </summary>
        /// <remarks>This API will add new info.</remarks>
        /// <param name="info"></param>
        [HttpPost]
        public void Post([FromBody]Info info)
        {
            try
            {
                _logger.LogInfo("InfoController Post([FromBody]Info info)");
                _infoRepository.Create(info);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
                throw;
            }
        }

        // PUT api/info/5
        /// <summary>
        /// PUT API info
        /// </summary>
        /// <remarks>This API will edit the info.</remarks>
        /// <param name="id"></param>
        /// <param name="info"></param>
        [HttpPut("{id}")]
        public void Put(string id, [FromBody]Info info)
        {
            try
            {
                _logger.LogInfo("InfoController Put(string id, [FromBody]Info info)");
                _infoRepository.Update(id, info);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
                throw;
            }
        }

        // DELETE api/info/5
        /// <summary>
        /// Delete API info
        /// </summary>
        /// <remarks>This API will delete the info.</remarks>
        /// <param name="id"></param>
        [HttpDelete("{id}")]
        public void Delete(string id)
        {
            try
            {
                _logger.LogInfo("InfoController Delete(string id)");
                _infoRepository.Delete(id);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
                throw;
            }
        }
    }
}