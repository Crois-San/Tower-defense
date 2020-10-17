using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//Восстановление переменных при рестарте игры
public class StartOver : MonoBehaviour
{
    public void Restart(GameObject playerData)
    {
        PlayerData pd = playerData.GetComponent<PlayerData>();
        pd.StartingOver = true;
        pd.Gold = 0;
        pd.Lives = 12;
        pd.Waves = 1;
        pd.Kills = 0;
        gameObject.SetActive(false);
    }
}
