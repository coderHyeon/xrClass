using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using UnityEngine.Networking;
using Newtonsoft.Json;


public class Database : MonoBehaviour
{
    public class DataScore //점수를 관리할 클래스 db의 내용을 읽고 쓰고 할려고함
    {
        public string name { get; set; } //아이디
        public int score { get; set; } //점수
    }


    void Start()
    {
        StartCoroutine(AddScoreCoroutine("psh12", 5000));
        StartCoroutine(GetScoreCoroutine());
    }

    private IEnumerator AddScoreCoroutine(string _name, int _score)
    {
        WWWForm form = new WWWForm();
        form.AddField("name", _name);
        form.AddField("score", _score);

        // using은 유니티 공식 없음 
        // 그러나 웹이랑 통신을 할 때는 여러가지 문제가 생길 수 있음
        // 통신이 끊길 수 도 있고 깨질 수 도 있기 때문에
        // 웹에서 받아온걸 복사해서 사용하니깐 사용하지 않을 때 자동으로 메모리에서 삭제해줌
        using (UnityWebRequest www =
            UnityWebRequest.Post("http://127.0.0.1/addscore.php", form))
        {
            yield return www.SendWebRequest();

            if (www.result == UnityWebRequest.Result.ConnectionError || 
                www.result == UnityWebRequest.Result.ProtocolError)
            {
                Debug.Log(www.error);
            }
        }

        Debug.Log("AddScore Success : " + _name + "(" + _score + ")");
    }

    private IEnumerator GetScoreCoroutine() {
        using (UnityWebRequest www =
            UnityWebRequest.PostWwwForm("http://127.0.0.1/getscore.php", "")) {
            yield return www.SendWebRequest();

            if (www.result == UnityWebRequest.Result.ConnectionError || www.result == UnityWebRequest.Result.ProtocolError) {
                Debug.Log(www.error);
            } else {
                Debug.Log(www.downloadHandler.text);
                string data = www.downloadHandler.text;

                List<DataScore> dataScores =
                   JsonConvert.DeserializeObject<List<DataScore>>(data);

                foreach (DataScore dataScore in dataScores) {
                    Debug.Log(dataScore.name + " : " + dataScore.score);
                }
            }
        }
    }
}