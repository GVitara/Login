using Amazon.DynamoDBv2.DataModel;
using LoginAPI.Interface;
using LoginAPI.Models;

namespace LoginAPI.Services
{
    public class RegisterService : IRegisterService
    {
        
        private readonly IDynamoDBContext _dynamoDBContext;
        public RegisterService(IDynamoDBContext dynamoDBContext) 
        { 
            _dynamoDBContext = dynamoDBContext;
        }
        public async Task<bool> RegisterUser(User user)
        {
            var user1 = await _dynamoDBContext.LoadAsync<User>(user.Id);
            if (user1 == null)
            {
                await _dynamoDBContext.SaveAsync(user);
                return true;
            }
            return false;
        }
    }
}
