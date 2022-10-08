﻿using Microsoft.AspNetCore.Identity;

using BusinessObjects.Data;
using BusinessObjects.Model;

namespace DataAccess
{
    public class UserDAO
    {

        private static UserDAO? instance = null;
        private static readonly object iLock = new object();
        private static PasswordHasher<User> passwordHasher = new PasswordHasher<User>();
        public UserDAO()
        {
        }

        public static UserDAO Instance
        {
            get
            {
                lock (iLock)
                {
                    if (instance == null)
                    {
                        instance = new UserDAO();
                    }
                    return instance;
                }
            }
        }

        private string createHashedPassword(User user)
        {
            // PasswordHasher<User> passwordHasher = new PasswordHasher<User>();
            return passwordHasher.HashPassword(user, user.Password);
        }

        private PasswordVerificationResult verifyPassword(User user, string password)
        {
            // PasswordHasher<User> passwordHasher = new PasswordHasher<User>();

            return passwordHasher.VerifyHashedPassword(user, user.Password, password);
        }

        public User FindMemberByEmail(string email)
        {
            var p = new User();
            try
            {
                using (var context = new AppDbContext())
                {
                    p = context.Users?.SingleOrDefault(x => x.Email == email);

                    if (p == null)
                    {
                        throw new Exception("Can not find with provided email");
                    }
                }
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
            return p;
        }

        public void SaveMember(User user)
        {
            try
            {
                using (var context = new AppDbContext())
                {
                    user.Password = createHashedPassword(user);
                    context.Users?.Add(user);
                    context.SaveChanges();
                }
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }

        public void UpdateMember(User user)
        {
            try
            {
                using (var context = new AppDbContext())
                {
                    context.Entry<User>(user).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
                    context.SaveChanges();
                }
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }

        public List<User> FindAll()
        {
            var p = new List<User>();
            try
            {
                using (var context = new AppDbContext())
                {
                    p = context.Users?.ToList();

                    if (p == null)
                    {
                        throw new Exception("No Members!");
                    }
                }
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
            return p;
        }
    }
}
