using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;
using System;

public class PostData : MonoBehaviour
{
    [Serializable]
    public class userdata
    {
        public string id;
        public string title;

    }

    void Start()
    {
        StartCoroutine(Upload());
    }

    IEnumerator Upload()
    {
        WWWForm form = new WWWForm();
        form.AddField("a", "abc");
       


        UnityWebRequest www = UnityWebRequest.Post("https://my-json-server.typicode.com/typicode/demo/posts",form);
        yield return www.SendWebRequest();
      

        switch (www.result)

        {
            case UnityWebRequest.Result.ConnectionError:
            case UnityWebRequest.Result.DataProcessingError:
                Debug.LogError("the error " + www.error);
                break;
            case UnityWebRequest.Result.Success:


                userdata ud = new userdata();
                ud = JsonUtility.FromJson<userdata>(www.downloadHandler.text);

                Debug.Log(www.downloadHandler.text);
                Debug.Log("Form upload complete!");
               
                break;
        }
      
}
    }