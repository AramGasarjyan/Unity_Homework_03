using System;
using DefaultNamespace;
using DefaultNamespace.UI;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public delegate void LoginCompleteDelegate(bool success);
public class LoginPanel : AbstractPanel
{
    [SerializeField] private TMP_InputField usernameInputField;
    [SerializeField] private TMP_InputField passwordInputField;
    [SerializeField] private Button loginButton;
    [SerializeField] private Button registrationButton;

    public event LoginCompleteDelegate OnLoginComplete;
    public event Action OnRegistrationButtonClick;
    
    private void OnEnable()
    {
        loginButton.onClick.AddListener(OnLoginButtonClicked);
        registrationButton.onClick.AddListener(OnRegistrationButtonClicked);
    }

    private void OnDisable()
    {
        loginButton.onClick.RemoveListener(OnLoginButtonClicked);
    }

    private void OnLoginButtonClicked()
    {
        string username = usernameInputField.text;
        string password = passwordInputField.text;

        Debug.Log($"Username: {username}, Password: {password}");

        if (DataStore.TryFind(username, password, out UserData userData))
        {
            Session.SetUserData(userData);
            OnLoginComplete?.Invoke(true);
        }
        else
        {
            OnLoginComplete?.Invoke(false);
        }
    }

    private void OnRegistrationButtonClicked()
    {
        OnRegistrationButtonClick?.Invoke();
    }
}