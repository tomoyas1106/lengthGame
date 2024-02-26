using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <Summary>
/// Prefabからオブジェクトを生成するサンプルスクリプトです。
/// </Summary>
public class PrefabInstantiateSample : MonoBehaviour
{
    // オブジェクトを生成する元となるPrefabへの参照を保持します。
    public GameObject prefabObj;

    // 生成したオブジェクトの親オブジェクトへの参照を保持します。
    public Transform parentTran;

    // マテリアルを保持します。
    public Material matCyan;
    public Material matMagenta;
    public Material matYellow;

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

        // マテリアルをランダムで設定します。
        int materialId = Random.Range(0, 3);
        Material mat = matCyan;
        switch (materialId)
        {
            case 1:
                mat = matMagenta;
                break;
            case 2:
                mat = matYellow;
                break;
        }
        obj.GetComponent<MeshRenderer>().material = mat;
    }
}