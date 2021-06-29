using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using Api.Db.Entities;
using Api.Interfaces.Repositories;
using Api.Interfaces.Services;
using Api.Models;
using Api.Models.Requests;
using AutoMapper;

namespace Api.Services
{
    public class UserService : IUserService
    {
        private readonly IUserRepository _userRepository;
        private readonly IMapper _mapper;

        public UserService(IUserRepository userRepository, IMapper mapper)
        {
            _userRepository = userRepository;
            _mapper = mapper;
        }

        private string EncriptaSenha(string senha)
        {
            byte[] bytes = Encoding.Unicode.GetBytes(senha);
            SHA256Managed hashstring = new SHA256Managed();
            byte[] hash = hashstring.ComputeHash(bytes);
            string hashString = string.Empty;
            foreach (byte x in hash)
            {
                hashString += String.Format("{0:x2}", x);
            }
            return hashString;
        }

        public async Task<UserModel> InsertAsync(UserRequest request)
        {
            var entity = _mapper.Map<UserEntity>(request);
            entity.Password = EncriptaSenha(entity.Password);
            entity = await _userRepository.InsertAsync(entity);
            return _mapper.Map<UserModel>(entity);
        }

        public async Task<UserModel> UpdateAsync(Guid id, UserRequest request)
        {
            var entity = await _userRepository.GetByIdAsync(id);
            entity.Password = EncriptaSenha(entity.Password);
            entity = await _userRepository.UpdateAsync(entity);
            return _mapper.Map<UserModel>(entity);
        }

        public async Task<bool> DeleteAsync(Guid id)
        {
            return await _userRepository.DeleteAsync(id);
        }

        public async Task<IEnumerable<UserModel>> GetAsync(Expression<Func<UserEntity, bool>> predicate)
        {
            return _mapper.Map<IEnumerable<UserModel>>(await _userRepository.GetAsync(predicate));
        }

        public async Task<UserModel> GetByIdAsync(Guid id)
        {
            return _mapper.Map<UserModel>(await _userRepository.GetByIdAsync(id));
        }

        public async Task<UserModel> PasswordSignInAsync(string userName, string password)
        {
            password = EncriptaSenha(password);
            var users = await _userRepository.GetAsync(x =>
                x.Active && x.UserName == userName && x.Password == password);

            return _mapper.Map<UserModel>(users.FirstOrDefault());
        }
    }
}