using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Networking;

public class Airplane : MonoBehaviour
{
    public string ccTo;
    public string ccFrom;
    public string countryName;
    public string flag;
    public Image flagImage;

    public int ShapeID { get; set; } = int.MinValue;
    public GameObject CountryCanvas;
    public GameObject UI;
    //public Transform uiTR;

    //public Button open;
    //void Start()
    //{
    //    Button openWindow = open.GetComponent<Button>();
    //    openWindow.onClick.AddListener(CountryFactsOpener);
    //}

    //void CountryFactsOpener()
    //{
    //    //CountryCanvas = GameObject.Find("CountryFacts").gameObject;
    //    Debug.Log("CountryCanvas");
    //}

    void OnMouseDown()
    {
        UI = GameObject.Find("/UIComponents");
        Transform uiTr = UI.transform;
        foreach (Transform child in uiTr)
        {
            if (child.tag == "CountryFacts")
            {
                foreach (Transform grandchild in child)
                {
                    if (grandchild.tag == "mainText")
                    {
                        grandchild.GetComponent<UnityEngine.UI.Text>().text = countryName;
                        //IEnumerator DownloadImg(string url)
                        //{
                        //    UnityWebRequest request = UnityWebRequestTexture.GetTexture(url);
                        //    yield return request.SendWebRequest();

                        //    //flagImage.sprite = Sprite.Create(www.texture, new Rect(0, 0, www.texture.width, www.texture.height), new Vector2(0, 0));
                        //grandchild.GetComponent<Image>().sprite = ((DownloadHandlerTexture)request.downloadHandler).texture;
                        //}

                    }
                    child.gameObject.SetActive(true);
                }
            }
            //CountryCanvas = GameObject.FindWithTag("CountryFacts");

            //CountryCanvas.transform.gameObject.SetActive(true);

        }
    }

    //private void Start()
    //{
    //    StartCoroutine(DownloadImg(flag));
    //}


}

//void Start()
//{
//    StartCoroutine(DownloadImage(url));
//}

//IEnumerator DownloadImage(string MediaUrl)
//{
//    UnityWebRequest request = UnityWebRequestTexture.GetTexture(MediaUrl);
//    yield return request.SendWebRequest();
//    if (request.isNetworkError || request.isHttpError)
//        Debug.Log(request.error);
//    else
//        YourRawImage.texture = ((DownloadHandlerTexture)request.downloadHandler).texture;
//}