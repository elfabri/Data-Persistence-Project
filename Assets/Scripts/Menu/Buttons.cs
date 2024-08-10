using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using TMPro;
#if UNITY_EDITOR
using UnityEditor;
#endif

public class Buttons : MonoBehaviour
{
    public Button start;
    public Button exit;
    public TMP_InputField playerName;

    public void StartClicked()
    {
        if (playerName.text != "")
        {
            GameManager.Instance.playerName = playerName.text;
            SceneManager.LoadScene(1);
        }
    }

    public void Exit()
    {
#if UNITY_EDITOR
        EditorApplication.ExitPlaymode();
#else
        Application.Quit();
#endif
    }
}
