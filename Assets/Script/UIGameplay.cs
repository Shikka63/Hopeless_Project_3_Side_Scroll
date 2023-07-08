using UnityEngine;
using UnityEngine.UI;

public class UIGameplay : MonoBehaviour 
{   
    [Header("Scene Index")]
    [SerializeField] private int sceneIndex = 0;

    [Header("Gameplay Buttons")]
    public Button buttonResume;
    public Button buttonPause;
    public Button buttonMenu;

    public GameObject panelPaused;

    private void Start() 
    {
        buttonMenu.onClick.AddListener(() => GameManager.Instance.ChangeScene(sceneIndex));
        buttonPause.onClick.AddListener(HandleButtonClick);
        buttonResume.onClick.AddListener(HandleButtonClick);
    }

    private void HandleButtonClick()
    {
        if(GameManager.Instance.isPaused)
        {
            GameManager.Instance.Resume();
            buttonPause.gameObject.SetActive(true);
            panelPaused.SetActive(false);
        }
        else
        {
            GameManager.Instance.Pause();
            buttonPause.gameObject.SetActive(false);
            panelPaused.SetActive(true);
        }
    }
}