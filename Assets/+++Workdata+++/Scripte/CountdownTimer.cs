using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class CountdownTimer : MonoBehaviour
{
    private bool timerActive;
    private float currentTime = 0f;
    private float startTime = 30f;
    
    [SerializeField] private TextMeshProUGUI countdownText;
    
    [SerializeField] private uiManager uiManager;
    [SerializeField] private CharacterController characterController;
    
    
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
            currentTime = startTime;
    }

    // Update is called once per frame
    void Update()
    {
        if (timerActive)
        {
            currentTime -= 1 * Time.deltaTime;
            countdownText.text = currentTime.ToString("0");
        }

        if (currentTime <= 0)
        {
            currentTime = 0;
            uiManager.LosePanel();
            characterController.canMove = false;
        }
    }

    public void StartTimer()
    {
        timerActive = true;
    }

    public void StopTimer()
    {
        timerActive = false;
    }
}
