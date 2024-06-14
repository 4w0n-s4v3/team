using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IngredientInteraction : MonoBehaviour 
{
    private void OnCollisionEnter2D(Collision2D other) {
        if(other.collider.CompareTag("InteractionActive"))
        {
        }
    }
}