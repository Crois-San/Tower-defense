using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

//Данные игрока
public class PlayerData : MonoBehaviour
{
    //Кол-во золота
    public int Gold { get; set; } = 0;

    //Кол-во жизней
    public int Lives { get; set; } = 12;

    //Номер волны
    public int Waves { get; set; } = 1;

    //Кол-во убийств
    public int Kills { get; set; } = 0;

    //Нажата ли кнопка "заново" пр проигрыше? Используется в сбросе улучшений башен
    public bool StartingOver { get; set; } = false;
    
    //Меню проигрыша
    [field:SerializeField]
    private GameObject GameOverPanel { get; set; }

    //Конфиг. файл
    private IniFile ini;
    
    void Start()
    {
        Gold = 0;
        Lives = 12;
        Waves = 1;
        Kills = 0;
        ini = new IniFile();
    }
    
    void Update()
    {
        //Проигрыш игрока
        if (Lives <= 0)
        {
            GameOverPanel.SetActive(true);
            if (StartingOver)
            {
                StartingOver = false;
            }
            Lives = 0;
        }
    }
}
