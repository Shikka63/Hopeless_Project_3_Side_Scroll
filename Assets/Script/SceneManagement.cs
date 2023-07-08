using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneManagement : MonoBehaviour
{
    //public UIMenu uimenu;
    private void Start()
    {
        //uimenu = GetComponent<UIMenu>();
    }
    public void ChangeScene(int sceneIndex)
    {
        SceneManager.LoadScene(sceneIndex);
    }

    public void ChangeLevel(int level)
    {
        GameManager.Instance.ChangeLevel(level);
    }

    public void ResetLevel()
    {
        GameManager.Instance.ResetLevel();
        UIMenu.Instance.levelCurrent = GameManager.Instance.levelCurrent;
        GameManager.Instance.CheckSaveFile();
        UIMenu.Instance.AddChangeSceneListeners();
        UIMenu.Instance.DisableLockedLevel();
    }
}
