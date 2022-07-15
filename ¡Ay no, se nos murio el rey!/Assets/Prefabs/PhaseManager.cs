using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
using Photon.Realtime;
using System.Linq;
using Hashtable = ExitGames.Client.Photon.Hashtable;
using UnityEngine.SceneManagement;

public class PhaseManager : MonoBehaviourPunCallbacks
{
    private int _continueCount;
    private int _playersCount;
    private bool _ready;
    public GameObject IamReadyButton;

    public void OnClick_Continue()
    {
        var hash = PhotonNetwork.LocalPlayer.CustomProperties;
        hash["Ready"] = true;
        PhotonNetwork.LocalPlayer.SetCustomProperties(hash);
        IamReadyButton.gameObject.SetActive(false);

        if (!PhotonNetwork.IsMasterClient) return;

        CheckAllPlayersReady();
    }

    public override void OnPlayerPropertiesUpdate(Player targetPlayer, Hashtable changedProps)
    {
        if (!PhotonNetwork.IsMasterClient) return;

        if (!changedProps.ContainsKey("Ready")) return;

        CheckAllPlayersReady();
    }

    public override void OnMasterClientSwitched(Player newMasterClient)
    {
        if (newMasterClient != PhotonNetwork.LocalPlayer) return;

        CheckAllPlayersReady();
    }


    private void CheckAllPlayersReady()
    {
        var players = PhotonNetwork.PlayerList;
        if (players.All(p => p.CustomProperties.ContainsKey("Ready") && (bool)p.CustomProperties["Ready"]))
        {
            SceneManager.LoadScene("EconomyTest");
        }
    }

    private void NextPhase()
    {

    }
}
