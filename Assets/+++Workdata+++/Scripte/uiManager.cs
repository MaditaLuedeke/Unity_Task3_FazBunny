using TMPro;
using UnityEngine;
using UnityEngine.InputSystem.HID;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class uiManager : MonoBehaviour
{
    [SerializeField] private CountdownTimer countdownTimer;
    
    [SerializeField] private GameObject mainMenu;
    [SerializeField] private Button quitButton;
    
    [SerializeField] private TextMeshProUGUI textEggCounter;
    [SerializeField] private TextMeshProUGUI textMeatCounter;
    [SerializeField] private GameObject losePanel;
    [SerializeField] private Button buttonTryAgain;
    
    [SerializeField] private GameObject winPanel;
    [SerializeField] private Button playAgainButton;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        mainMenu.SetActive(true);
        
        losePanel.SetActive(false);
        buttonTryAgain.onClick.AddListener(ReloadLevel);
        
        winPanel.SetActive(false);
        playAgainButton.onClick.AddListener(ReloadLevel);
        
        countdownTimer.StopTimer();
    }

    public void OpenLevel()
    {
        mainMenu.SetActive(false);
        countdownTimer.StartTimer();
    }

    public void QuitGame()
    {
        Application.Quit();
    }

    public void GoingToMainMenu()
    {
        mainMenu.SetActive(true);
    }
    
    public void UpdateEggText(int newEggCount)
    {
        textEggCounter.text = newEggCount.ToString();
    }

    public void UpdateMeatText(int newMeatCount)
    {
        textMeatCounter.text = newMeatCount.ToString();
    }

    public void LosePanel()
    {
        losePanel.SetActive(true);
        countdownTimer.StopTimer();
    }

    public void WinPanel()
    {
        winPanel.SetActive(true);
        countdownTimer.StopTimer();
    }

    void ReloadLevel()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
}

