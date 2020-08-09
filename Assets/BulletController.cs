using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletController : MonoBehaviour
{
　　//爆発エフェクトのPrefab
	public GameObject explodePrefab;
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
		transform.Translate (0, 0.2f, 0);

		if (transform.position.y > 5) {
			Destroy (gameObject);
		}
	}
    // オブジェクトにアタッチしたトリガーの中に別のオブジェクトが入ったとき(衝突判定がった時？)に呼び出されます。（2D 物理挙動のみ）
    // 入ったオブジェクトに関する詳細な情報は呼び出し時に渡される Collision2D 引数に代入されます。つまり衝突した Enemy
    // see: https://docs.unity3d.com/ja/current/ScriptReference/MonoBehaviour.OnTriggerEnter2D.html
    void OnTriggerEnter2D(Collider2D coll)
    {
        // 衝突した時にオブジェクトを消す
        // Enemy     
		Destroy (coll.gameObject);
        // Bullet
		Destroy (gameObject);
        // 衝突したときにスコアを更新する
		GameObject.Find ("Canvas").GetComponent<GameSystem> ().AddScore ();
        // 爆発エフェクトを作成	
		GameObject effect = Instantiate (explodePrefab, transform.position, Quaternion.identity) as GameObject;
		Destroy (effect, 1.0f);
	}
}
