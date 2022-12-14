using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using UnityEngine;

public static class SaveSystem
{
    static bool loadFlag;

    public static bool GetLoadFlag()
    {
        return loadFlag;
    }

    public static void SetLoadFlag(bool flag)
    {
        loadFlag = flag;
    }

    public static bool SavePlayer(PlayerController player)
    {
        BinaryFormatter formatter = new BinaryFormatter();

        string path = Application.persistentDataPath + "/player.data";
        FileStream stream = new FileStream(path, FileMode.Create);

        PlayerData data = new PlayerData(player);

        formatter.Serialize(stream, data);

        stream.Close();

        if(File.Exists(path))
        {
            return true;
        }
        else{
            return false;
        }
    }

    public static PlayerData LoadPlayer()
    {
        string path = Application.persistentDataPath + "/player.data";

        if(File.Exists(path))
        {
            BinaryFormatter formatter = new BinaryFormatter();

            FileStream stream = new FileStream(path, FileMode.Open);

            PlayerData data = formatter.Deserialize(stream) as PlayerData;

            stream.Close();

            return data;
        }
        else{
            Debug.Log("Save File Not Found in path: " + path);
            return null;
        }
    }
}
