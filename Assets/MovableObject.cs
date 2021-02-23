using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using NaughtyAttributes;
using DG.Tweening;
using CodeHelper;
public class MovableObject : LogicObject
{
    [Foldout("Static Data")] public Rigidbody2D r2d;
    public override void Move(Vector2 vector,GemLogicBlock glb)
    {
      
        transform.DOLocalMove(transform.position + vector.ToVector3(), 1).OnComplete(glb.HalfMTTNS);
      
    }
}
