using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;


public class PutData : MonoBehaviour
{ 
    void Start()
    {
        StartCoroutine(Upload());
    }

    IEnumerator Upload()
    {
        byte[] myData = System.Text.Encoding.UTF8.GetBytes("title");
        using (UnityWebRequest www = UnityWebRequest.Put("https://my-json-server.typicode.com/typicode/demo/posts", myData))
        {
            yield return www.SendWebRequest();

            if (www.result != UnityWebRequest.Result.Success)
            {
                Debug.Log(www.error);
            }
            else
            {
                Debug.Log(myData);
                Debug.Log(www.downloadHandler.text);
                Debug.Log("Upload complete!");
            }
        }
    }
}
