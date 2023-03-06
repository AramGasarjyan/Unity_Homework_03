using DefaultNamespace;
using DefaultNamespace.UI;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace DefaultNamespace.UI
{
    public delegate void RegistrationCompleteDelegate(bool success);
    public class RegistrationPanel : AbstractPanel
    {
        [SerializeField] private TMP_InputField nameInputField;
        [SerializeField] private TMP_InputField surnameInputField;
        [SerializeField] private TMP_InputField usernameInputField;
        [SerializeField] private TMP_InputField passwordInputField;
        [SerializeField] private TMP_Dropdown userGenderDropdown;
        [SerializeField] private Button RegisterButton;

        public event RegistrationCompleteDelegate OnRegistrationComplete;

        private void OnEnable()
        {
            RegisterButton.onClick.AddListener(OnRegisterButtonClicked);
        }

        private void OnDisable()
        {
            RegisterButton.onClick.RemoveListener(OnRegisterButtonClicked);
        }

        private void OnRegisterButtonClicked()
        {
            string name = nameInputField.text;
            string surname = surnameInputField.text;
            string username = usernameInputField.text;
            string password = passwordInputField.text;
            string gender = userGenderDropdown.options[userGenderDropdown.value].text;

            Debug.Log($"Name {name} surname {surname} username {username} password {password} gender {gender} ");
            if (MatchingCriterias(name, surname, username, password, gender)) 
            {
                DataStore.AddUser(new UserData(name, surname, username, password, gender));
                OnRegistrationComplete?.Invoke(true);
            }
            else
            {
                OnRegistrationComplete?.Invoke(false);
            }

            
        }

        private bool MatchingCriterias(string name, string surname, string username, string password, string gender)
        {
            return name != string.Empty && surname != string.Empty &&
                username != string.Empty && password != string.Empty && gender != string.Empty;
        }

    }
}
