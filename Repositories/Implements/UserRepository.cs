﻿using DataAccess;
using DataAccess.DTO;
using DataAccess.Util.UserMapper;
using BusinessObjects.Model;

namespace Repositories.Implements
{
    public class UserRepository : IUserRepository
    {
        public void Add(UserDTO user)
        {
            UserDAO.Instance.SaveMember(UserMapper.mapToEntity(user));
        }

        public List<UserDTO> GetAll()
        {
            return UserDAO.Instance.FindAll().Select(m => UserMapper.mapToDTO(m)).ToList()!;
        }

        public UserDTO Login(string email, string password)
        {
            return UserMapper.mapToDTO(UserDAO.Instance.FindMemberByEmailPassword(email, password))!;
        }

        public UserDTO GetLoggedAccount()
        {
            throw new NotImplementedException();
        }

        public void Update(UserDTO user, string newCity, string newCountry, string newCompany)
        {
            User temp_user = UserDAO.Instance.FindMemberByEmailPassword(user.Email!, user.Password!);
            temp_user.City = newCity;
            temp_user.Country = newCountry;
            temp_user.CompanyName = newCompany;
            UserDAO.Instance.UpdateMember(temp_user);
        }

        public UserDTO UpdatePassword(string email, string password, string newPassword)
        {
            User temp_user = UserDAO.Instance.FindMemberByEmailPassword(email!, password!);
            temp_user.Password = newPassword;
            UserDAO.Instance.UpdateMember(temp_user);
            return UserMapper.mapToDTO(temp_user)!;
        }
    }
}
