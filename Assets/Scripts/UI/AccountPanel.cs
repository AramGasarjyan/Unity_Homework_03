using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace DefaultNamespace.UI
{
    public delegate void LogOutDelegate();

    public class AccountPanel : AbstractPanel
    {
        [SerializeField] private TMP_InputField nameInputField;
        [SerializeField] private TMP_InputField surnameInputField;
        [SerializeField] private TMP_InputField userNameInputField;
        [SerializeField] private TMP_Dropdown genderDropdown;
        [SerializeField] private Button logOutButton;
        public event LogOutDelegate OnLogOut;

        public void Setup(UserData userData)
        {
            nameInputField.text = userData.Name;
            surnameInputField.text = userData.Surname;
            userNameInputField.text = userData.Username;
            genderDropdown.options[0].text = userData.Gender;
        }

        private void OnEnable()
        {
            logOutButton.onClick.AddListener(OnLogOutButtonClicked);
        }

        private void OnDisable()
        {
            logOutButton.onClick.RemoveListener(OnLogOutButtonClicked);
        }

        private void OnLogOutButtonClicked()
        {
            OnLogOut?.Invoke();
        }
    }
}