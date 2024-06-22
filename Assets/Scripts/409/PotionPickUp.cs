using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class PotionPickUp : MonoBehaviour
{
    public Potion potion;
    public SpriteRenderer spriteRenderer;

    public int count = 0;

#if UNITY_EDITOR
    public void OnValidate()
    {
        spriteRenderer = gameObject.GetComponent<SpriteRenderer>();
        spriteRenderer.sprite = potion.potionImage;
    }
#endif

    void Start()
    {

    }
}
