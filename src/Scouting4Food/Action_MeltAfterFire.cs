using Photon.Pun;
using UnityEngine;
using Zorro.Core;

public class ItemCookingSimple : ItemComponent
{
    [SerializeField] private bool disableCooking;
    public bool canBeCooked => !disableCooking;


    public override void OnInstanceDataSet()
    {

    }

    [PunRPC]
    private void FinishCookingRPC()
    {
        if (photonView.AmController)
        {
            PhotonNetwork.Destroy(gameObject);
        }
    }

    public void FinishCooking()
    {
        if (!photonView.AmController) return;
        photonView.RPC("FinishCookingRPC", RpcTarget.All);
        if ((bool)item.holderCharacter && (bool)item.holderCharacter.GetComponent<CharacterItems>() && (bool)item.holderCharacter.GetComponent<CharacterItems>().cookSfx)
        {
            item.holderCharacter.GetComponent<CharacterItems>().cookSfx.Play(transform.position);
        }
        Debug.Log("Item Cooked and Destroyed");
    }
}