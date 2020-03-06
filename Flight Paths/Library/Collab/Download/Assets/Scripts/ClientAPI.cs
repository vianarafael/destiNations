using System.Collections;
using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;
using SimpleJSON;
// added
class DataItem
{
    public string username;
}
// end
public class ClientAPI : MonoBehaviour
{
    [SerializeField]
    Airplane[] prefabs;
    public string url;
    public static object planeData = "the data";
    public string result;
    public object data;
    public GameObject globe;
    private Airplane instance;
    List<Airplane> airplanes;
    private string[] countryCodes = { "EG", "US", "DE", "GR", "FR", "CH", "BR", "GB", "AU", "CA", "RU", "JP", "TR", "UK", "TH", "MX", "PH", "DZ", "AE", "ZA", "KR", "ES", "AR", "IN" };
    void Awake()
    {
        airplanes = new List<Airplane>();
    }
    void Start()
    {
        StartCoroutine(Get(url));
    }
    public IEnumerator Get(string url)
    {
        using (UnityWebRequest www = UnityWebRequest.Get(url))
        {
            yield return www.SendWebRequest();
            if (www.isNetworkError)
            {
                Debug.Log(www.error);
            }
            else
            {
                if (www.isDone)
                {
                    result = @System.Text.Encoding.UTF8.GetString(www.downloadHandler.data);
                    // {"data":[{"to":{"city":"Oranjestad"
                    //DataItem deserialized = JsonUtility.FromJson<DataItem>(result);
                    var N = JSON.Parse(result);
                    string[] allData = { N["data"] };
                    var versionString = N["data"][0]["to"]["city"];
                    for (int i = 0; i < 100; i++)
                    {
                        Debug.Log(allData.Length);
                        Debug.Log(N["data"][i]["to"]["city"]);
                    }
                    //Debug.Log("Deserialized " + versionString);
                    data = JsonUtility.FromJson<object>(result);
                    globe = GameObject.Find("/earth/Icosphere");
                    Airplane instance = Instantiate(prefabs[0]);
                    Transform p = instance.transform;
                    p.parent = globe.transform;
                    //p.localPosition = ?????
                    Debug.Log(data);
                    for (var i = 0; i < countryCodes.Length; i++)
                    {
                        //Debug.Log(typeof(result));
                        //bool exists = Array.Exists(countryCodes);
                        //if (Array.Exists(countryCodes, element => element == result[i].to.country.cc))
                        //{
                        //	Debug.Log(element);
                        //}
                    }
                    airplanes.Add(instance);
                }
                else
                {
                    //handle problem
                    Debug.Log("Error: Could not get data");
                }
            }
        }
    }
}