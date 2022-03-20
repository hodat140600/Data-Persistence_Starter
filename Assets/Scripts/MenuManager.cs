using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

public struct UserInfo
{
    public string userName;
    public int userScore;
}
public class MenuManager : MonoBehaviour
{
    public static MenuManager Instance;
    public UserInfo user;

    private void Awake()
    {
        if (Instance != null) {
            Destroy(gameObject);
            return;
        }
        Instance = this;
        DontDestroyOnLoad(gameObject);
        LoadUserInfo();
        Debug.Log(Application.persistentDataPath);
    }
    

    [System.Serializable]
    public class SaveData{
        public UserInfo userInfo; 
    }
    public void SaveUserInfo() {
        SaveData data = new SaveData();
        data.userInfo = user;
        Debug.Log(data);
        string json = JsonUtility.ToJson(data.userInfo);
        Debug.Log(json);
        File.WriteAllText(Application.persistentDataPath + "/savefile.json", json);
    }
    public void LoadUserInfo() {
        string path = Application.persistentDataPath + "/savefile.json";
        if (File.Exists(path))
        {
            string json = File.ReadAllText(path);
            UserInfo data = JsonUtility.FromJson<UserInfo>(json);
            user = data;
            
            
            return;
        }
        user.userScore = 0;
    }
}
