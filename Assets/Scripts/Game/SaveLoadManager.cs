using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using UnityEngine;

public class SaveLoadManager
{
    public static string dataFolder = "Save Data";
    public static string dataExtension = ".dat";

    public static void SaveData<T>(T _data, string fileName = null)
    {
        string dataDirectory = Path.Combine(Application.persistentDataPath, dataFolder);

        if (!Directory.Exists(dataDirectory)) {
            Directory.CreateDirectory(dataDirectory);
        }

        if (fileName == null) {
            fileName = typeof(T).Name + dataExtension;
        }
        string dataPath = Path.Combine(dataDirectory, fileName);

        BinaryFormatter bf = new BinaryFormatter();
        FileStream file = File.Open(dataPath, FileMode.OpenOrCreate);
        bf.Serialize(file, _data);
        file.Close();
    }

    public static T LoadData<T>(string fileName = null)
    {
        string dataDirectory = Path.Combine(Application.persistentDataPath, dataFolder);

        if (!Directory.Exists(dataDirectory)) {
            Debug.LogWarning("Directorio no existe.");
            return default;
        }

        if (fileName == null) {
            fileName = typeof(T).Name + dataExtension;
        }
        string dataPath = Path.Combine(dataDirectory, fileName);

        if (File.Exists(dataPath)) {
            BinaryFormatter bf = new BinaryFormatter();
            FileStream file = File.Open(dataPath, FileMode.Open);
            try {
                object aux = bf.Deserialize(file);
                file.Close();
                return (T)aux;

            } catch (System.Exception) {
                Debug.LogError("Archivo Corrupto.");
                file.Close();
                return default;
                throw;
            }
        } else {
            Debug.LogWarning("Archivo no existe: " + dataPath);
            return default;
        }
    }
}
