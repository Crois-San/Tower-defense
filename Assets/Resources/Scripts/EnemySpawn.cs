using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//Спавнер врагов в начале пути
public class EnemySpawn : MonoBehaviour
{
    [field:SerializeField]
    private GameObject Enemy{get; set; }
    public GameObject PlayerData { get; set; }
    private PlayerData pd { get; set; }

    //Задержка между врагами в волне
    private float SpawnDelay { get; set; } = 1f;
    
    //Количество заспавненных врагов
    private int SpawnNumber { get; set; }

    //Таймеры
    private float Timer { get; set; }
    private float WaveTimer { get; set; } 
    
    //Кол-во врагов в текущем фрейме
    private int k;
    private bool isNotCalculated = true;
    private IniFile ini;

    
    void Start()
    {
        PlayerData = GameObject.Find("PlayerData");
        pd = PlayerData.GetComponent<PlayerData>();
        ini = new IniFile();
    }
    
    void Update()
    {
        //Расчет кол-ва врагов в волне от номерв волны до номера волны + 5
        if (isNotCalculated)
        {
            SpawnNumber = Random.Range(pd.Waves,pd.Waves+5);
            isNotCalculated = false;
        }
        
        Timer += Time.deltaTime;
        
        //Спавн врагов
        if (k <= SpawnNumber)
        {
            if (Timer >= SpawnDelay)
            {
                if (Enemy != null)
                {
                    GameObject en = Instantiate(Enemy);
                    en.GetComponent<Enemy>().HitPoints += pd.Waves;
                    en.GetComponent<Enemy>().Reward *= pd.Waves;
                    en.GetComponent<Enemy>().DamagePoints += pd.Waves;
                    k++;
                }
                Timer = 0f;
            }
        }
        else
        {
            WaveTimer += Time.deltaTime;
            //чтение задержки между волнами из конфиг. файла
            //просчет времени между волнами
            if (WaveTimer >= float.Parse(ini.IniReadValue("Time between waves","WAVE_DELAY")))
            {
                pd.Waves++;
                isNotCalculated = true;
                k = 0;
                WaveTimer = 0f;
            }
        }
        
        
    }
    
}
