using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using RAIN.Action;
using RAIN.Core;

[RAINAction]
public class RegisterPlayerDamage : RAINAction
{
    int meleeDamage = 10;
    GameObject playerObject;

    public override void Start(RAIN.Core.AI ai)
    {
        playerObject = ai.WorkingMemory.GetItem<GameObject>("player");
    }

    public override ActionResult Execute(RAIN.Core.AI ai)
    {
        playerObject.SendMessage("ReceiveDamage", meleeDamage);
        return ActionResult.SUCCESS;
    }

    public override void Stop(RAIN.Core.AI ai)
    {
        base.Stop(ai);
    }
}