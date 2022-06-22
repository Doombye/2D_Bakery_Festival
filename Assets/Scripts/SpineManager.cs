using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Spine.Unity;

public class SpineManager : MonoBehaviour
{
    // 스파인 애니메이션을 위한 것
    //public SkeletonAnimation skeletonAnimation;
    public AnimationReferenceAsset[] animClip;
    public SkeletonGraphic sg;

    public string walk;
    public string dance;

    private void Start()
    {
        sg = GetComponent<SkeletonGraphic>();
    }

    // 애니메이션에 대한 Enum
    public enum AnimState
    {
        walk, dance
    }

    public void SetNormal()
    {
        sg.AnimationState.SetAnimation(0, walk, true);
    }

    // 현재 애니메이션 처리가 무엇인지에 대한 변수
    private AnimState animState;

    // 현재 재생되고 있는 애니메이션
    private string CurrentAnimation;

    Rigidbody2D rigd;
    private float xx;

    private void Awake()
    {
        rigd = GetComponent<Rigidbody2D>();
    }

    private void Update()
    {
        xx = Input.GetAxisRaw("Horizontal");
        if (xx == 1)
        {
            animState = AnimState.walk;
        }
        else if(Input.GetKey(KeyCode.Alpha1))
        {
            animState = AnimState.dance;
            //transform.localScale = new Vector2(xx, 1);
        }
        else if(Input.GetKey(KeyCode.Alpha2))
        {
            animState = AnimState.walk;

        }
        // 애니메이션 적용
        SetCurrentAnimation(animState);
    }

    private void AnimChange(AnimationReferenceAsset animClip, bool loop, float speed)
    {
        // 동일한 애니메이션을 재생할려고 한다면 리턴
        if (animClip.name.Equals(CurrentAnimation))
            return;

        // 해당 애니메이션으로 변경한다.
        //skeletonAnimation.state.SetAnimation(0, animClip, loop).TimeScale = speed;
        //skeletonAnimation.loop = loop;
        //skeletonAnimation.timeScale = speed;

        // 현재 재생되고 있는 애니메이션 값을 변경
        CurrentAnimation = animClip.name;
    }

    private void SetCurrentAnimation(AnimState state)
    {
        switch(state)
        {
            case AnimState.walk:
                AnimChange(animClip[(int)AnimState.walk], true, 1f);
                break;

            case AnimState.dance:
                AnimChange(animClip[(int)AnimState.dance], true, 1f);
                break;
        }
    }

}
