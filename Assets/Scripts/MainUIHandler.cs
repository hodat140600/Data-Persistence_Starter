using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MainUIHandler : MonoBehaviour
{
    [SerializeField] public Text bestScoreTxt;
    private void Awake()
    {
        bestScoreTxt = GameObject.Find("BestScoreText").GetComponentInChildren<Text>();
    }
    private void Start()
    {
        if (MenuManager.Instance.user.userScore != 0)
        {
            bestScoreTxt.text += MenuManager.Instance.user.userName + " : " + MenuManager.Instance.user.userScore;
        }
    }
}
