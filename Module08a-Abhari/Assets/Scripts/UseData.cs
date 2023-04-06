using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting.Dependencies.NCalc;

public class UseData : MonoBehaviour
{/**
  * Tutorial link
  * https://github.com/tikonen/blog/tree/master/csvreader
  * */

    public object dataObject;
    List<Dictionary<string, object>> data; 
    public GameObject myCube;

    int currentEntry;
    private float startDelay = 2.0f;
    private float timeInterval = 0.05f;

    void Awake()
    {

        data = CSVReader.Read("OnlyCO2");//udata is the name of the csv file 

        for (var i = 0; i < data.Count; i++)
        {
            //name, age, speed, description, is the headers of the database
            print("xco2 " + data[i]["xco2"]);
        }
        currentEntry = 0;
    }

    // Use this for initialization
    void Start()
    {
        InvokeRepeating("SpawnObject", startDelay, timeInterval);
    }

    // Update is called once per frame
    //void Update()
    //{
    //    SpawnObject();
    //}

    void SpawnObject()
    {
        Debug.Log("Spawn Object called");
        dataObject = data[currentEntry]["xco2"];
        float co2Data = map(System.Convert.ToSingle(dataObject), 388.09f, 426.59f, 1, 3);
        float scaledData = Mathf.Exp(co2Data);
        currentEntry += 1;

        transform.localScale = new Vector3(scaledData, scaledData, scaledData);
        Debug.Log("co2 count: " + currentEntry + "\nco2 data: " + co2Data);
    }

    float map(float value, float domainMin, float domainMax, float newDomainMin, float newDomainMax)
    {
        return newDomainMin + ((newDomainMax - newDomainMin) / (domainMax - domainMin)) * (value - domainMin);
    }
}