using UnityEngine;

namespace DefaultNamespace
{
    public static class Session
    {
        private const string NAME_KEY = "name";
        private const string SURNAME_KEY = "surname";
        private const string USERNAME_KEY = "username";
        private const string PASSWORD_KEY = "password";
        private const string GENDER_KEY = "gender";

        public static UserData UserData { get; private set; }

        public static void SetUserData(UserData userData)
        {
            UserData = userData;
        }

        public static void SaveProfile()
        {
            if (UserData == null)
            {
                return;
            }

            PlayerPrefs.SetString(NAME_KEY, UserData.Name);
            PlayerPrefs.SetString(SURNAME_KEY, UserData.Surname);
            PlayerPrefs.SetString(USERNAME_KEY, UserData.Username);
            PlayerPrefs.SetString(PASSWORD_KEY, UserData.Password);
            PlayerPrefs.SetString(GENDER_KEY, UserData.Gender);
            PlayerPrefs.Save();
        }

        public static void LoadProfile()
        {
            string name = PlayerPrefs.GetString(NAME_KEY);
            string surname = PlayerPrefs.GetString(SURNAME_KEY);
            string username = PlayerPrefs.GetString(USERNAME_KEY);
            string password = PlayerPrefs.GetString(PASSWORD_KEY);
            string gender = PlayerPrefs.GetString(GENDER_KEY);
            SetUserData(new UserData(name, surname, username, password, gender));
        }

        public static void ClearProfile()
        {
            PlayerPrefs.DeleteKey(USERNAME_KEY);
            PlayerPrefs.DeleteKey(PASSWORD_KEY);
            PlayerPrefs.Save();
        }

        public static bool HasProfile()
        {
            return PlayerPrefs.HasKey(USERNAME_KEY);
        }
    }
}

/*
 * username - admin
 * password - 1234
 */