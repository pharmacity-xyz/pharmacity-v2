using Microsoft.AspNetCore.Identity;

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

        public void AddNewUser(User user)
        {
            try
            {
                using (var context = new AppDbContext())
                {
                    user.Password = CreateHashedPassword(user, user.Password);
                    context.Users?.Add(user);
                    context.SaveChanges();
                }
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }

        public List<User> FetchAllUsers()
        {
            var p = new List<User>();
            try
            {
                using (var context = new AppDbContext())
                {
                    p = context.Users?.ToList();

                    if (p == null)
                    {
                        throw new Exception("Can not fetch all users");
                    }
                }
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
            return p;
        }

        public User FindUserByEmail(string email)
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

        public void UpdateUser(User user)
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

        public void UpdateUserPassword(User user, string provided_password, string new_password)
        {
            try
            {
                using (var context = new AppDbContext())
                {
                    VerifyPassword(user, provided_password);
                    user.Password = CreateHashedPassword(user, new_password);
                    context.Entry<User>(user).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
                    context.SaveChanges();
                }
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }

        public User ForgotPassword(User user, string newPassword)
        {
            try
            {
                using (var context = new AppDbContext())
                {
                    user.Password = CreateHashedPassword(user, newPassword);
                    context.Entry<User>(user).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
                    context.SaveChanges();
                }

            }
            catch (Exception e)
            {

                throw new Exception(e.Message);
            }

            return user;
        }

        private string CreateHashedPassword(User user, string password)
        {
            return passwordHasher.HashPassword(user, password);
        }

        public void VerifyPassword(User user, string provided_password)
        {
            PasswordHasher<User> passwordHasher = new PasswordHasher<User>();
            try
            {
                if (passwordHasher.VerifyHashedPassword(user, user.Password, provided_password) == PasswordVerificationResult.Failed)
                {
                    throw new Exception("You entered wrong password. Please type again.");
                }
            }
            catch (Exception e)
            {

                throw new Exception(e.Message);
            }
        }
    }
}
