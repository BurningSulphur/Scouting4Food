using Photon.Pun;
using System.Collections;
using UnityEngine;

public class Action_ReduceUsesAndSpawn : ItemAction
{
    public bool SpawnOnFullyUsed;
    
    public Item itemToSpawn;

    public override void RunAction()
    {
        item.photonView.RPC("ReduceUsesRPC", RpcTarget.All);
    }

    [PunRPC]
    public void ReduceUsesRPC()
    {
        OptionableIntItemData data = item.GetData<OptionableIntItemData>(DataEntryKey.ItemUses);
        if (data.HasData && data.Value > 0)
        {
            data.Value--;
            if (item.totalUses > 0)
            {
                item.SetUseRemainingPercentage((float)data.Value / (float)item.totalUses);
            }
            if (data.Value == 0 && SpawnOnFullyUsed && (bool)base.character && base.character.IsLocal && base.character.data.currentItem == item)
            {
                item.StartCoroutine(item.ConsumeDelayed());
                base.character.StartCoroutine(SpawnItemDelayed());
            }
        }
    }
    
    public IEnumerator SpawnItemDelayed()
    {
        Character c = base.character;
        Item item = itemToSpawn;
        float timeout = 2f;
        while (this != null)
        {
            timeout -= Time.deltaTime;
            if (timeout <= 0f)
            {
                yield break;
            }
            yield return null;
        }
        GameUtils.instance.InstantiateAndGrab(item, c);
    }
}