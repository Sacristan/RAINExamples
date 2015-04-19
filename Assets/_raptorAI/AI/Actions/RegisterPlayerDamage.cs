using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using RAIN.Action;
using RAIN.Core;

[RAINAction]
public class RegisterPlayerDamage : RAINAction
{

    GameObject playerObject;

    float nodeEntryTime;
    float lastAttackTime;

    private int meleeDamage = 10;
    private float attackRegisterTreshold = 1.2f;
    private string memoryKey = "lastAttackTime";
    
    public override void Start(RAIN.Core.AI ai)
    {
        nodeEntryTime = Time.timeSinceLevelLoad;
        lastAttackTime = ai.WorkingMemory.GetItem<float>(memoryKey);
        playerObject = ai.WorkingMemory.GetItem<GameObject>("player");
    }

    public override ActionResult Execute(RAIN.Core.AI ai)
    {
        if (nodeEntryTime - lastAttackTime > attackRegisterTreshold)
        {
            lastAttackTime = nodeEntryTime;
            ai.WorkingMemory.SetItem<float>(memoryKey, nodeEntryTime);
            playerObject.SendMessage("ReceiveDamage", meleeDamage);
            return ActionResult.SUCCESS;
        }
        else
        {
            return ActionResult.FAILURE;
        }


    }

}