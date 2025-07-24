using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AutoGenerator : MonoBehaviour
{
    // ������Ʈ�� �ڵ� �����ǰ� ���ִ� ��ũ��Ʈ.
    // �켱 �ڵ� ������ ������Ʈ�� Transform�� �ʿ��ϰڴ�. 

    // �ڵ� ������ ��� �ϴ°� ������?
    // ������ ���� �ְ� �� ���� ������Ʈ�� ����� �� Ư�� ��ġ�� ������Ʈ�� �ű�� �� ���? 
    // ������ ���� ���� �����? �� �𸣰ڴ�. �����ڷ� ����. 
    // ī�޶� ���� ������Ʈ�� ����� �� ������Ʈ�� Ʈ���� �ݶ��̴��� �޾Ƽ� ó����. 
    // Ʈ���� �ݸ��� �޼��带 ����� ���ȭ���� �ڷ� �̵����Ѻ���. 

    public Transform ground;

    public float collidingObjWidth = 8f;

    private ObstacleManager obstacleManager;

    // Start is called before the first frame update
    void Start()
    {
        obstacleManager = ObstacleManager.Instance;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        /*
         
        float collidingObjWidth = ((BoxCollider2D)collision).size.x;
        ���⼭ ������ ��. 
        -> collision�� BoxCollider2D�� �ƴ� ���� �־ ������ �� ��
        ������ ũ�⸦ ���ҰŸ� �� ũ�Ⱑ ������ �˰� ������ �׳� ���ڷ� ũ�⸦ ���ص���.
        float colldingObjWidth = 8f;�� 

         */

        if (collision.gameObject.CompareTag("background"))
        {
            //Debug.Log($"{collision.name}�� �浹��!");
            // �̵���Ű��. 
            // ������ġ + x������ ������Ʈ ���� ���� * 5��ŭ �̵� 
            Vector3 collidingObjPos = collision.transform.position;

            collidingObjPos.x = collidingObjPos.x + (collidingObjWidth * 5f);
            //collidingObjPos.x += (collidingObjWidth * 5f); // collidingObjPos.x = collidingObjPos.x + (collidingObjWidth * 5f)

            //Debug.Log($"{collision.name} �ٲ�� �� ��ġ : {collision.transform.position}");
            collision.transform.position = collidingObjPos;
            //Debug.Log($"{collision.name} �ٲ� �� ��ġ : {collision.transform.position}");
            return;
        }

        if (collision.gameObject.CompareTag("obstacle"))
        {
            Debug.Log($"BgLooper�� ��ֹ� �ε���.");
            // ��ֹ��� ���� ��ġ
            //Obstacle obstacle = collision.gameObject.GetComponent<Obstacle>();
            //obstacle.SetRandomPosition();

            // ��ֹ��� �ε����� ��ֹ��� ���� ��ġ�� *5�� �̵��ϰ�, ��ֹ� ���� ���� ����
            GameObject parentObj = collision.transform.parent.gameObject;
            obstacleManager.SetObstaclePosition(parentObj, collidingObjWidth);

            // ��ֹ� ���� �� ����
            obstacleManager.SetChildObjDistance(parentObj);

            return;
        }
    }
}
