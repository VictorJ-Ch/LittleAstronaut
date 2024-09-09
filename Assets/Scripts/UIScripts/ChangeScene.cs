using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class ChangeScene : MonoBehaviour
{
    public string sceneName;
    Button button;

    void Start()
    {
        button = GetComponent<Button>();
        button.onClick.AddListener(ChangingScene);
    }

    public void ChangingScene()
    {
        Debug.Log("Button pressed");
        SceneManager.LoadScene(sceneName);
    }
}
