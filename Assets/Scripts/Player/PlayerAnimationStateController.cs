using NUnit.Framework;
using UnityEngine;

public class PlayerAnimationStateController : AnimationStateController
{
    [SerializeField] GameObject[] PlayerModels;
    GameObject currentCharacter;
    private void Start()
    {
        GameObject currentCharacter = Instantiate(PlayerModels[PlayerPrefs.GetInt("charId")], transform);
        currentCharacter.transform.localPosition = Vector3.zero;
        currentCharacter.transform.localRotation = Quaternion.identity;
        var b = currentCharacter.GetComponent<AnimatorBundle>();
        handsAnimator = b.GetHandsAnimator();
        legsAnimator = b.GetLegsAnimator();
       
    }
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
