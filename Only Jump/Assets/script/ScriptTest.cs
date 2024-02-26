
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <Summary>
/// Prefabからオブジェクトを生成するサンプルスクリプトです。
/// </Summary>
public class ScriptTest : MonoBehaviour
{
    // オブジェクトを生成する元となるPrefabへの参照を保持します。
    public GameObject prefabObj;

    // 生成したオブジェクトの親オブジェクトへの参照を保持します。
    public Transform parentTran;



    // Prefabを生成する高さを定義します。
    public float height;

    void Start()
    {

    }

    void Update()
    {
        // フレームカウントが10の倍数の時にオブジェクトを生成します。
        if (Time.frameCount % 10 == 0)
        {
            CreateObject();
        }
    }

    /// <Summary>
    /// Prefabからオブジェクトを生成します。
    /// </Summary>
    void CreateObject()
    {
        // ゲームオブジェクトを生成します。
        GameObject obj = Instantiate(prefabObj, Vector3.zero, Quaternion.identity);

        // ゲームオブジェクトの親オブジェクトを設定します。
        obj.transform.SetParent(parentTran);

        // ゲームオブジェクトの位置を設定します。
        obj.transform.localPosition = new Vector3(0f, height, 0f);

    }
}
