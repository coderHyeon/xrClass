// https://hkn10004.tistory.com/77
// https://m.blog.naver.com/PostView.nhn?blogId=rlawndks4204&logNo=221337190066&proxyReferer=https:%2F%2Fwww.google.com%2F
// https://stuban.tistory.com/56
// https://www.nuget.org/packages/Newtonsoft.Json/

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;
using Newtonsoft.Json;

public class Login_Backup : MonoBehaviour
{
    public class ResUserData
    {
        public List<UserData> userData;
    }

    public class UserData
    {
        public string username { get; set; }
        public int score { get; set; }
    }

    string loginUri;
    Dictionary<string, object> dicData =
        new Dictionary<string, object>();


    void Start()
    {
        loginUri = "http://localhost/login.php";

        StartCoroutine(LoginCoroutine("kch1234", "1234"));
    }

    IEnumerator LoginCoroutine(string username, string password)
    {
        WWWForm form = new WWWForm();
        form.AddField("loginUser", username);
        form.AddField("loginPass", password);

        using (UnityWebRequest www = UnityWebRequest.Post(loginUri, form))
        {
            yield return www.SendWebRequest();

            if (www.isNetworkError || www.isHttpError)
            {
                Debug.Log(www.error);
            }
            else
            {
                Debug.Log(www.downloadHandler.text);
                string data = www.downloadHandler.text;
                //ResUserData res =
                //    JsonFx.Json.JsonReader.Deserialize<ResUserData>(data);


                //string json = "{'username': 'kch', 'score': '3500'}";
                List<UserData> myRootObject =
                   JsonConvert.DeserializeObject<List<UserData>>(data);

                //Debug.Log(myRootObject.username + " : " + myRootObject.score);

                //string szUser = "";
                foreach (UserData userData in myRootObject)
                //foreach(UserData userData in res)
                {
                    //    szUser += userData.username + " ";
                    //    szUser += userData.score + "\r\n";
                    Debug.Log(userData.username + " : " + userData.score);
                }

                Debug.Log("End");
            }
        }
    }
}