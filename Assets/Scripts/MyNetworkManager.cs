using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Mirror;

public class MyNetworkManager : NetworkManager
{

    public override void OnClientConnect(NetworkConnection conn)
    {
        base.OnClientConnect(conn);

        print("Client Connected");
    }

    public override void OnServerAddPlayer(NetworkConnection conn)
    {
        base.OnServerAddPlayer(conn);

        MyNetworkPlayer player = conn.identity.GetComponent<MyNetworkPlayer>();

        player.setPlayerName($"Player {numPlayers}");

        Color randomPlayerColour = new Color(Random.Range(0f, 1f), Random.Range(0f, 1f), Random.Range(0f, 1f));
        player.setPlayerColour(randomPlayerColour);

        print($"Player Added, there are now {numPlayers} players on the server!");
    }
}
