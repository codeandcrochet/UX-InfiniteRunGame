using UnityEngine;
using TMPro; // If using TextMeshPro
using UnityEngine.UI; // If using standard UI Text

public class CollectionCounter : MonoBehaviour
{
    public TextMeshProUGUI counterText; // Use TextMeshProUGUI if using TextMeshPro
    // public Text counterText; // Uncomment this if using standard Text
    private int collectiblesCount = 0;

    private void Start()
    {
        UpdateCounterText();
    }

    public void IncrementCounter()
    {
        collectiblesCount++;
        UpdateCounterText();
    }

    private void UpdateCounterText()
    {
        counterText.text = "Collected: " + collectiblesCount;
    }
}