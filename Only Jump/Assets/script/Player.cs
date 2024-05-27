using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using UnityEngine.UIElements;

public class Player : MonoBehaviour
{
    //Vector3 pos = transform.position;    
    private Rigidbody rb;
    public float speed = 3.0f;
    public float jumpPower = 400.0f; // ジャンプ力
    private bool isGround;
    private Player player;
    public Text text;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    void Update()
    {
        // プレイヤーの移動
        Vector3 movement = new Vector3();

        if (Input.GetKey(KeyCode.W))
        {
            movement.z -= 1;
        }
        if (Input.GetKey(KeyCode.S))
        {
            movement.z += 1;
        }
        if (Input.GetKey(KeyCode.D))
        {
            movement.x -= 1;
        }
        if (Input.GetKey(KeyCode.A))
        {
            movement.x += 1;
        }

        // 移動速度を加算
        rb.AddForce(movement * speed);

        // スペースキーが押されたらジャンプ

        Debug.Log($"Space: {Input.GetKeyDown(KeyCode.Space)} && isGround {isGround}");

        if (Input.GetKeyDown(KeyCode.Space) && isGround)
        {
            Debug.Log(" jaump: ");
            rb.AddForce(Vector3.up * jumpPower);
            isGround = false; // ジャンプ中は地面にいないと判断
        }

        // プレイヤーのポジションを取得し、コンソールに出力
        Vector3 playerPosition = transform.position;
        //Debug.Log("Player Position: " + playerPosition);

        // プレイヤーの位置をText UIに表示（オプション）
        if (text != null)
        {
            text.text = "Player Position: " + playerPosition.ToString();
        }
        //y座標が0以下になった場合にEndシーンへの移動
        if ( playerPosition.y <  0)
        {
            SceneManager.LoadScene("End");
        }
    }

    void OnCollisionStay(Collision other)
    {
        //地上にいる場合の
        if(other.gameObject.CompareTag("Plane"))
        {
            Debug.Log("Player is on the ground.");
            isGround = true;
        }
    }

    void OnCollisionExit(Collision other)
    {
        //空中にいる間のboolの判定を取る
        if(other.gameObject.CompareTag("Plane"))
        {
            Debug.Log("Player left the ground.");
            isGround = false;
        }
    }
}