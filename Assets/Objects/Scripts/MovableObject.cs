using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using NaughtyAttributes;
using DG.Tweening;
using CodeHelper;
public class MovableObject : LogicObject
{
    [Foldout("Static Data")] public Rigidbody2D r2d;
    public override void Move(GemLogicBlock glb, Vector2 dir)
    {

        transform.DOLocalMove(transform.localPosition + dir.ToVector3(), 1).OnComplete(glb.HalfMTTNS);

    }
}
