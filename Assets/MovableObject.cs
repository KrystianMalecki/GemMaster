using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using NaughtyAttributes;
public class MovableObject : LogicObject
{
    [Foldout("Static Data")] public Rigidbody2D r2d;
    public override void Move(Vector2 vector)
    {
        base.Move(vector);
        r2d.AddRelativeForce(vector, ForceMode2D.Force);
    }
}
