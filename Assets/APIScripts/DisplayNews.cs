//Display News

//using System.Collections;
//using System.Collections.Generic;
//using UnityEngine;
//using UnityEngine.Networking;
//using UnityEngine.UI;
//using TMPro;

//public class DisplayNews : MonoBehaviour
//{
//    public GameObject FullNews;
//    int NewsIndex;
//    public RawImage ThumbNail;

//    public void SetValue(int value)
//    {
//        NewsIndex = value;
//        Debug.Log(value);
//        StartCoroutine(GetRawImage(NewsIndex, FullNews.transform));
//        StartCoroutine(Read(NewsIndex));
//    }
//    public Root root;
//    IEnumerator Read(int TextNumber1)
//    {

//        UnityWebRequest url = UnityWebRequest.Get("https://newsapi.org/v2/everything?q=apple&from=2022-07-17&to=2022-07-17&sortBy=popularity&apiKey=e1fa14bc9882454cb387e335cc2abee0");
//        yield return url.SendWebRequest();

//        if (url.result != UnityWebRequest.Result.Success)
//        {
//            Debug.Log("---------error---------");
//        }
//        else
//        {
//            string result = url.downloadHandler.text;
//            root = JsonUtility.FromJson<Root>(result);

//            SetGroup1Headlines(TextNumber1);
//        }
//        url.Dispose();
//    }

//    IEnumerator GetRawImage(int imageIndex, Transform verticalGroup)
//    {
//        UnityWebRequest request = UnityWebRequestTexture.GetTexture(root.articles[imageIndex].urlToImage);
//        yield return request.SendWebRequest();
//        verticalGroup.transform.GetChild(1).GetComponent<RawImage>().texture = ((DownloadHandlerTexture)request.downloadHandler).texture;
//        request.Dispose();
//    }

//    public void SetGroup1Headlines(int TextNumber)
//    {

//        TextMeshProUGUI NewsTitle = FullNews.transform.GetChild(0).GetComponent<TextMeshProUGUI>();
//        if (NewsTitle != null)
//        {
//            NewsTitle.text = root.articles[TextNumber].title;
//            StartCoroutine(GetRawImage(NewsIndex, FullNews.transform));
//            TextMeshProUGUI NewsDetails = FullNews.transform.GetChild(2).GetChild(0).GetComponent<TextMeshProUGUI>();
//            NewsDetails.text = root.articles[TextNumber].description; //Description
//            TextMeshProUGUI NewsAuthor = FullNews.transform.GetChild(2).GetChild(0).GetChild(0).GetComponent<TextMeshProUGUI>();
//            NewsAuthor.text = root.articles[TextNumber].author; //Author

//        }
//        else
//        {
//            Debug.Log("something wrong with the textbox you are trying to reach");
//        }


//    }


//    [System.Serializable]
//    public class Article
//    {
//        public Source source;
//        public string author;
//        public string title;
//        public string description;
//        public string url;
//        public string urlToImage;
//        public string publishedAt;
//        public string content;
//    }

//    [System.Serializable]
//    public class Root
//    {
//        public string status;
//        public int totalResults;
//        public List<Article> articles;
//    }

//    [System.Serializable]
//    public class Source
//    {
//        public string id;
//        public string name;
//    }

//}