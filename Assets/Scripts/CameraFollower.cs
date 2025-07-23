using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEngine.GraphicsBuffer;

public class CameraFollower : MonoBehaviour
{
    // ī�޶� �÷��̾ ���� �ٳ�� �Ѵ�. 
    // ��� ī�޶� �÷��̾ ����ٴϰ� �ұ�? 
    // �켱 �� ��ũ��Ʈ�� �÷��̾ �˾ƾ� ����ٴϰ� ������ �� �� �����ϱ� 
    // �÷��̾��� ��ġ�� ��������. 

    // ī�޶� �÷��̾� ��ġ�� ���󰡰� �Ϸ��� ��� �ؾ��ұ�? 
    // ī�޶� ��ġ�� �÷��̾� ��ġ�� �Ȱ��� �����ϸ� �ɰ� ������.. 
    // �Ǳ� �Ѵ�. �ٵ� ī�޶� �� �ٱ��� ��� �ȴ�. 
    // ī�޶� ����ٴϴ� ������ �����ϰ� �ʹ�. 
    // �׷����� ó������ ī�޶�� �÷��̾� ���� �Ÿ��� �����صΰ� 
    // �� �Ÿ��� �����ϸ鼭 ī�޶� �̵����Ѻ��� �� ���? 
    // �ٵ� �Ÿ��� �����ϴ� �� ��� �ڵ�� ǥ������? ���� �ڵ� ����. 
    // ī�޶��� ��ġ�� �÷��̾� ��ġ + distance ��ŭ���� �ϴ°���. 

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

        // ī�޶��� ��ġ�� �÷��̾� ��ġ + distance ��ŭ���� �ϴ°���. 
        //transform.position = playerTransform.position + new Vector3(distance, 0, -10); // �̷��� �ϸ� y�൵ ����.

        // ī�޶��� y���� �������� �����鼭 �÷��̾ ���󰡾���. 
        Vector3 cameraPos = transform.position;
        cameraPos.x = playerTransform.position.x + distance;
        transform.position = cameraPos;
    }
}
