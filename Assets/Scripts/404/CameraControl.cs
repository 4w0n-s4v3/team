using System.Collections;
using System.Collections.Generic;
using Cinemachine;
using UnityEngine;

public class CameraControl : MonoBehaviour
{
    CinemachineVirtualCamera virtualCamera;

    private void Awake() {
        virtualCamera = gameObject.GetComponent<CinemachineVirtualCamera>();
    }

    // Start is called before the first frame update
    void OnEnable()
    {
        virtualCamera.Follow = FindObjectOfType<Player>().pivot;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
