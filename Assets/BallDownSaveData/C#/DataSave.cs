using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

public class DataSave : MonoBehaviour
{
    string Data_Temp;
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(Run5s());
        //SaveDataEvent();
    }

    void SaveDataEvent()
    {
        DateTime localDate = DateTime.Now;
        print(localDate.ToString("yyyyMMdd-HH-mm-ss"));
        string path = Application.persistentDataPath + localDate.ToString("yyyyMMdd-HH-mm-ss") + ".txt";
        if (!File.Exists(path))
        {
            File.WriteAllText(path, Data_Temp);
        }
    }

    IEnumerator Run5s()
    {
        float TempAX, TempAY, TempAZ, TempRX, TempRY, TempRZ;
        for (int i=0; i<50;i++)
        {
            
            TempAX = (float)((int)(transform.position.x * 1000))/ 1000;
            TempAY = (float)((int)(transform.position.y * 1000))/ 1000;
            TempAZ = (float)((int)(transform.position.z * 1000))/ 1000;
            TempRX = (float)((int)(transform.rotation.x * 1000))/ 1000;
            TempRY = (float)((int)(transform.rotation.y * 1000))/ 1000;
            TempRZ = (float)((int)(transform.rotation.z * 1000))/ 1000;

            Data_Temp = Data_Temp + TempAX + "\t"+ TempAY + "\t" + TempAZ + "\t" + TempRX + "\t" + TempRY + "\t" + TempRZ + "\n";
            yield return new WaitForSeconds(0.1f);
        }
      
        SaveDataEvent();
    }
    // Update is called once per frame
    void Update()
    {

    }
}