using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CreateOrJoinRoomsCanvas : MonoBehaviour
{
    [SerializeField]
    private CreateRoomMenu _createRoomMenu;
    private RoomsCanvases _roomsCanvases;
    [SerializeField]
    private RoomListingsMenu _roomListingsMenu;

    public void FirstInitialize(RoomsCanvases canvases)
    {
        _roomsCanvases = canvases;
        _createRoomMenu.FirstInitialize(canvases);
        _roomListingsMenu.FirstInitialize(canvases);
    }
    public void Show()
    {
        gameObject.SetActive(true);
    }

    public void Hide()
    {
        gameObject.SetActive(false);
    }
}
