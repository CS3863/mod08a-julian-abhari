using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class UseData : MonoBehaviour
{/**
  * Tutorial link
  * https://github.com/tikonen/blog/tree/master/csvreader
  * */

    List<Dictionary<string, object>> data; 
    public GameObject myCube;//prefab
    int cubeCount; //variable 
    private float startDelay = 2.0f;
    private float timeInterval = 1.0f;

    void Awake()
    {

        data = CSVReader.Read("OnlyCO2");//udata is the name of the csv file 

        for (var i = 0; i < data.Count; i++)
        {
            //name, age, speed, description, is the headers of the database
            print("xco2 " + data[i]["xco2"]);
        }


    }//end Awake()

    // Use this for initialization
    void Start()
    {
        
        // InvokeRepeating("SpawnObject", startDelay, timeInterval);
    }//end Start()

    // Update is called once per frame
    void Update()
    {
        for (var i = 0; i < data.Count; i++)
        {
            float xco2 = (float)data[i]["xco2"];
            myCube.transform.localScale = new Vector3(xco2, xco2, xco2);
            // cubeCount += (int) xco2; // convert xco2 data to int and add to cubeCount
            // Debug.Log("cubeCount" +cubeCount);
        }
    }

    void SpawnObject()
    {
        //As long as cube count is not zero, instantiate prefab
        if (cubeCount > 0)
        {
            Instantiate(myCube);
            Debug.Log("instantiating cube - current cube count: " + cubeCount);
            cubeCount--;
        }
    }
}