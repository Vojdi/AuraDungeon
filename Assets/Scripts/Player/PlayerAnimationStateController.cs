using UnityEngine;

public class PlayerAnimationStateController : AnimationStateController
{
    void Update()
    {
        RefreshValues();
        if (PlayerMovement.IsWalking)
        {
            MovementIsWalking();
        }
        else
        {
            MovementNotWalking();
        }
    }
    protected override void RefreshValues()
    {
        movementSpeed = PlayerStats.Instance.MovementSpeed;
        reloadRate = PlayerStats.Instance.ReloadTime;
    }
}
