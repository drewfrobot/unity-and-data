using System.Collections;
using System.Collections.Generic;
using UnityEngine;
// for sqlite interface
using System;
using System.Data;
using Mono.Data.Sqlite;

public class DBAccess : MonoBehaviour
{

    public GameObject barPrefab;
    public string irisSpecies = "setosa";
    public string databaseTable = "irisdb.sqlite";

    void Start()
    {

    // Output some information to the Console at runtime
    Debug.Log (Application.dataPath + "/" + databaseTable);
    //Base SQLite code - opens database
    string connectionString = "URI=file:" + Application.dataPath + "/" + databaseTable; //Path to database.
    IDbConnection dbcon;
    dbcon = (IDbConnection) new SqliteConnection(connectionString);
    dbcon.Open(); //Open connection to the database.
    IDbCommand dbcmd = dbcon.CreateCommand();

    //Define database queries

    //Uncomment line 31 for scenarios #1 and #3
    string sql = "SELECT SepalLength, SepalWidth, PetalLength, ColorCode " + "FROM iristbl";
    //Uncomment line 33 for scenario #2
    //string sql = "SELECT SepalLength, SepalWidth, PetalLength, ColorCode  " + "FROM iristbl WHERE Species = '" + irisSpecies + "'";
		
    dbcmd.CommandText = sql;
    IDataReader reader = dbcmd.ExecuteReader(); 

    while(reader.Read()) {
      float sepalLength = reader.GetFloat (0);
      float sepalWidth = reader.GetFloat (1);
      float petalLength = reader.GetFloat (2);
      string barColor = reader.GetString (3);
      //Uncomment line 44 for scenarios #1 and #2
      GameObject instanceBar = (GameObject)Instantiate(barPrefab, new Vector3(sepalWidth, petalLength , sepalLength), Quaternion.identity);
      //Uncomment lines 46/47 for scenario #3. Here the prefab is located on the horizontal with no height, then scaled to height.
      //GameObject instanceBar = (GameObject)Instantiate(barPrefab, new Vector3(sepalWidth, 0 , sepalLength), Quaternion.identity);
      //instanceBar.transform.localScale = new Vector3(0.05f,petalLength,0.05f);
            
      //Set color based on ColorCode in query
      Color newCol;
        if (ColorUtility.TryParseHtmlString(barColor, out newCol)) {
                instanceBar.GetComponent<Renderer>().material.color = newCol;
        }
    }

    // clean up
    reader.Close();
    reader = null;
    dbcmd.Dispose();
    dbcmd = null;
    dbcon.Close();
    dbcon = null;

    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
