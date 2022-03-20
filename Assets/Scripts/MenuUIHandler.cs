using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;
#if UNITY_EDITOR
using UnityEditor;
#endif

// Sets the script to be executed later than all default scripts
// This is helpful for UI, since other things may need to be initialized before setting the UI
[DefaultExecutionOrder(1000)]

public class MenuUIHandler : MonoBehaviour
{
    public static MenuUIHandler Instance { get; private set; }
    public TMP_InputField userInput;
    public TMP_Text bestScoreTxt;
    public string currentUser;
    private void Awake()
    {
        Instance = this;
        userInput = GameObject.Find("InpuUsertField").GetComponent<TMP_InputField>();
        bestScoreTxt = gameObject.GetComponentInChildren<TMP_Text>();
    }
    private void Start()
    {
        //MenuManager.Instance.LoadUserInfo();

        bestScoreTxt.text += ":" + MenuManager.Instance.user.userName + " : " + MenuManager.Instance.user.userScore;
    }
    private void InputUserName() {
        currentUser = userInput.text;
    }

    public void StartNew() {
        InputUserName();
        //Debug.Log("User name: " + MenuManager.Instance.user.userName);
        SceneManager.LoadScene(1);
    }
    public void QuitApplication() {
#if UNITY_EDITOR
        EditorApplication.ExitPlaymode();
#else
        Application.Quit();
#endif
        //MenuManager.Instance.SaveUserInfo();
    }
}
