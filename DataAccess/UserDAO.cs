using BusinessObjects.Data;
using BusinessObjects.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess
{
    public class UserDAO
    {

        private static UserDAO? instance = null;
        private static readonly object iLock = new object();
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

        public User FindMemberByEmailPassword(string email, string password)
        {
            var p = new User();
            try
            {
                using (var context = new AppDbContext())
                {
                    p = context.Members?.SingleOrDefault(x => x.Email == email && x.Password == password);

                    if (p == null)
                    {
                        throw new Exception("Wrong password or username");
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
                    context.Members?.Add(user);
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
                    p = context.Members?.ToList();

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
