using Assets.GameScripts.Models;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class TotalScore : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI score_text;
    private float totalScore;
    // Start is called before the first frame update
    void Start()
    {
        totalScore = (float)GameVars.conesCollected + GameVars.cameraSpeedCalculated;
        totalScore = Mathf.Round(totalScore * 10.0f) * 0.1f;
        score_text.text = "Score: " + totalScore;
        GameVars.cameraSpeedCalculated = GameVars.CameraMoveSpeed;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
