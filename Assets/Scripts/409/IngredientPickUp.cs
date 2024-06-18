using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class IngredientPickUp : MonoBehaviour
{
    public PotionIngredient potionIngredient;
    public SpriteRenderer spriteRenderer;

#if UNITY_EDITOR
    public void OnValidate() {
        spriteRenderer = gameObject.GetComponent<SpriteRenderer>();
        spriteRenderer.sprite = potionIngredient.ingredientImage;
    }
#endif

    void Start()
    {
        
    }
}
