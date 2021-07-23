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
        for(int i=0; i<50;i++)
        {
            Data_Temp = Data_Temp + transform.position.x+"\t"+ transform.position.y + "\t" + transform.position.z + "\t" + transform.rotation.x + "\t" + transform.rotation.y + "\t" + transform.rotation.z + "\n";
            yield return new WaitForSeconds(0.1f);
        }
      
        SaveDataEvent();
    }
    // Update is called once per frame
    void Update()
    {

    }
}