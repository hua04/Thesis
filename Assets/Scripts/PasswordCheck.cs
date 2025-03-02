using System.Collections;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class PasswordCheck : MonoBehaviour
{

    public string PasswordField;

    public TextMeshProUGUI PasswordText;

    public GameObject incorrect;


    public TMP_InputField PasswordInput;

    public void Start()
    {
        incorrect.SetActive(false);
        PasswordInput.contentType = TMP_InputField.ContentType.Password;
    }
    public void UserLogin()
    {
        StartCoroutine(CheckText());
    }


    public IEnumerator CheckText()
    {
        PasswordField = PasswordInput.text;
        yield break;
    }

    public void CheckPassword()
    {
        string pass = PasswordInput.text;
        if (pass == "")
        {
            incorrect.SetActive(true);
        }
        else
        {
            SceneManager.LoadScene("GameScene");
        }
    }
}
