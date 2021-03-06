using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using Photon.Pun;
using Photon.Realtime;

public class CreateRoomMenu : MonoBehaviourPunCallbacks
{
    [SerializeField]
    private TMP_Text _roomName;
    [SerializeField]
    private int _maxPlayers;
    [SerializeField]
    private int _waitPlayer;

    private RoomsCanvases _roomsCanvases;

    [SerializeField]
    private TMP_Text _currentRoomName;


    public void FirstInitialize(RoomsCanvases canvases)
    {
        _roomsCanvases = canvases;
    }

    public void OnClick_CreateRoom()
    {
        if (!PhotonNetwork.IsConnected)
            return;
        _currentRoomName.text = _roomName.text;
        RoomOptions options = new RoomOptions();
        options.MaxPlayers = (byte)_maxPlayers;
        options.PlayerTtl = _waitPlayer;
        options.IsVisible = true;
        PhotonNetwork.JoinOrCreateRoom(_roomName.text, options, TypedLobby.Default);
    }

    public override void OnCreatedRoom()
    {
        _roomsCanvases.CurrentRoomCanvas.Show();
        _roomsCanvases.CreateOrJoinRoomsCanvas.Hide();
    }

    public override void OnCreateRoomFailed(short returnCode, string message)
    {
        base.OnCreateRoomFailed(returnCode, message);
    }
}
