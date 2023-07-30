using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class test : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        Vector3 origin = new Vector3(0.05f, 0, 0); // 原点
        Vector3 direction = new Vector3(1, 0, 0); // X軸方向を表すベクトル
        Ray ray = new Ray(origin, direction); // Rayを生成
        Debug.DrawRay(ray.origin, ray.direction * 30, Color.red, 5.0f); // 長さ３０、赤色で５秒間可視化
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
