using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Assertions;

public class AttackDelayModule : MonoBehaviour
{
    private Player mPlayer;
    private PlayerMovement mPlayerMovment;
    private PlayerAnimationController mAnimationController;

    private Enemy mPrevTarget;
    private Enemy mTarget;
    private float mShootDelayCounter = 0.0f;
    private bool mIsShooting = false;

    void Start()
    {
        mPlayer = GetComponent<Player>();
        Assert.IsNotNull(mPlayer, "[AttackDelayModule]--- mPlayer is null");

        mPlayerMovment = GetComponentInChildren<PlayerMovement>();
        Assert.IsNotNull(mPlayerMovment, "[AttackDelayModule]--- mPlayer is null");

        mAnimationController = GetComponentInChildren<PlayerAnimationController>();
        Assert.IsNotNull(mAnimationController, "[AttackDelayModule]--- mAnimationController is null");
    }


    void FixedUpdate()
    {
        if (!mTarget)
        {
            mAnimationController.SetIdleAnimation();
            return;
        }

        if (!mPlayerMovment.IsMoving)
            mPlayerMovment.RotateTowards(mTarget.transform);
        else
            mShootDelayCounter = 0.0f;

        if ((mShootDelayCounter > mAnimationController.GetShootDelay()) && (mPlayerMovment.Agent.velocity.sqrMagnitude == 0.0f))
        {
            mPlayer.AutoAttack(mTarget);
            mShootDelayCounter = 0.0f;
            mIsShooting = false;
        }
        if (mIsShooting)
            mShootDelayCounter += Time.deltaTime;
        else
            mAnimationController.SetIdleAnimation();
    }

    public void AttackWithDelay(Enemy target)
    {
        mAnimationController.SetAttackAnimation();
        if (mTarget && mTarget != target)
        {
            var ui = mTarget.GetComponent<TargetUI>();
            if (ui)
            {
                ui.SetDisplayOnPlayerTarget(false);
            }
            mPrevTarget = mTarget;
            mTarget = target;
        }
        else if (!mTarget)
        {
            var ui = target.GetComponent<TargetUI>();
            if (ui)
            {
                ui.SetDisplayOnPlayerTarget(true);
            }
            mTarget = target;
        }
       
        //mTarget = target;
        mIsShooting = true;
    }

}
