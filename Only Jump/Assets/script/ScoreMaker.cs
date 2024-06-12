using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScoreMaker : MonoBehaviour
{
    public static  float _score = 0f;
    private float scoreRate = 1f;
    // Start is called before the first frame update
    void Start()
    {
        Debug.Log("(x, y, z) = " + transform.localScale);
        Debug.Log("x = " + transform.localScale.x);
        Debug.Log("y = " + transform.localScale.y);
        Debug.Log("z = " + transform.localScale.z);
    }

    // Update is called once per frame
    void Update()
    {
        _score += scoreRate*Time.deltaTime;
        if (_score > 10 ){
            transform.localScale = new Vector3(2, 2, 2); // スケールの縮小
        }
        // if (_score > 18){
        //
        // }
        if (_score > 20){
            transform.localScale = new Vector3(1, 1, 1); // スケールの縮小
        }
    }
    
}
