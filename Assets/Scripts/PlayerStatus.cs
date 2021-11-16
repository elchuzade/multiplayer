using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
using Photon.Pun;

public class PlayerStatus : MonoBehaviour
{
    public List<GameObject> emojies = new List<GameObject>();
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
        photonView.RPC("RecreateAvatar", RpcTarget.All, playerStatusEmoji, photonView.ViewID);
    }

    [PunRPC]
    void RecreateAvatar(string emoji, int viewId)
    {
        Debug.Log(viewId);
        foreach (var item in FindObjectsOfType<PhotonView>())
        {
            if (item.ViewID == viewId)
            {
                Debug.Log("found user: " + viewId);
                GameObject spawnedPlayerPrefab = item.gameObject;
                // Destroy old emoji and Respawn emoji based on the player status
                GameObject playerEmoji = Instantiate(emojies.Find(e => e.name == emoji), spawnedPlayerPrefab.transform.Find("Head").Find("Emoji"));
                playerEmoji.transform.SetParent(spawnedPlayerPrefab.transform.Find("Head").Find("Emoji"));
                break;
            }
        }
    }

    public string GetEmoji()
    {
        return emoji;
    }
}
