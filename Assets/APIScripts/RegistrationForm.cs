//Registration Form

//using System.Collections;
//using System.Collections.Generic;
//using UnityEngine;
//using System.Text.RegularExpressions;
//using UnityEngine.Networking;
//using UnityEngine.UI;
//using TMPro;

//public class RegistrationForm : MonoBehaviour
//{
//    public TMP_InputField User_Name;
//    public TMP_InputField Email_Text;
//    public TMP_InputField Ph_No;
//    public TMP_InputField Address;
//    public TMP_InputField State;
//    public Root root;
//    int Unumber;

//    public VerticalLayoutGroup Vgroup;
//    public Transform UserNameButtonPanel;

//    public Transform UserDataPanel;

//    private void Start()
//    {
//        StartCoroutine(GetData());
//    }

//    IEnumerator GetData()
//    {
//        UnityWebRequest request = UnityWebRequest.Get("https://api.jsonbin.io/v3/b/62d6695c5ecb581b56c56c31");
//        request.SetRequestHeader("X-Master-Key", "$2b$10$3CHhA3lf9e7wQYpxPthwqOZCjW6ho/wFLzwynHMbSTSi0TmQ1LhYO");
//        request.SetRequestHeader("X-Access-Key", "$2b$10$ShcIwKJm9.ODS8JA2vMbHuTvZGX23XofxpHMtaPyiH7S0YcrSRuwO");

//        yield return request.SendWebRequest();
//        string result = request.downloadHandler.text;

//        var jsonData = SimpleJSON.JSON.Parse(result);
//        root = JsonUtility.FromJson<Root>(jsonData["record"].ToString());

//        Debug.Log(result);

//        UserDataPrint();
//        SetDetails(Unumber);
//        //request.Dispose();
//    }


//    public void UserDataPrint()
//    {
//        //Debug.Log(root.userList[0].UserName);

//        if (root.userList.Count > 10)
//        {
//            Vgroup.spacing = 40;
//        }
//        else if (root.userList.Count < 5)
//        {
//            Vgroup.spacing = -750;
//        }
//        else
//        {
//            Vgroup.spacing = 5;
//        }
//        for (int i = 0; i < root.userList.Count; i++)
//        {
//            TextMeshProUGUI UserNameTitle = UserNameButtonPanel.transform.GetChild(i).GetChild(0).GetComponent<TextMeshProUGUI>();
//            if (UserNameTitle != null)
//            {
//                UserNameTitle.text = root.userList[i].UserName;
//            }
//        }
//        for (int Index = root.userList.Count; Index < 20; Index++)
//        {
//            UserNameButtonPanel.GetChild(Index).gameObject.SetActive(false);
//        }
//    }


//    void SetDetails(int UserCountNumber)
//    {
//        TextMeshProUGUI _UserName = UserDataPanel.transform.GetChild(0).GetChild(0).GetComponent<TextMeshProUGUI>();
//        _UserName.text = root.userList[UserCountNumber].UserName;
//        TextMeshProUGUI _UserState = UserDataPanel.transform.GetChild(1).GetChild(0).GetComponent<TextMeshProUGUI>();
//        _UserState.text = root.userList[UserCountNumber].User_State;
//    }

//    public void OnUserClick(int UserNumber)
//    {
//        Unumber = UserNumber;
//        StartCoroutine(GetData());
//        Debug.Log(Unumber);
//    }

//    public void OnSubmit()
//    {
//        if (DataNotEmpty())
//        {
//            User user = new User();

//            user.UserName = User_Name.text;
//            user.User_EmailId = Email_Text.text;
//            user.PhNo = long.Parse(Ph_No.text);
//            user.User_Address = Address.text;
//            user.User_State = State.text;
//            root.userList.Add(user);
//            string JsonstrOutput = JsonUtility.ToJson(root);
//            UnityWebRequest WriteUrl = UnityWebRequest.Put("https://api.jsonbin.io/v3/b/62d6695c5ecb581b56c56c31", JsonstrOutput);
//            WriteUrl.SetRequestHeader("Content-Type", "application/json");
//            WriteUrl.SetRequestHeader("X-Master-Key", "$2b$10$3CHhA3lf9e7wQYpxPthwqOZCjW6ho/wFLzwynHMbSTSi0TmQ1LhYO");
//            WriteUrl.SendWebRequest();
//            //File.AppendAllText(Application.dataPath + "/JsonTxt.txt", JsonstrOutput);
//            ResetUI();
//        }

//    }
//    bool DataNotEmpty()
//    {
//        if (User_Name.text == "")
//        {
//            Debug.Log("Enter Name");
//            return false;
//        }

//        if (Email_Text.text == "")
//        {
//            Debug.Log("Enter Email");
//            return false;
//        }

//        bool isEmail = Regex.IsMatch(Email_Text.text, @"\A(?:[a-z0-9!#$%&'*+/=?^_`{|}~-]+(?:\.[a-z0-9!#$%&'*+/=?^_`{|}~-]+)*@(?:[a-z0-9](?:[a-z0-9-]*[a-z0-9])?\.)+[a-z0-9](?:[a-z0-9-]*[a-z0-9])?)\Z", RegexOptions.IgnoreCase);
//        if (isEmail == false)
//        {
//            Debug.Log("please enter valid Email address");
//            return false;
//        }

//        if (Ph_No.text == "")
//        {
//            Debug.Log("Enter Number");
//            return false;
//        }

//        if (Address.text == "")
//        {
//            Debug.Log("Enter Address");
//            return false;
//        }

//        if (State.text == "")
//        {
//            Debug.Log("Enter State");
//            return false;
//        }
//        return true;
//    }

//    public void ResetUI()
//    {
//        User_Name.text = "";
//        Address.text = "";
//        Ph_No.text = "";
//        Email_Text.text = "";
//        State.text = "";
//    }

//    [System.Serializable]
//    public class User
//    {
//        public string UserName;
//        public string User_EmailId;
//        public long PhNo;
//        public string User_Address;
//        public string User_State;
//    }
//    [System.Serializable]
//    public class Root
//    {
//        public List<User> userList;
//    }    