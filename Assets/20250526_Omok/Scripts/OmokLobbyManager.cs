using Photon.Pun;
using Photon.Realtime;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;
public class OmokLobbyManager : MonoBehaviourPunCallbacks
{
    [SerializeField] private string gameVersion = "0.0.1";
    [SerializeField] private Button CreateRoomButton;
    [SerializeField] private Button EnterRoomButton;
    [SerializeField] private TMP_InputField inputField;
    [SerializeField] private GameObject inputFieldObject;
    private string roomName;


    private void Start()
    {
        CreateRoomButton.interactable = true;
        CreateRoomButton.onClick.AddListener(OnClickCreateRoomButton);
        EnterRoomButton.onClick.AddListener(OnClickEnterRoomButton);
        PhotonNetwork.ConnectUsingSettings();
        inputFieldObject.SetActive(false);
    }


    public override void OnConnectedToMaster()
    {
        CreateRoomButton.interactable = true;
        PhotonNetwork.JoinRoom("Room");
    }

    public override void OnJoinedRoom()
    {
        base.OnJoinedRoom();
        PhotonNetwork.LoadLevel("Room");
        Debug.Log("룸 접속 성공");
    }


    public override void OnDisconnected(DisconnectCause cause)
    {
        Debug.LogWarningFormat("Disconnected: {0}", cause);

        CreateRoomButton.interactable = false;
    }



    public void OnClickCreateRoomButton()
    {
        inputFieldObject.SetActive(true);


    }

    public void OnClickEnterRoomButton()
    {
        roomName = inputField.text;

        if (string.IsNullOrEmpty(roomName))
        {
            Debug.LogWarning("방 제목을 입력하세요.");
            return;
        }
        if (!PhotonNetwork.IsConnected)
        {
            Debug.LogWarning("Photon에 아직 연결되지 않았습니다.");
            return;
        }
        if (!PhotonNetwork.InLobby)
        {
            Debug.LogWarning("아직 로비에 입장하지 않았습니다. 잠시만 기다려주세요.");
            return;
        }
        RoomOptions options = new RoomOptions
        {
            IsVisible = true,
            IsOpen = true,
            MaxPlayers = 2,
            CleanupCacheOnLeave = true
        };
        PhotonNetwork.CreateRoom(roomName, options);

        //roomName = inputField.text;

        //if (!string.IsNullOrEmpty(roomName) && PhotonNetwork.IsConnected)
        //{
        //    PhotonNetwork.JoinRoom(roomName);

        //}

        //else
        //{
        //    Debug.LogFormat("Connect : {0}", gameVersion);

        //    PhotonNetwork.GameVersion = gameVersion;

        //    PhotonNetwork.ConnectUsingSettings();
        //}
    }

    public override void OnCreatedRoom()
    {
        Debug.Log("방 생성이 완료되었습니다.");
    }

    //public override void OnCreatedRoomFailed(short returnCode, string message)
    //{
    //    Debug.LogWarning($"방 생성 실패: {message}");
    //}

    
}
