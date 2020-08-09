﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
	public GameObject bulletPrefab;

	// Start is called before the first frame update
	void Start()
	{
			
	}

	// Update is called once per frame
	void Update()
	{
　　// プレイヤーの移動範囲を制限するRangeを呼び出す
　　transform.localPosition = Range.ClampPosition( transform.localPosition );
　　// 矢印キーでプレイヤーを移動する
		if (Input.GetKey (KeyCode.LeftArrow)) {
			transform.Translate (-0.1f, 0, 0);
		}
		if (Input.GetKey (KeyCode.RightArrow)) {
			transform.Translate ( 0.1f, 0, 0);
		}
		if (Input.GetKey (KeyCode.UpArrow)) {
			transform.Translate ( 0,0.1f, 0);
		}
		if (Input.GetKey (KeyCode.DownArrow)) {
			transform.Translate ( 0,-0.1f, 0);
		}
		if (Input.GetKeyDown (KeyCode.Space)) {
			// bulletPrefab を Player の位置に Player と同じ向きで配置
			Instantiate (bulletPrefab, transform.position, Quaternion.identity);
		}
	}
    // プレイヤーを削除する	
    public void DeletePlayer (){
        Destroy (gameObject);
　　}
}
