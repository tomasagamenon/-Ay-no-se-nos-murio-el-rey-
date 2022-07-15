using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoomsCanvases : MonoBehaviour
{
    [SerializeField]
    private ConnectServerCanvas _connectServerCanvas;
    public ConnectServerCanvas ConnectServerCanvas { get { return _connectServerCanvas; } }
    [SerializeField]
    private CreateOrJoinRoomsCanvas _createOrJoinRoomsCanvas;
    public CreateOrJoinRoomsCanvas CreateOrJoinRoomsCanvas { get { return _createOrJoinRoomsCanvas; } }
    [SerializeField]
    private CurrentRoomCanvas _currentRoomCanvas;
    public CurrentRoomCanvas CurrentRoomCanvas { get { return _currentRoomCanvas; } }

    private void Awake()
    {
        FirstInitialize();
    }

    private void FirstInitialize()
    {
        ConnectServerCanvas.FirstInitialize(this);
        CreateOrJoinRoomsCanvas.FirstInitialize(this);
        CurrentRoomCanvas.FirstInitialize(this);
    }
}
