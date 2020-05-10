using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class scoringScript : MonoBehaviour
{
    public TextMeshProUGUI scoringText1, scoringText2;
    private int score1=0, score2=0;
    // Start is called before the first frame update
    void Start()
    {
        scoringText1.text = score1.ToString();
        scoringText2.text = score2.ToString();
    }


    public void UpdateScore(string namaWall)
    {
        if(namaWall=="tembokL")
        {
            score2 +=1;
            scoringText2.text = score2.ToString();
        }
        else if(namaWall=="tembokR")
        {
            score1 +=1;
            scoringText1.text = score1.ToString();
        }
    }
}
