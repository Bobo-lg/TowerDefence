using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimationID
{
    public static readonly int MovementID = Animator.StringToHash("Movement");
    public static readonly int LockID = Animator.StringToHash("Lock");
    public static readonly int HorizontalID = Animator.StringToHash("Horizontal");
    public static readonly int VerticalID = Animator.StringToHash("Vertical");
    public static readonly int HasInputID = Animator.StringToHash("HasInput");
    public static readonly int RunID = Animator.StringToHash("Run");
    public static readonly int DeltaAngleID = Animator.StringToHash("DeltaAngle");
    public static readonly int DieID = Animator.StringToHash("Die");
    public static readonly int ParryID = Animator.StringToHash("Parry");
}
