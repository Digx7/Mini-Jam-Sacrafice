using UnityEngine;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;

public static class SaveSystem
{
  static string path = Application.persistentDataPath + "/score.fun";

  public static void SaveScore(ScoreBoard_SO score){
    BinaryFormatter formatter = new BinaryFormatter();

    FileStream stream = new FileStream(path, FileMode.Create);

    ScoreBoard_Data data = new ScoreBoard_Data(score);

    formatter.Serialize(stream, data);
    stream.Close();
  }

  public static ScoreBoard_Data LoadScore(){
    if (File.Exists(path)){
      BinaryFormatter formatter = new BinaryFormatter();
      FileStream stream = new FileStream(path, FileMode.Open);

      ScoreBoard_Data data = formatter.Deserialize(stream) as ScoreBoard_Data;
      stream.Close();

      return data;

    }else{
      Debug.LogWarning("Save file not found in " + path);
      return null;
    }
  }

  public static void DeleteScore(){
    if(File.Exists(path)){
      File.Delete(path);
    }else{
      Debug.LogWarning("Save file not found in " + path);
    }
  }
}
