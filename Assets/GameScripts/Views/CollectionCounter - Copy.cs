using UnityEngine;
using TMPro; // If using TextMeshPro
using UnityEngine.UI;
using Assets.GameScripts.Models; // If using standard UI Text

public class CollectionCounter : MonoBehaviour
{
    public TextMeshProUGUI counterText; // Use TextMeshProUGUI if using TextMeshPro
    // public Text counterText; // Uncomment this if using standard Text
    public int collectiblesCount = 0;

    private void Start()
    {
        UpdateCounterText();
        GameVars.conesCollected = collectiblesCount;
    }

    public void IncrementCounter()
    {
        collectiblesCount++;
        UpdateCounterText();
    }

    private void UpdateCounterText()
    {
        counterText.text = " " + collectiblesCount;
    }
    private void Update()
    {
        GameVars.conesCollected = collectiblesCount;
    }
}