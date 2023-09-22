using UnityEngine;
using UnityEngine.Networking;
using System.Collections;
using System.Collections.Generic;

// UnityWebRequest.Get example

// Access a website and use UnityWebRequest.Get to download a page.
// Also try to download a non-existing page. Display the error.

public class WebRequestExample : MonoBehaviour
{
    void Start()
    {
        List<int> pepe = new List<int>();
        pepe.Add(1);
        pepe.Add(2);
        Debug.Log(pepe.Count);
        pepe.Insert(1, 4);
        Debug.Log(pepe.Count);
     


        // A correct website page.
        StartCoroutine(GetRequest("https://pastebin.com/raw/2AYrLkhk"));

        // A non-existing page.
        //StartCoroutine(GetRequest("https://error.html"));
    }

    IEnumerator GetRequest(string uri)
    {
        using (UnityWebRequest webRequest = UnityWebRequest.Get(uri))
        {
            // Request and wait for the desired page.
            yield return webRequest.SendWebRequest();

            string[] pages = uri.Split('/');
            int page = pages.Length - 1;

            switch (webRequest.result)
            {
                case UnityWebRequest.Result.ConnectionError:
                case UnityWebRequest.Result.DataProcessingError:
                    Debug.LogError(pages[page] + ": Error: " + webRequest.error);
                    break;
                case UnityWebRequest.Result.ProtocolError:
                    Debug.LogError(pages[page] + ": HTTP Error: " + webRequest.error);
                    break;
                case UnityWebRequest.Result.Success:
                    Debug.Log(pages[page] + ":\nReceived: " + webRequest.downloadHandler.text);
                    break;
            }
        }
    }
}