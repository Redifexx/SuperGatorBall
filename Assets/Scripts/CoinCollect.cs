using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoinCollect : MonoBehaviour
{
    public int coinCount = 0;
    public LevelData levelData;
    public GameData gameData;
    // Start is called before the first frame update
    void Start()
    {
        
    }
    public void OnTriggerEnter(Collider Col)
    {
        if (Col.gameObject.tag == "Coin")
        {
            bool coinTaken = true;
            if (coinTaken)
            {
                Debug.Log("Coin Collected");
                coinCount++;
                levelData.totalCoins--;
                gameData.coinText.text = levelData.totalCoins.ToString();
                Destroy(Col.gameObject);
                coinTaken = false;
            }
        }
    }
    public void OnTriggerExit(Collider Col)
    {
        if (Col.gameObject.tag == "Coin")
        {
            Destroy(Col.gameObject);
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
