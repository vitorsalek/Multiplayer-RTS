using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Mirror;

public class MyNetworkPlayer : NetworkBehaviour
{
    [SyncVar]
    [SerializeField]
    private string playerName = "Missing Name";

    [SyncVar]
    [SerializeField]
    private Color playerColor=Color.white;

    [Server]
    public void setPlayerName(string name)
    {
        playerName = name;
    }
    [Server]
    public void setPlayerColour(Color colour)
    {
        playerColor = colour;
    }
}
