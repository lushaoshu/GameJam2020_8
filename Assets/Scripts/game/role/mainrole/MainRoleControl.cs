using UnityEngine;
using System.Collections;

public class MainRoleControl : SmartControl<MainRoleModel>
{
    private float moveH, moveV;
    private float moveSpeed=1;
    //public override void OnAppInit()
    //{
    //    base.OnAppInit();
    //    model.player = GameObject.FindWithTag("Player");
    //    model.rb = model.player.GetComponent<Rigidbody2D>();
    //    model.anim = model.player.FindChild<Animator>("body");

    //}


    //public override void OnFrameUpdate()
    //{
    //    base.OnFrameUpdate();
    //    moveH = Input.GetAxisRaw("Horizontal") * moveSpeed;
    //    moveV = Input.GetAxisRaw("Vertical") * moveSpeed;

    //    if (moveH > 0)
    //        model.player.transform.eulerAngles = new Vector3(0, 0, 0);
    //    if (moveH < 0)
    //        model.player.transform.eulerAngles = new Vector3(0, 180, 0);

    //    PlayAnimation(moveH!=0|| moveV!=0? AnimationParams.Run : AnimationParams.Idle);
    //    moveH = moveV != 0 ? 0 : moveH;
    //    moveV = moveH != 0 ? 0 : moveV;
    //    model.rb.velocity = new Vector2(moveH, moveV);
    //}

    //string preAnimName = "idle";
    //public void PlayAnimation(string animName)
    //{
    //    model.anim.SetBool(preAnimName, false);
    //    model.anim.SetBool(animName, true);
    //    preAnimName = animName;//
    //}
}
