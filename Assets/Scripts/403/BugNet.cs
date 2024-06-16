using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class BugNet : MonoBehaviour
{

    
    public Transform playerPos;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Vector2 direction = Camera.main.ScreenToWorldPoint(Input.mousePosition) - transform.position;
        //마우스 거리로 부터 각도 계산
        float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
        //축으로부터 방향과 각도의 회전값
        Quaternion rotation = Quaternion.AngleAxis(angle , Vector3.forward);
        transform.rotation = rotation;
        if(Input.GetKeyDown(KeyCode.Mouse0)) {
        }
        transform.position = new Vector3(playerPos.position.x + 0.1f, playerPos.position.y + 0.3f, playerPos.position.z);
    }
}
