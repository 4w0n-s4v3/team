using System.Collections;
using System.Collections.Generic;
using Cinemachine;
using UnityEngine;

public class ClickPoint : MonoBehaviour
{
    public CinemachineVirtualCamera cinemachine;
    public GameObject keyImage;
    public Transform movePos;
    public GameObject ui;

    public bool isUI;
    public bool isEnter;

    public bool isClick;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (isClick && Input.GetKeyDown(KeyCode.Z))
        {
            if (isUI)
            {
                ui.SetActive(true);
                Time.timeScale = 0;
            }
            else
            {
                isClick = false;
                GameManager.instance.player.transform.position = movePos.position;

                if (isEnter)
                {
                    cinemachine.gameObject.GetComponent<CinemachineConfiner2D>().enabled = false;
                    cinemachine.Follow = null;
                    cinemachine.transform.position = new Vector3(-35.0f, 7.0f, cinemachine.transform.position.z);
                }
                else
                {
                    cinemachine.Follow = GameManager.instance.player.transform;
                    cinemachine.gameObject.GetComponent<CinemachineConfiner2D>().enabled = true;
                }
            }
        }
    }

    private void OnTriggerStay2D(Collider2D other) {
        if (other.gameObject.CompareTag("Player"))
        {
            isClick = true;
            keyImage.SetActive(true);
        }
    }

    private void OnTriggerExit2D(Collider2D other) {
        if (other.gameObject.CompareTag("Player"))
        {
            isClick = false;
            keyImage.SetActive(false);
        }
    }
}
