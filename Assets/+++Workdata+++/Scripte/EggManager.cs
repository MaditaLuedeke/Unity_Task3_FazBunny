using UnityEngine;

public class EggManager : MonoBehaviour
{
    [SerializeField] public int counterEggs = 0;
    [SerializeField] private uiManager uiManager;
    
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        counterEggs = 0;
        uiManager.UpdateEggText(counterEggs);
    }
    
    public void EggCollected()
    {
        counterEggs++;
        uiManager.UpdateEggText(counterEggs);
    }
    
}
