using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
using Photon.Realtime;

public class RoomListingsMenu : MonoBehaviourPunCallbacks
{
    [SerializeField]
    private Transform _content;
    [SerializeField]
    private RoomListing _roomListing;

    private List<RoomListing> _listings = new List<RoomListing>();
    private RoomsCanvases _roomsCanvases;

    public float timeBetweenUpdates;
    private float _nextUpdate;

    public void FirstInitialize(RoomsCanvases canvases)
    {
        _roomsCanvases = canvases;
    }

    public override void OnJoinedRoom()
    {
        _roomsCanvases.CurrentRoomCanvas.Show();
    }

    public override void OnRoomListUpdate(List<RoomInfo> roomList)
    {
        if(Time.time >= _nextUpdate)
        {
            UpdateRoomList(roomList);
            _nextUpdate = Time.time + timeBetweenUpdates;
        }
    }

    private void UpdateRoomList(List<RoomInfo> list)
    {
        foreach(RoomListing roomListing in _listings)
        {
            Destroy(roomListing.gameObject);
        }
        _listings.Clear();
        foreach(RoomInfo room in list)
        {
            RoomListing newRoom = Instantiate(_roomListing, _content);
            newRoom.SetRoomInfo(room);
            _listings.Add(newRoom);
        }
    }
}
