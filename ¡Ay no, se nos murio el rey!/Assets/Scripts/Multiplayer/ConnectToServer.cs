using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;
using Photon.Pun;
using UnityEngine.UI;

public class ConnectToServer : MonoBehaviourPunCallbacks
{
    [SerializeField]
    private TMP_Text _roomName;
    [SerializeField]
    private TMP_Text _buttonText;
    [SerializeField]
    private GameObject _button;

    public ConnectServerCanvas connectCanvases;
    public CreateOrJoinRoomsCanvas createOrJoinRoomsCanvas;

    public void OnClick_Connect()
    {
        if (_roomName.text.Length < 1)
            return;
        _buttonText.text = "Connecting...";
        _button.GetComponent<Button>().enabled = false;
        MasterManager.GameSettings._nickName = _roomName.text;
        PhotonNetwork.NickName = MasterManager.GameSettings.NickName;
        PhotonNetwork.GameVersion = MasterManager.GameSettings.GameVersion;
        PhotonNetwork.AutomaticallySyncScene = true;
        PhotonNetwork.ConnectUsingSettings();
    }

    public override void OnConnectedToMaster()
    {
        PhotonNetwork.JoinLobby();
    }

    public override void OnJoinedLobby()
    {
        connectCanvases.Hide();
        _buttonText.text = "Connect";
        _button.GetComponent<Button>().enabled = true;
        createOrJoinRoomsCanvas.Show();
    }
}
