using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelData : MonoBehaviour
{
    // Start is called before the first frame update
    public int totalCoins;
    void Start()
    {
        totalCoins = GameObject.FindGameObjectsWithTag("Coin").Length;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
