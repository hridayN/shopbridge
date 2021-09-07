using ShopBridge.API.DTO.Requests;
using ShopBridge.API.DTO.Responses;
using ShopBridge.API.Services.Contracts;
using ShopBridge.API.Infrastructure.Contracts.Base;
using ShopBridge.API.Infrastructure.Entities;
using ShopBridge.API.Mapper;
using System;
using System.Threading.Tasks;
using Common.Utility.Contracts;
using ShopBridge.API.Models;
using Microsoft.IdentityModel.Tokens;
using System.Text;
using System.IdentityModel.Tokens.Jwt;
using System.Collections.Generic;
using System.Security.Claims;

namespace ShopBridge.API.Services.Core
{
    /// <summary>
    /// UserService logic class
    /// </summary>
    public class UserService : IUserService
    {
        /// <summary>
        /// UserRepository variable
        /// </summary>
        private IRepository<UserEntity> _userRepository;

        /// <summary>
        /// IExpressionFilter variable
        /// </summary>
        private readonly IExpressionFilter _expressionFilter;

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="userRepository"></param>
        public UserService(IRepository<UserEntity> userRepository,
            IExpressionFilter expressionFilter)
        {
            _userRepository = userRepository;
            _expressionFilter = expressionFilter;
        }

        /// <summary>
        /// SaveUser method to save/update user info
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        public async Task<SaveUserResponse> SaveUser(SaveUserRequest request)
        {
            SaveUserResponse response = new SaveUserResponse();
            if (request == null)
            {
                response.StatusCode = Enums.Enums.StatusCode.BadRequest;
                response.Message = "Invalid request.";
                return response;
            }
            UserEntity userEntity;
            if (request.User.Id != null)
            {
                var savedUser = await _userRepository.GetOneAsyncWithOrder(x => x.Id == (Guid)request.User.Id, "", false);
                if (savedUser != null)
                {
                    savedUser.ModifiedDate = DateTime.Now;
                    await _userRepository.UpdateAsync(savedUser);
                    response.UserId = (Guid)request.User.Id;
                    response.Message = "User updated successfully.";
                    response.StatusCode = Enums.Enums.StatusCode.Ok;
                } else
                {
                    response.Message = "Invalid user data.";
                    response.StatusCode = Enums.Enums.StatusCode.BadRequest;
                    return response;
                }
            } else
            {
                request.User.Id = new Guid();
                request.User.CreatedDate = request.User.ModifiedDate = DateTime.Now;
                userEntity = ObjectMapper.Mapper.Map<UserEntity>(request.User);
                var savedUser = await _userRepository.AddAsync(userEntity);
                response.UserId = savedUser.Id;
                response.Message = "User added successfully.";
                response.StatusCode = Enums.Enums.StatusCode.Ok;
            }
            return response;
        }

        /// <summary>
        /// Method to retrieve the user
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        public async Task<RetrieveUserResponse> RetrieveUser(RetrieveUserRequest request)
        {
            RetrieveUserResponse response = new RetrieveUserResponse();
            if (request == null || (request.UserId == null && string.IsNullOrWhiteSpace(request.Name) && string.IsNullOrWhiteSpace(request.Password)))
            {
                response.StatusCode = Enums.Enums.StatusCode.BadRequest;
                response.Message = "Invalid request.";
                return response;
            }
            UserEntity userEntity = null;
            if (request.UserId != null)
            {
                userEntity = await _userRepository.GetOneAsyncWithOrder(x => x.Id == request.UserId, "", false);
            }
            else if (!string.IsNullOrWhiteSpace(request.Name) && !string.IsNullOrWhiteSpace(request.Password))
            {
                userEntity = await _userRepository.GetOneAsyncWithOrder(x => x.Name == request.Name && x.Password == request.Password, "", false);
            }
            else
            {

            }
            
            if (userEntity == null)
            {
                response.StatusCode = Enums.Enums.StatusCode.NotFound;
                response.Message = "No user found with the given UserId.";
                return response;
            } else
            {
                response.User = ObjectMapper.Mapper.Map<User>(userEntity);
                response.User.Password = null;
                response.StatusCode = Enums.Enums.StatusCode.Ok;
                response.Message = "User retrieved successfully.";
            }

            return response;
        }

        /// <summary>
        /// Login method
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        public async Task<LoginResponse> Login(LoginRequest request)
        {
            LoginResponse response = new LoginResponse();
            if (request == null)
            {
                response.StatusCode = Enums.Enums.StatusCode.BadRequest;
                response.Message = "Invalid request.";
                return response;
            }
            RetrieveUserRequest retrieveUserRequest = new RetrieveUserRequest() 
            {
                Name = request.Name,
                Password = request.Password
            };
            RetrieveUserResponse retrieveUserResponse = await RetrieveUser(retrieveUserRequest);
            if (retrieveUserResponse.StatusCode == Enums.Enums.StatusCode.Ok)
            {
                var secretKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes("superSecretKey@345"));
                var signinCredentials = new SigningCredentials(secretKey, SecurityAlgorithms.HmacSha256);
                var tokenOptions = new JwtSecurityToken(
                    issuer: "http://localhost:57174",   // the name of the webserver that issues the token
                    audience: "http://localhost:57174", // valid recipients
                    claims: new List<Claim>(),          // list of user roles
                    expires: DateTime.Now.AddMinutes(5),    // the date and time after which the token expires
                    signingCredentials: signinCredentials
                );
                response.Token = new JwtSecurityTokenHandler().WriteToken(tokenOptions);
                response.StatusCode = Enums.Enums.StatusCode.Ok;
            } else
            {
                response.StatusCode = Enums.Enums.StatusCode.Unauthorized;
                response.Message = retrieveUserResponse.Message;
            }
            return response;
        }
    }
}
