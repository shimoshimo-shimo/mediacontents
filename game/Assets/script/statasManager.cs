using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class statasManager 
{
    public static int HP;
    
    public static void SaveData()
    {
        PlayerPrefs.SetInt("HP", HP);
    }
    
    public static void LoadData()
    {
        HP = PlayerPrefs.GetInt("HP", 100);
    }


    
};
