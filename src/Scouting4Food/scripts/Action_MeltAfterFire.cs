using Photon.Pun;
using System.Collections;
using UnityEngine;
using Zorro.Core;
/*
public class Action_MeltAfterFire : ItemComponent
{
    [SerializeField]
    public bool spawnWhenCooked;
    public Item itemToSpawn;
    
    public override void OnInstanceDataSet()
    {

    }
    
    
    private void ChangeStatsCooked()
    {
        if (spawnWhenCooked)
        {
            ItemComponent[] components = GetComponents<ItemComponent>();
            for (int num = components.Length - 1; num >= 0; num--)
            {
                if (components[num] != this)
                {
                    Object.Destroy(components[num]);
                }
            }
            ItemAction[] components2 = GetComponents<ItemAction>();
            for (int num2 = components2.Length - 1; num2 >= 0; num2--)
            {
                Object.Destroy(components2[num2]);
            }
            item.overrideUsability = Optionable<bool>.Some(value: false);
            
            Character.localCharacter.StartCoroutine(SpawnItemDelayed());
            return;
        }
    }
    public IEnumerator SpawnItemDelayed()
    {
        Character c = Character.localCharacter;
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
*/