using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEngine.GraphicsBuffer;

public class CameraFollower : MonoBehaviour
{
    // 카메라가 플레이어를 따라 다녀야 한다. 
    // 어떻게 카메라가 플레이어를 따라다니게 할까? 
    // 우선 이 스크립트가 플레이어를 알아야 따라다니게 구현을 할 수 있으니까 
    // 플레이어의 위치를 가져오자. 

    // 카메라가 플레이어 위치를 따라가게 하려면 어떻게 해야할까? 
    // 카메라 위치와 플레이어 위치를 똑같이 설정하면 될것 같은데.. 
    // 되긴 한다. 근데 카메라가 맵 바깥을 찍게 된다. 
    // 카메라가 따라다니는 범위를 제한하고 싶다. 
    // 그럴려면 처음부터 카메라와 플레이어 사이 거리를 저장해두고 
    // 이 거리를 유지하면서 카메라를 이동시켜보는 건 어떨까? 
    // 근데 거리를 유지하는 걸 어떻게 코드로 표현하지? 강의 코드 보자. 
    // 카메라의 위치를 플레이어 위치 + distance 만큼으로 하는거지. 

    public Transform playerTransform;

    private float distance;

    private void Awake()
    {
        distance = transform.position.x - playerTransform.position.x;
        Debug.Log($"distance = {distance}");
    }

    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        //Vector3 pos = transform.position;
        //pos = playerTransform.position;
        //pos.z = -10;
        //transform.position = pos;

        // 카메라의 위치를 플레이어 위치 + distance 만큼으로 하는거지. 
        //transform.position = playerTransform.position + new Vector3(distance, 0, -10); // 이렇게 하면 y축도 변함.

        // 카메라의 y축은 움직이지 않으면서 플레이어를 따라가야함. 
        Vector3 cameraPos = transform.position;
        cameraPos.x = playerTransform.position.x + distance;
        transform.position = cameraPos;
    }
}
