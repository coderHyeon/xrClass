using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

using UnityEngine.SceneManagement;
using Photon.Pun;
using Photon.Realtime;
using TMPro;


public class TitleConnectLobby : MonoBehaviourPunCallbacks
{
    [SerializeField] private string nickName = string.Empty;

    [SerializeField] private Button connectBtn = null;

    private string myNicName;


    private void Start()
    {
        connectBtn.interactable = true;
    }

    public void OnValueChanged(string _nickName)
    {
        nickName = _nickName;
        connectBtn.interactable = _nickName.Length > 0;
        PhotonNetwork.NickName = nickName;
    }

    public void OnSubmitMade()
    {
        if (string.IsNullOrEmpty(nickName))
        {
            Debug.Log("닉네임이 비어있음");
            return;
        }

        if (PhotonNetwork.IsConnected)
        {
            PhotonNetwork.JoinLobby();
        }
        else
        {
            PhotonNetwork.ConnectUsingSettings();
        }
    }

    public override void OnConnectedToMaster()
    {
        Debug.LogFormat("마스터에 연결됨 : {0}", nickName);
        connectBtn.interactable = false;
        PhotonNetwork.JoinLobby();
        Debug.Log("마스터 서버 접속 성공");
    }

    public override void OnJoinedLobby()
    {
        base.OnJoinedLobby();
        PhotonNetwork.LoadLevel("OmokLobbyScene");
        Debug.Log("로비접속 성공");
    }
}
