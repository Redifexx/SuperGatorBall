using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class GameData : MonoBehaviour
{
    public GameObject world;
    public LevelData levelData;
    public TextMeshProUGUI coinText;
    // Start is called before the first frame update
    void Start()
    {
        coinText.text = levelData.totalCoins.ToString();
    }

    // Update is called once per frame
    void Update()
    {
    }
}
