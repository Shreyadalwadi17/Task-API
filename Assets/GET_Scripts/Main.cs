using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.Networking;
using System;

public class Main : MonoBehaviour
{
    public string url;
    public GameObject btnprefeb;
    public Transform parent;


    [Serializable]

    public class Article
    {
        public Source source;
        public string author;
        public string title;
        public string description;
        public string url;
        public string urlToImage;
        public DateTime publishedAt;
        public string content;
    }

    public class Root
    {
        public string status;
        public int totalResults;
        public List<Article> articles;
    }

    public class Source
    {
        public string id;
        public string name;
    }

    void Start()
    {
        StartCoroutine(GetRequest(url));
    }

    public void refresh()
    {
        Start();
    }

    IEnumerator GetRequest(string url)
    {
        using (UnityWebRequest webRequest = UnityWebRequest.Get(url))
        {
            yield return webRequest.SendWebRequest();


            switch (webRequest.result)
            {
                case UnityWebRequest.Result.ConnectionError:
                case UnityWebRequest.Result.DataProcessingError:
                    Debug.LogError("the error " + webRequest.error);
                    break;
                case UnityWebRequest.Result.Success:

                    Root facts = new Root();
                    facts = JsonUtility.FromJson<Root>(webRequest.downloadHandler.text);


                    for (int i = 0; i < facts.articles.Count; i++)
                    {
                        GameObject obj = Instantiate(btnprefeb, parent);
                        obj.GetComponentInChildren<TMP_Text>().text += facts.articles[i].author;
                    }


                    Debug.Log(facts.status);
                    Debug.Log(facts.totalResults);
                    //Debug.Log(facts.articles[1].source.id);
                    //Debug.Log(facts.articles[1].source.name);

                    break;
            }

        }
    }


}
