using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//Описывает врага
public class Enemy : MonoBehaviour
{
    //Кол-во жизней врага
    public int HitPoints { get; set; } = 3;
    //Урон врага
    public int DamagePoints { get; set; } = 1;
    //Награда за убийство врага
    public int Reward { get; set; } = 10;
    
    //точки маршрута врага
    [field:SerializeField]
    private Transform[] points { get; set; }

    //Порядок прохода точек маршрута
    private int n;
    //скорость движения врага
    private const float MOVEMENT_SPEED = 2.5f;
    [field:SerializeField]
    private GameObject PlayerData { get; set; }
    private PlayerData pd { get; set; }
    
    protected void Start()
    {
        PlayerData = GameObject.Find("PlayerData");
        pd = PlayerData.GetComponent<PlayerData>();


    }
    
    void Update()
    {
        Movement();
        HitPointCheck();
        
        

    }

    //Расчет маршрута врага по пути
    //производится по точкам, расположенным на сцене
    private void Movement()
    {
        if (n==0)
        {
            transform.position = Vector3.MoveTowards(transform.position,points[0].position,MOVEMENT_SPEED * Time.deltaTime);
            if (transform.position == points[0].position)
            {
                transform.rotation = Quaternion.Euler(0,0,0);
                n = 1;
            }
                
        }
        else if(n==1)
        {
            transform.position = Vector3.MoveTowards(transform.position,points[1].position,MOVEMENT_SPEED * Time.deltaTime);
            if (transform.position == points[1].position)
            {
                transform.rotation = Quaternion.Euler(0,0,90);
                n = 2;
            }
                
        }
        else
        {
            transform.position = Vector3.MoveTowards(transform.position,points[2].position,MOVEMENT_SPEED * Time.deltaTime);
        }
    }

    //Проверка здоровья врага
    //если оно равно 0, удаляет врага со сцены
    private void HitPointCheck()
    {
        if (HitPoints <= 0)
        {
            Destroy(gameObject);
            pd.Gold += Reward;
            pd.Kills++;
        }
    }


}
