using UnityEngine;

public class EggManager : MonoBehaviour
{
    [SerializeField] public int counterEggs = 0;
    [SerializeField] public int counterMeat = 0;
    [SerializeField] private uiManager uiManager;
    
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        counterEggs = 0;
        uiManager.UpdateEggText(counterEggs);
        
        counterMeat = 0;
        uiManager.UpdateMeatText(counterMeat);
    }
    
    public void EggCollected()
    {
        counterEggs++;
        uiManager.UpdateEggText(counterEggs);
        
        counterMeat++;
        uiManager.UpdateMeatText(counterMeat);
    }
    
}
