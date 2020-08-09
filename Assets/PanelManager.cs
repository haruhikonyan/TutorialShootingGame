using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PanelManager : MonoBehaviour
{
    [SerializeField] GameObject GOPanel;

    // Start is called before the first frame update
    void Start()
    {
        PlayGame();
    }

    // パネルを表示する
    public void StopGame()
    {
        GOPanel.SetActive(true);
    }
    // パネルを非表示
    public void PlayGame()
    {
		GOPanel.SetActive(false);
    }
}
