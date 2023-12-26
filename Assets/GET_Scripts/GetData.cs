using System.Collections;using System.Collections.Generic;using UnityEngine;using TMPro;using UnityEngine.Networking;using System;using System.Threading.Tasks;public class GetData : MonoBehaviour{    public string url;    public GameObject btnprefeb;    public Transform parent;    public Root root;    [Serializable]    public class Article    {        public Source source;        public string author;        public string title;        public string description;        public string url;        public string urlToImage;        public DateTime publishedAt;        public string content;    }    public class Root    {        public string status;        public int totalResults;        public List<Article> articles;    }    public class Source    {        public string id;        public string name;    }    private async void Start()    {        await GetFun();    }    public async Task GetFun()    {        using (UnityWebRequest webRequest = UnityWebRequest.Get("https://newsapi.org/v2/everything?q=keyword&apiKey=acf7d6dde18f4398b11bfb9f07e5bc07"))        {            await webRequest.SendWebRequest();            switch (webRequest.result)            {                case UnityWebRequest.Result.ConnectionError:                case UnityWebRequest.Result.DataProcessingError:                    Debug.LogError("The error: " + webRequest.error);                    break;                case UnityWebRequest.Result.Success:                    root = JsonUtility.FromJson<Root>(webRequest.downloadHandler.text);

                    for (int i = 0; i < root.articles.Count; i++)
                    {
                        GameObject obj = Instantiate(btnprefeb, parent);
                        obj.GetComponentInChildren<TMP_Text>().text += root.articles[i].author;
                        //await Task2();
                    }
                    Debug.Log(root.status);                    Debug.Log(root.totalResults);                   Debug.Log(root.articles[2].title);                    break;            }        }

        await Task.WhenAll(Task1(), Task3(), Task4());
     

    }    private async Task Task1()    {
        await Task.Delay(1000);        Debug.Log("Task 1 completed");    }    private async Task Task2()    {

        await Task.Delay(5000);
        Debug.Log(root.articles[2].title);        Debug.Log("Task 2 completed");

    }    private async Task Task3()    {
        await Task2();
        Debug.Log("Task 3 completed");

    }
    private async Task Task4()    {
        await Task.Delay(1000);
        Debug.Log("Task 4 completed");
    }}