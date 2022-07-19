using API.Interfaces;
using API.Models;
using Microsoft.AspNetCore.Components;
using Microsoft.EntityFrameworkCore;
using System.Diagnostics;

namespace API.Services
{
    public class ClientDataService : IClientDataServices
    {
        private ILogger<ClientDataService> _logger { get; set; }
        private readonly IHttpContextAccessor _httpContext;
        private IDbContextFactory<DatabaseContext> _dbFactory { get; set; }

        public ClientDataService(ILogger<ClientDataService> logger, 
            IHttpContextAccessor accessor, 
            IDbContextFactory<DatabaseContext> databaseFactory, 
            bool initialize = true)
        {
            _httpContext = accessor;
            _dbFactory = databaseFactory;
            _logger = logger;

            if (initialize)
            {
                Init();
            }
        }

        public void Init()
        {

            var user = _httpContext.HttpContext.User.Identity;

            if (user != null && user.IsAuthenticated)
            {
                var username = user.Name;
                using var db = _dbFactory.CreateDbContext();
            }

        }

        public async Task<List<ClientModel>> GetAllClientsAsync()
        {
            await using var db = _dbFactory.CreateDbContext();
            try
            {
                return await db.Client
                    .AsNoTracking()
                    .ToListAsync();
            }
            catch(DbUpdateException ex)
            {
                _logger.LogCritical(ex.Message);
                return new List<ClientModel>();
            }
        }

        public async Task<ClientModel> GetClientByIdAsync(string clientId)
        {
            try
            {
                await using var db = _dbFactory.CreateDbContext();
                var result = await db.Client
                    .Where(x => x.ClientSn == clientId)
                    .AsNoTracking()
                    .FirstOrDefaultAsync();

                if (result != null)
                {
                    return result;
                }
                else 
                { 
                    return new ClientModel();
                }
            }
            catch (DbUpdateException ex)
            {
                Debug.WriteLine(ex.Message);
                _logger.LogCritical(ex.Message);
                return null;
            }
        }

        public async Task<int> AddClientAsync(ClientModel client)
        {

            if (client == null)
            {
                _logger.LogDebug(new ArgumentNullException(nameof(client)).ToString());
                return 0;
            }
                
            try
            {
                await using var db = _dbFactory.CreateDbContext();

                var status = await db.ClientStatus
                    .Where(x => x.Id == client.ClientStatus.Id)
                    .SingleOrDefaultAsync();

                client.ClientStatus = status;

                await db.Client.AddAsync(client);
                return await db.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                _logger.LogCritical(ex.Message);
                return -1;
            }
        }

        public async Task<int> DeleteClient(string clientId)
        {
            await using var db = _dbFactory.CreateDbContext();

            if (string.IsNullOrEmpty(clientId))
            {
                _logger.LogError(new ArgumentNullException(nameof(clientId)).ToString());
                return -1;
            }
                var clientModel = await db.Client
                    .Where(x => x.ClientSn == clientId)
                    .FirstOrDefaultAsync();

                if (clientModel == null)
                    return -1;
            try
            {
                db.Client.Remove(clientModel);
                var result = await db.SaveChangesAsync();
                return result;
            }
            catch (DbUpdateException ex)
            {
                _logger.LogCritical(ex.Message);
                return -1;
            }
        }

        public async Task<List<ClientStatusModel>> GetClientStatusListAsync()
        {
            await using var db = _dbFactory.CreateDbContext();

            return await db.ClientStatus
                .ToListAsync();
        }
    }
}
