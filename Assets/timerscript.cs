using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class timerscript : MonoBehaviour
{
    // Start is called before the first frame update
    public int counter = 30;

    public Text Timer;
    void Start()
    {
        Timer.text = counter.ToString();
        StartCoroutine(hitungmundur());
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    IEnumerator hitungmundur()

    {
        while (counter > 0)
        {
            yield return new WaitForSeconds(1);
            counter -= 1;
            Timer.text = counter.ToString();

        }

        Timer.text = "GAME OVER!!";
    }

}
