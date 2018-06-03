using UnityEngine;
using System.Collections;
using System;
using System.Runtime.Serialization.Formatters.Binary;
using System.IO;

public class RemoveAds : MonoBehaviour {

    public static RemoveAds control;
    public bool adsfree;

    void Awake()
    {
        if(control == null)
        {
            DontDestroyOnLoad(gameObject);
            control = this;
        }
        else if(control != this)
        {
            Destroy(gameObject);
        }
        loadadsfree();
    }

    public void save()
    {
        BinaryFormatter bf = new BinaryFormatter();
        FileStream file = File.Create(Application.persistentDataPath + "/playerInfo.dat");
        Debug.Log(Application.persistentDataPath);

        PlayerData data = new PlayerData();
        data.adsfree = adsfree;

        bf.Serialize(file, data);
        file.Close();
    }

    public void loadadsfree()
    {
        if(File.Exists(Application.persistentDataPath + "/playerInfo.dat"))
        {
            BinaryFormatter bf = new BinaryFormatter();
            FileStream file = File.Open(Application.persistentDataPath + "/playerInfo.dat", FileMode.Open);
            PlayerData data = (PlayerData)bf.Deserialize(file);
            file.Close();

            adsfree = data.adsfree;
        }
    }
}

[Serializable]
class PlayerData
{
    public bool adsfree;
}
