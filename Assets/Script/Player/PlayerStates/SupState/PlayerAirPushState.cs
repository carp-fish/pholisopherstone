using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAirPushState : PlayerAbilityState
{
    public bool CanAirPush { get; private set; }
    private bool airPushUsed;
    private float lastAirPushTime;
    public PlayerAirPushState(Player player, PlayerStateMachine stateMachine, PlayerData playerData, string animBoolName) : base(player, stateMachine, playerData, animBoolName)
    {
    }

    public override void Enter()
    {
        base.Enter();

        CanAirPush = false;
        airPushUsed = false;
        player.inputHandler.UseAirPushInput();

        player.RB.drag = playerData.airPushDrag;
    }
    public override void Exit()
    {
        base.Exit();
    }

    public override void LogicUpdate()
    {
        base.LogicUpdate();

        if(!isExitingState)
        {
            if(Time.time >= startTime + playerData.airPushTime && !airPushUsed)
            {
                //air push funct
                player.PushWind.CreatePushWind();
                airPushUsed = true;
            }

            if(Time.time >= startTime + playerData.airPushDuration)
            {
                player.RB.drag = 0;
                isAbilityDone = true;
                lastAirPushTime = Time.time;
            }
        }
    }
    public bool CheckIfCanAirPush()
    {
        return CanAirPush && Time.time >= lastAirPushTime + playerData.airPushCooldown;
    }
    public void ResetCanAirPush() => CanAirPush = true;

}
