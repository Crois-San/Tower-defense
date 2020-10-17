using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

//Описывает действия башни
public class Tower : MonoBehaviour
{
    //Список врагов на сцене
    private List<GameObject> enemies { get; set; }

    //Урон башни
    private int DamagePoints { get; set; } = 1;
    

    //Радиус обнаружения врага
    private float DetectionRadius { get; set; } = 2.5f;

    //Скорострельность башни, чем ниже значение, тем чаще происходит выстрел
    private float ShotSpeed { get; set; } = 0.5f;

    //Таймер
    private float Timer { get; set; } = 0;
    
    //Текущая цель башни
    private GameObject targetEnemy { get; set; }
    private Enemy targetEnemyScript { get; set; }
    
    //Меню улучшения башни
    [field:SerializeField]
    private GameObject UpgradeUI { get; set; }
    
    [field:SerializeField]
    private GameObject PlayerData { get; set; }
    private PlayerData pd { get; set; }

    private void Start()
    {
        pd = PlayerData.GetComponent<PlayerData>();
    }

    void Update()
    {
        //Сброс улучшений при начале новой игры
        if (pd.StartingOver)
        {
            DamagePoints = 1;
        }
        enemies = new List<GameObject>(GameObject.FindGameObjectsWithTag("Enemy"));
        //поиск врагов в сцене
        if (enemies != null)
        {
            //проверка на наличие врагов в радиусе обнаружения башни
            if (enemies.Any(e => Vector3.Distance(transform.position, e.transform.position) < DetectionRadius))
            {
                //Проверка врагов, которыен вышли из зоны видимости
                foreach (var e in enemies)
                {
                    if (Vector3.Distance(transform.position, e.transform.position) < DetectionRadius)
                    {
                        targetEnemy = e;
                        targetEnemyScript = targetEnemy.GetComponent<Enemy>();
                        break;
                    }
                }
                Timer += Time.deltaTime;
                //Производит выстрел
                if (Timer > ShotSpeed) 
                {
                    targetEnemyScript.HitPoints -= DamagePoints;
                    Timer = 0;
                }
                        
            }
        }
    }

    //Производит улучшение башни по клику мыши
    //Стоимость улучшения - 50 золота
    private void OnMouseDown()
    {
        Vector3 mousePos = Input.mousePosition;
        mousePos.z = Camera.main.nearClipPlane+1;
        UpgradeUI.transform.position =Camera.main.ScreenToWorldPoint(mousePos);
        UpgradeUI.SetActive(true);
        int gold = PlayerData.GetComponent<PlayerData>().Gold;
        if (gold >= 50)
        {
            PlayerData.GetComponent<PlayerData>().Gold -= 50;
            DamagePoints++;
        }
    }
}
