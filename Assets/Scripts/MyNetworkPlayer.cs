using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using Mirror;

public class MyNetworkPlayer : NetworkBehaviour
{
    [SerializeField] private TMP_Text nameText = null;
    [SerializeField] private Renderer thisRender = null;

    [SyncVar(hook = nameof(changeName))]
    [SerializeField]
    private string playerName = "Missing Name";

    [SyncVar(hook = nameof(changeColor))]
    [SerializeField]
    private Color playerColor = Color.black;


    #region Server

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
    [Command]
    private void CmdSetPlayerName(string name)
    {
        if (name.Length <= 3)
        {
            Debug.LogError("Name needs to have more than 3 characters");
        }
        else if (name.Length >= 16)
        {
            Debug.LogError("Name needs to have less than 16 characters");
        }
        else
        {
            RpcDebugNewName(name);
            setPlayerName(name);
        }
        
    }

    #endregion

    #region Client

    private void changeColor(Color oldColor, Color newColor)
    {
        thisRender.material.SetColor("_BaseColor", newColor);
    }
    private void changeName(string oldName, string newName)
    {
        nameText.text = newName;
    }

    [ContextMenu("Set Name")]
    private void setMyName()
    {
        CmdSetPlayerName("My new name");
    }
    [ClientRpc]
    private void RpcDebugNewName(string name)
    {
        Debug.Log($"Player name changed to {name}");
    }
    #endregion


}
