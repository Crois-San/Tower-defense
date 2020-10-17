using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

//Показывает номер волны на интерфейсе
public class ShowWaves : MonoBehaviour
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
        text.text =pd.Waves.ToString();
    }
}
