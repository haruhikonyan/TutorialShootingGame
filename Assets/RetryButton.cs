using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class RetryButton : MonoBehaviour
{
    public void OnRetry(){
    // リトライボタンを押すとシーンをロードする
        SceneManager.LoadScene("SampleScene");
    }
}
