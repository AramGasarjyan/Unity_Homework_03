using System.Collections.Generic;

namespace DefaultNamespace
{
    public class UserData
    {
        public string Name { get; }
        public string Surname { get; }
        public string Username { get; }
        public string Password { get; }
        public string Gender { get; }

        public UserData(string name, string surname, string username, string password, string gender)
        {
            Name = name;
            Surname = surname;
            Username = username;
            Password = password;
            Gender = gender;
        }
    }

    public static class DataStore
    {
        private static List<UserData> _userDatas = new List<UserData>();

        public static bool TryFind(string username, string password, out UserData userData)
        {
            userData = _userDatas.Find(data => username == data.Username && password == data.Password);
            return userData != null;
        }

        public static void AddUser(UserData user)
        {
            _userDatas.Add(user);
        }
    }
}