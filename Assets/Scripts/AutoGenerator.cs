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

    // Start is called before the first frame update
    void Start()
    {
        
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
            // �̵���Ű��. 
            // ������ġ + x������ ������Ʈ ���� ���� * 5��ŭ �̵� 
            Vector3 collidingObjPos = collision.transform.position;
            //float collidingObjWidth = ((BoxCollider2D)collision).size.x;
            float collidingObjWidth = 8f;

            collidingObjPos.x += (collidingObjWidth * 5f); // collidingObjPos.x = collidingObjPos.x + (collidingObjWidth * 5f)

            collision.transform.position = collidingObjPos;
            return;
        }

        //if (collision.gameObject.CompareTag("Obstacle"))
        //{
        //    // ��ֹ��� ���� ��ġ
        //    Obstacle obstacle = collision.gameObject.GetComponent<Obstacle>();
        //    obstacle.SetRandomPosition();
        //}
    }
}
