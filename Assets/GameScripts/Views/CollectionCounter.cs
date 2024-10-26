using TMPro;
using UnityEngine;
// If using TextMeshPro

// If using standard UI Text

namespace Assets.GameScripts
{
    public class CollectionCounter : MonoBehaviour
    {
        public TextMeshProUGUI CounterText; 
        private int _collectiblesCount = 0;

        private void Start()
        {
            UpdateCounterText();
        }

        public void IncrementCounter()
        {
            _collectiblesCount++;
            UpdateCounterText();
        }

        private void UpdateCounterText()
        {
            CounterText.text = " " + _collectiblesCount;
        }
    }
}