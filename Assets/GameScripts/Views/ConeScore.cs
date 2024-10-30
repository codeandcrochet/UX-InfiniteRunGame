using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using Assets.GameScripts.Models;
public class Score : MonoBehaviour
{

    [SerializeField] TextMeshProUGUI cones_text;
   
    // Start is called before the first frame update
    void Start()
    {
        cones_text.text = "Cones Collected: " + GameVars.conesCollected.ToString();
    }

    // Update is called once per frame
    void Update()
    {

    }
}
