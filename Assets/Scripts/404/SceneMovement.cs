using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneMovement : MonoBehaviour
{
    public string moveSceneName;
    public Vector2 movePosition;

    private void OnTriggerEnter2D(Collider2D other) {
        if (other.gameObject.CompareTag("Player"))
        {
            GameManager.instance.player.transform.position = movePosition;
            SceneManager.LoadScene(moveSceneName);
        }
    }
}
