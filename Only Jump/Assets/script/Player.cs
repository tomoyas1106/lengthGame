using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

 
public class Player : MonoBehaviour
{
    //Vector3 posi = transform.position;    
    private Rigidbody rb;
    float speed = 3.0f;
    //private int upForce;
    private bool isGround;
    private float jumpPower = 400.0f; //ジャンプ力
    public  Text text;
 
 
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        //this.rb = GetComponent<Rigidbody>();
    }
 
    void Update()
    {
        // Wキー（前方移動）
        if (Input.GetKey(KeyCode.W))
        {
            rb.velocity = transform.forward * speed;
        }
        // Sキー（後方移動）
        if (Input.GetKey(KeyCode.S))
        {
            rb.velocity = - transform.forward * speed;
        }
        // Dキー（右移動）
        if (Input.GetKey(KeyCode.D))
        {
            rb.velocity = - transform.right * speed;
        }
        // Aキー（左移動）
        if (Input.GetKey(KeyCode.A))
        {
            rb.velocity = transform.right * speed;
        }
        // スペースが押されたらジャンプさせる
        if (Input.GetKeyDown(KeyCode.Space)&& isGround)
        {
            rb.AddForce(transform.up * jumpPower);
        }
        GameObject player = GameObject.Find("Player");
        Vector3 tmp = new Vector3(player.transform.position.x, player.transform.position.y, player.transform.position.z);
        Debug.Log(tmp);

        if (tmp.y < 0)
        {
            SceneManager.LoadScene("end");
        }
    }
 
    void OnTriggerStay(Collider other)
    {
        if(other.CompareTag("Plane"))
        {
            isGround = true;
        }
    


    }
 
    void OnTriggerExit(Collider other)
    {
        if(other.CompareTag("Plane"))
           isGround = false;
    }
   
}