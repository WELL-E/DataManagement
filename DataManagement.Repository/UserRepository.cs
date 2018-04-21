using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using Dapper;
using DataManagement.Entities;
using DataManagement.Repository.Interfaces;

namespace DataManagement.Repository
{
    public class UserRepository : BaseRepository, IUserRepository
    {
        public bool AddUser(User user)
        {
            var parameters = new DynamicParameters();
            parameters.Add("_userName", user.UserName);
            parameters.Add("_userMobile", user.UserMobile);
            parameters.Add("_userEmail", user.UserEmail);
            parameters.Add("_faceBookUrl", user.FaceBookUrl);
            parameters.Add("_linkedInUrl", user.LinkedInUrl);
            parameters.Add("_twitterUrl", user.TwitterUrl);
            parameters.Add("_personalWebUrl", user.PersonalWebUrl);
            SqlMapper.Execute(Conn, "AddUser", parameters, commandType:CommandType.StoredProcedure);
            return true;
        }

        public bool UpdateUser(User user)
        {
            //var parameters = new DynamicParameters();
            //parameters.Add("_userId", user.UserId);
            //parameters.Add("_userName", user.UserName);
            //parameters.Add("_userMobile", user.UserMobile);
            //parameters.Add("_userEmail", user.UserEmail);
            //parameters.Add("-faceBookUrl", user.FaceBookUrl);
            //parameters.Add("_linkedInUrl", user.LinkedInUrl);
            //parameters.Add("_twitterUrl", user.TwitterUrl);
            //parameters.Add("_personalWebUrl", user.PersonalWebUrl);
            var sql = string.Format("call UpdateUser({0},{1}, {2}, {3}, {4}, {5}, {6}, {7})",
                user.UserId, user.UserName, user.UserMobile, user.UserEmail, user.FaceBookUrl, 
                user.LinkedInUrl, user.TwitterUrl, user.PersonalWebUrl);
            SqlMapper.Execute(Conn, "UpdateUser", sql);
            return true;
        }

        public bool DeleteUser(int userId)
        {
            var sql = string.Format("call DeleteUser({0})", userId);
            SqlMapper.Execute(Conn, sql);
            return true;
        }

        public IList<User> GetAllUser()
        {
            return SqlMapper.Query<User>(Conn, "GetAllUsers", CommandType.StoredProcedure).ToList();
        }

        public User GetUserById(int userId)
        {
            try
            {
                var sql = string.Format("call GetUserById({0})", userId);
                return SqlMapper.Query<User>(Conn, sql).FirstOrDefault();
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }
        }
    }
}
