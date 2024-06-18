using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class GridManager : MonoBehaviour
{
    Grid grid;
    [SerializeField] Tilemap interectiveMap = null;
    [SerializeField] Tilemap pathMap = null;
    [SerializeField] Tile hoverTile = null;
    [SerializeField] RuleTile pathTile = null;
    [SerializeField] Rigidbody2D playerRigid;

    private Vector3Int previousMousePos = new Vector3Int();

    private void Start() {
        grid = gameObject.GetComponent<Grid>();
    }

    private void Update() {
        
    }

    Vector3Int GetMousePosition () {
        Vector3 mouseWorldPos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        return grid.WorldToCell(mouseWorldPos);
    }

    private void OnTriggerEnter2D(Collider2D collision) {
        if (collision.gameObject.CompareTag("Player"))
        {
            playerRigid.sleepMode = RigidbodySleepMode2D.NeverSleep;
        }
    }

    private void OnTriggerStay2D(Collider2D collision) {
        if (collision.gameObject.CompareTag("Player"))
        {
            Vector3Int mousePos = GetMousePosition();
            if (!mousePos.Equals(previousMousePos)) {
                interectiveMap.SetTile(previousMousePos, null); // Remove old hoverTile
                interectiveMap.SetTile(mousePos, hoverTile);
                previousMousePos = mousePos;
            }

            // Left mouse click -> add path tile
            if (Input.GetMouseButton(0)) {
                pathMap.SetTile(mousePos, pathTile);
            }

            // Right mouse click -> remove path tile
            if (Input.GetMouseButton(1)) {
                pathMap.SetTile(mousePos, null);
            }
        }
    }

    private void OnTriggerExit2D(Collider2D collision) {
        if (collision.gameObject.CompareTag("Player"))
        {
            playerRigid.sleepMode = RigidbodySleepMode2D.StartAwake;
            interectiveMap.SetTile(previousMousePos, null);
        }
    }
}
