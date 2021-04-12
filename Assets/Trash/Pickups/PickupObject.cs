using UnityEngine;
using NaughtyAttributes;
using System;
using DG.Tweening;
using System.Collections;

public class PickupObject : MonoBehaviour
{
    public AudioSource audioSource;
    public Collider2D col;
    public SpriteRenderer sr;
    public virtual void Pickup(Entity entity)
    {
        DG.Tweening.DOTween.Kill(this, false);
        lvl.Pickuped(id);
        audioSource.Play();
        col.enabled = false;
        sr.enabled = false;
        StartCoroutine(disable());
    }
    IEnumerator disable()
    {
        yield return new WaitForSeconds(0.5f);
        gameObject.SetActive(false);

    }
    [ReadOnly] public int id;
    [ReadOnly] public Level lvl;
    public virtual void Setup(Level l, int id)
    {
        gameObject.SetActive(true);
        col.enabled = true;
        sr.enabled = transform;

        lvl = l;
        this.id = id;
    }
    protected void up()
    {

        transform.DOLocalMoveY(transform.localPosition.y + 0.2f, 2f).OnComplete(down);
    }
    protected void down()
    {
        transform.DOLocalMoveY(transform.localPosition.y - 0.2f, 2f).OnComplete(up);
    }
}
