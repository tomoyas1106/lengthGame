using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Score : MonoBehaviour
{
    public  float _score = 0f;
    public  Text text;

    void Update()
    {
       _score += Time.deltaTime;
    }
    // Update is called once per frame
    public void ShowRate()
    {
        float score = _score;

        text.text = $"{score:P0}";
    }
}
