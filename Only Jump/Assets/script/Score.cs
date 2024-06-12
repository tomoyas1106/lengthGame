using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class Score : MonoBehaviour
{
    public  Text text;


    void Update()
    {
        ShowRate();
    }
    // Update is called once per frame
    public void ShowRate()
    {

        text.text = $"{Mathf.FloorToInt(ScoreMaker._score)}";
    }
}
