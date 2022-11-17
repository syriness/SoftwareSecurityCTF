using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ScoreManager : MonoBehaviour
{
    public int score = 0;
    public TextMeshProUGUI textScore = null;

    public void OnTargetHit()
    {
        score += 1;
    }

    // Start is called before the first frame update
    void Start()
    {
        textScore.text = "Score : 0";
    }

    // Update is called once per frame
    void Update()
    {
        textScore.text = "Score : " + score.ToString();        
    }
}
