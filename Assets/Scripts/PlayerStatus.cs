using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;

public class PlayerStatus : MonoBehaviour
{
    private string emoji = "disappointed-face";
    // "disappointed-face"

    // Start is called before the first frame update
    void Start()
    {
        PhotonView photonView = PhotonView.Get(this);
        // string playerStatusEmoji = gameObject.GetComponent<PlayerStatus>().GetEmoji();
        //PlayerPrefs.SetString("emoji", "disappointed-face");
        //string playerStatusEmoji = PlayerPrefs.GetString("emoji");
        string playerStatusEmoji = emoji;
        photonView.RPC("RecreateAvatar", RpcTarget.Others, playerStatusEmoji);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public string GetEmoji()
    {
        return emoji;
    }
}
