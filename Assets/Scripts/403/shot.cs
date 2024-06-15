using System.Collections;
using System.Collections.Generic;
using Unity.Mathematics;
using Unity.VisualScripting.FullSerializer;
using UnityEngine;

public class shot : MonoBehaviour
{
    float angle;
    Vector2 target, mouse;
    public GameObject bulletPrefab;
    public float shotSpeed = 10.0f;
    public Transform sPoint;
    private void Start()
    {
        target = transform.position;
        
    }
    private void Update()
    {
        //카메라 스크린의 마우스 거리와 총과의 방향 
        Vector2 direction = Camera.main.ScreenToWorldPoint(Input.mousePosition) - transform.position;
        //마우스 거리로 부터 각도 계산
        float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
        //축으로부터 방향과 각도의 회전값
        Quaternion rotation = Quaternion.AngleAxis(angle , Vector3.forward);
        transform.rotation = rotation;
        if(Input.GetKeyDown(KeyCode.Mouse0)) {
            GameObject bullet = Instantiate(bulletPrefab, sPoint.position, Quaternion.AngleAxis(angle - 90,Vector3.forward));
        }
    }
}
