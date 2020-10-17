using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


//Действия при проходе врага в конец пути
public class Lose : MonoBehaviour
{
    private GameObject PlayerData { get; set; }
    private PlayerData pd { get; set; }
    void Start()
    {
        PlayerData = GameObject.Find("PlayerData");
        pd = PlayerData.GetComponent<PlayerData>();
    }

    //Отнимает кол-во жизней игрока, равное урону прошедшего врага
    //И удаляет его со сцены
    private void OnTriggerEnter2D(Collider2D other)
    {
        pd.Lives -= other.gameObject.GetComponent<Enemy>().DamagePoints;
        Destroy(other.gameObject);
    }
}
