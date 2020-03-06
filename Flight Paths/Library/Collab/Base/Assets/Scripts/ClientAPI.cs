using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;

public class ClientAPI : MonoBehaviour
{
    public string url;
    public static object planeData;

    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(Get(url));
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public IEnumerator Get(string url)
    {
        using(UnityWebRequest www = UnityWebRequest.Get(url))
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
                    //handle result
                    var result = System.Text.Encoding.UTF8.GetString(www.downloadHandler.data);
                    planeData = result;
                    Debug.Log("We have data" + planeData);
                }
                else
                {
                    //handle problemr
                    Debug.Log("Error: Could not get data");
                }
            }
        }
    }
}
