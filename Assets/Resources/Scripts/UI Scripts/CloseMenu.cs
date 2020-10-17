using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CloseMenu : MonoBehaviour
{
    // Закрывает меню
    public void Close()
    {
        gameObject.SetActive(false);
    }
}
