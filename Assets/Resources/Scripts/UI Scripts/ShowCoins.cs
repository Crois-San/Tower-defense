using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

//Показывает количество золота на интерфейсе
public class ShowCoins : MonoBehaviour
{
    public GameObject PlayerData { get; set; }
    private PlayerData pd { get; set; }
    private Text text { get; set; }
    void Start()
    {
        text = GetComponent<Text>();
        PlayerData = GameObject.Find("PlayerData");
        pd = PlayerData.GetComponent<PlayerData>();

    }
    
    void Update()
    {
        text.text =pd.Gold.ToString();
    }
}
