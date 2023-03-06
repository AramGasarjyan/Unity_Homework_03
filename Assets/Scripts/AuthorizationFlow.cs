using DefaultNamespace.UI;
using UnityEditor;
using UnityEngine;

namespace DefaultNamespace
{
    public class AuthorizationFlow : MonoBehaviour
    {
        [SerializeField] private LoginPanel loginPanel;
        [SerializeField] private AccountPanel accountPanel;
        [SerializeField] private RegistrationPanel registrationPanel;

        private AbstractPanel _currentPanel;

        private void Start()
        {
            Run();
        }

        private void OnEnable()
        {
            //Login Panel
            loginPanel.OnLoginComplete += OnLoginComplete;
            loginPanel.OnRegistrationButtonClick += OnRegistrationButtonClick;

            //Account Panel
            accountPanel.OnLogOut += OnAccountLogOut;

            //Registration panel
            registrationPanel.OnRegistrationComplete += OnRegistrationComplete;
        }

        private void OnDisable()
        {
            //Login Panel
            loginPanel.OnLoginComplete -= OnLoginComplete;
            loginPanel.OnRegistrationButtonClick -= OnRegistrationButtonClick;

            //Account Panel
            accountPanel.OnLogOut -= OnAccountLogOut;

            //Registration panel
            registrationPanel.OnRegistrationComplete -= OnRegistrationComplete;
        }

        private void Run()
        {
            if (Session.HasProfile())
            {
                Session.LoadProfile();
                ShowAccountPanel();
                return;
            }

            ShowLoginPanel();
        }

        private void ShowLoginPanel()
        {
            HidePrevious();
            loginPanel.Show();
            SetCurrent(loginPanel);
        }

        private void ShowAccountPanel()
        {
            HidePrevious();
            accountPanel.Setup(Session.UserData);
            accountPanel.Show();
            SetCurrent(accountPanel);
        }

        private void ShowRegistrationPanel()
        {
            HidePrevious();
            registrationPanel.Show();
            SetCurrent(registrationPanel);
        }

        private void OnLoginComplete(bool success)
        {
            if (success)
            {
                Session.SaveProfile();
                ShowAccountPanel();
                return;
            }


            Debug.LogError("Invalid credentials");
        }

        private void OnRegistrationButtonClick()
        {
            ShowRegistrationPanel();
        }

        private void OnRegistrationComplete(bool success)
        {
            if (success)
            {
                ShowLoginPanel();
                return;
            }

            Debug.LogError("Invalid credentials");
        }

        private void HidePrevious()
        {
            if (_currentPanel == null)
            {
                return;
            }

            _currentPanel.Hide();
        }

        private void SetCurrent(AbstractPanel panel)
        {
            _currentPanel = panel;
        }

        private void OnAccountLogOut()
        {
            Session.SetUserData(null);
            Session.ClearProfile();
            ShowLoginPanel();
        }
    }
}