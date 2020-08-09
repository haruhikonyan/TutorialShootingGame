using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
	public GameObject bulletPrefab;
	//爆発エフェクトのPrefab
	public GameObject explodePrefab;
	Vector3 mousePos;

	// Start is called before the first frame update
	void Start()
	{
			
	}

	// Update is called once per frame
	void Update()
	{
　　// プレイヤーの移動範囲を制限するRangeを呼び出す
　　transform.localPosition = Range.ClampPosition( transform.localPosition );
		Move();
		if (Input.GetKeyDown (KeyCode.Space) || Input.GetMouseButtonDown(0)) {
			// bulletPrefab を Player の位置に Player と同じ向きで配置
			Instantiate (bulletPrefab, transform.position, Quaternion.identity);
		}
	}
	// プレイヤーを削除する	
	public void DeletePlayer (){
			Destroy (gameObject);
　　}
	// see: https://i-school.memo.wiki/d/%A3%B1%A3%B4%A1%A5Android%A4%C7%A4%CE%A5%B9%A5%EF%A5%A4%A5%D7%C1%E0%BA%EE%A4%F2%BC%C2%C1%F5%A4%B9%A4%EB%28Unity%202019%B0%CA%B9%DF%29
	void Move() {
		// マウス左クリック(画面タッチ)が行われたら
		if (Input.GetMouseButtonDown(0)) {
			// タッチした位置を代入
			mousePos = Camera.main.ScreenToWorldPoint ( Input.mousePosition );
		}
    if (Input.GetMouseButton(0))
    {
			// ベクトルの引き算を行い、現在のタッチ位置とその１フレーム前のタッチ位置との差分を方向として代入
			Vector3 mouseDiff = Camera.main.ScreenToWorldPoint ( Input.mousePosition ) - mousePos;
			// 次のフレームのタッチ情報を計算できるように現在のタッチ位置を1フレーム前のタッチ位置として代入
			// これにより、方向の取得→更新をタッチしている間繰り返している
			mousePos = Camera.main.ScreenToWorldPoint ( Input.mousePosition );

			// 現在のPlayerの位置に対して、タッチ位置の移動方向を使って移動先を算出する
			Vector3 newPos = transform.position + mouseDiff;

			// Playerオブジェクトの位置を更新して移動を解決する
			transform.position = newPos;
    }


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
	}
	void OnTriggerEnter2D(Collider2D coll)
	{
		GameObject effect = Instantiate (explodePrefab, transform.position, Quaternion.identity) as GameObject;
		Destroy (effect, 1.0f);
		GameObject.Find ("Canvas").GetComponent<GameSystem> ().GameOver ();
	}
}
