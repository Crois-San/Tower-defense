using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

//Показывает количество убийств на интерфейсе
public class ShowKills : MonoBehaviour
{
    [field:SerializeField]
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
        text.text = pd.Kills.ToString();
    }
}
