using System.Collections;
using UnityEngine;

using UnityEngine.Networking;

public class Login : MonoBehaviour {
    private string loginUri = "http://127.0.0.1/login.php";

    private void Start() {
        // 아이디와 패스워드가 있는지 검사
        StartCoroutine(LoginCoroutine("psh12", "psh1234"));

       // Debug.Log(System.DateTime.Now.ToString("yyyy-MM-dd-hh-mm-ss"));
       // Debug.Log(System.DateTime.Now.ToString("yyyy-mm-dd-hh-mm-ss"));
    }

    private IEnumerator LoginCoroutine(
        string _id, string _pw) {
        WWWForm form = new WWWForm();
        form.AddField("id", _id); // key:loginUser - velue : 사용자에게 입력받은 값
        form.AddField("pw", _pw);

        using (UnityWebRequest www =
            UnityWebRequest.Post(loginUri, form)) {
            yield return www.SendWebRequest(); //결과를 받을 때까지 대기 서버와 통신이라 비동기 방식 얼마가 걸리지 모름

            if (www.result == UnityWebRequest.Result.ConnectionError || www.result == UnityWebRequest.Result.ProtocolError) {
                Debug.Log(www.error);
            } else {
                Debug.Log(www.downloadHandler.text);//웹서버를 통신을 할 때 무조건 문자열로 주고 받음 그러하여 결과값은 문자로 오게됨
            }
        }
    }
}