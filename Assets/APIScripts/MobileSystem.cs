//Mobile System

//using System.Collections;
//using System.Collections.Generic;
//using UnityEngine;
//using UnityEngine.Networking;
//using UnityEngine.UI;
//using TMPro;

//public class MobileSystem : MonoBehaviour
//{
//    public Root root;
//    public Transform NList;
//    public Transform NewsApp;



//    private void Start()
//    {
//        StartCoroutine(Read());
//    }


//    IEnumerator Read()
//    {
//        UnityWebRequest url = UnityWebRequest.Get("https://newsapi.org/v2/everything?q=apple&from=2022-07-17&to=2022-07-17&sortBy=popularity&apiKey=e1fa14bc9882454cb387e335cc2abee0");
//        //UnityWebRequest url = UnityWebRequest.Get("https://www.chamancgjsdos.com");

//        yield return url.SendWebRequest();

//        if (url.result != UnityWebRequest.Result.Success)
//        {
//            Debug.Log("---------error---------");
//        }

//        else
//        {
//            string result = url.downloadHandler.text;
//            root = JsonUtility.FromJson<Root>(result);
//            SetGroup1Headlines();
//        }
//        url.Dispose();
//    }

//    public void SetGroup1Headlines()
//    {
//        for (int i = 0; i < 20; i++)
//        {
//            TextMeshProUGUI currentTextBox = NList.transform.GetChild(i).GetChild(0).GetComponent<TextMeshProUGUI>();
//            if (currentTextBox != null)
//            {
//                currentTextBox.text = root.articles[i].title;
//                int childIndex = i;
//                StartCoroutine(GetRawImage(i, childIndex, NList.transform));
//            }
//            else
//            {
//                Debug.Log("something wrong with the textbox you are trying to reach");
//            }
//        }
//    }

//    IEnumerator GetRawImage(int imageIndex, int childIndex, Transform verticalGroup)
//    {
//        UnityWebRequest request = UnityWebRequestTexture.GetTexture(root.articles[imageIndex].urlToImage);
//        yield return request.SendWebRequest();
//        verticalGroup.transform.GetChild(childIndex).GetChild(1).GetComponent<RawImage>().texture = ((DownloadHandlerTexture)request.downloadHandler).texture;
//        request.Dispose();
//    }

//    public void OpenNewsApp()
//    {
//        NewsApp.gameObject.SetActive(true);
//    }

//    public void CloseNewsApp()
//    {
//        NewsApp.gameObject.SetActive(false);
//    }

//    //JsonData_Inspector...
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