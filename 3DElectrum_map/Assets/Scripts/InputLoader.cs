using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputLoader : MonoBehaviour {
    public string[] items;
    public float testparser;

    // Use this for initialization
    IEnumerator Start()
    {
        WWW LocationInfo = new WWW("http://localhost/ConnectUnity/LocationInfo");
        yield return LocationInfo;
         string itemDataString = LocationInfo.text;
          string positionInfo = LocationInfo.text;
          print(itemDataString);
          items = itemDataString.Split(';');
        //  print(GetDataValue(items[2], "Pos_Z:"));
        GetDataValue(items[2], "Pos_Z:");
      }

      void GetDataValue(string data, string index)
      {
          string value = data.Substring(data.IndexOf(index)+index.Length);
          if(value.Contains("|")) value = value.Remove(value.IndexOf("|"));
          testparser = float.Parse(value);
      }
   //     updateCharacterPosition();
    }
 /*   void updateCharacterPosition()
    {

       string connectionParameter = string.Format("Server={0};" +
          "Database={1};" +
          "User ID={2};" +
          "Password={3};" +
          "Pooling={4}", "localhost", "register", "root", "********", "False");

        MySqlConnection DBCon = new MySqlConnection(connectionParameter);
        DBCon.Open();
        MySqlCommand DBCmd = DBCon.CreateCommand();

        Vector3 newPos = new Vector3(0, 0, 0);

        string loadCoordinates = string.Format("select {0}, {1}, {2} from {3} where {4} = '{5}';",
        "positionX", "positionY", "positionZ", "login", "user", PLAYER_NAME);

        //The loadCoordinates return a string like this, for example: "select positionX, positionY, positionZ from login where user = 'exampleUserName';"


        DBCmd.CommandText = loadCoordinates;

        MySqlDataReader reader = DBCmd.ExecuteReader();

        while (reader.Read())
        {

            newPos.x = (float)reader["positionX"];
            newPos.y = (float)reader["positionY"];
            newPos.z = (float)reader["positionZ"];

        }

        reader.Close();
        reader = null;
        DBCmd = null;
        DBCon.Close();
        DBCon = null;
        print(newPos);
        transform.position = newPos;

    }*/

