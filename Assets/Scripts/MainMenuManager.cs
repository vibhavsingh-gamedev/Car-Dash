using DG.Tweening;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MainMenuManager : MonoBehaviour
{

    public Button playButton;
    public Button optionsButton;
    public Button quitButton;
    public Button backButton;

    public GameObject mainMenuPanel;
    public GameObject optionsMenuPanel;


    void Start()
    {
        playButton.onClick.AddListener(PlayButtonPressed);
        optionsButton.onClick.AddListener(OptionsButtonPressed);
        quitButton.onClick.AddListener(QuitButtonPressed);
        backButton.onClick.AddListener(BackButtonPressed);

        optionsMenuPanel.SetActive(false);
    }

    // BUTTON PRESSED

    void PlayButtonPressed()
    {
        PlayButtonAnimation(playButton.transform);
        Invoke(nameof(StartGame), 0.25f);
    }

    void OptionsButtonPressed()
    {
        PlayRotateAnimation(optionsButton.transform);

        mainMenuPanel.SetActive(false);
        optionsMenuPanel.SetActive(true);
    }

    void QuitButtonPressed()
    {
        PunchAnimation(quitButton.transform);
        Invoke(nameof(QuitGame), 0.3f);
    }

    void BackButtonPressed()
    {
        PunchAnimation(backButton.transform);

        optionsMenuPanel.SetActive(false);
        mainMenuPanel.SetActive(true);
    }


    public void StartGame() 
    {
        SceneManager.LoadScene("LoadingScene");
    }

    public void QuitGame()
    {
        Application.Quit();

        Debug.Log("Game Quit");
    }


    void PlayButtonAnimation(Transform button)
    {
        button.DOScale(1.2f, 0.2f)
            .SetEase(Ease.OutBack)
            .OnComplete(() => button.DOScale(1f, 0.2f));
    }

    void PlayRotateAnimation(Transform button)
    {
        button.DORotate(new Vector3(0, 0, 30), 0.2f)
            .SetLoops(2, LoopType.Yoyo)
            .SetEase(Ease.InOutSine);
    }

    void PunchAnimation(Transform button)
    {
        button.DOPunchScale(Vector3.one * 0.3f, 0.3f, 10, 1f);
    }


}
