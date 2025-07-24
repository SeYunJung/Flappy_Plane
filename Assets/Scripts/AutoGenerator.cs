using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AutoGenerator : MonoBehaviour
{
    // 오브젝트를 자동 생성되게 해주는 스크립트.
    // 우선 자동 생성할 오브젝트의 Transform이 필요하겠다. 

    // 자동 생성을 어떻게 하는게 좋을까?
    // 가상의 선이 있고 그 선에 오브젝트가 닿았을 때 특정 위치에 오브젝트를 옮기는 건 어떨까? 
    // 가상의 선은 뭘로 만들까? 잘 모르겠다. 강의자료 보자. 
    // 카메라 하위 오브젝트를 만들고 이 오브젝트에 트리거 콜라이더를 달아서 처리함. 
    // 트리거 콜리션 메서드를 만들고 배경화면을 뒤로 이동시켜보자. 

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
        여기서 에러가 남. 
        -> collision이 BoxCollider2D가 아닐 수도 있어서 에러가 난 것
        어차피 크기를 구할거면 그 크기가 몇인지 알고 있으면 그냥 숫자로 크기를 정해도됨.
        float colldingObjWidth = 8f;로 

         */

        if (collision.gameObject.CompareTag("background"))
        {
            //Debug.Log($"{collision.name}과 충돌함!");
            // 이동시키기. 
            // 현재위치 + x축으로 오브젝트 가로 길이 * 5만큼 이동 
            Vector3 collidingObjPos = collision.transform.position;

            collidingObjPos.x = collidingObjPos.x + (collidingObjWidth * 5f);
            //collidingObjPos.x += (collidingObjWidth * 5f); // collidingObjPos.x = collidingObjPos.x + (collidingObjWidth * 5f)

            //Debug.Log($"{collision.name} 바뀌기 전 위치 : {collision.transform.position}");
            collision.transform.position = collidingObjPos;
            //Debug.Log($"{collision.name} 바뀐 후 위치 : {collision.transform.position}");
            return;
        }

        if (collision.gameObject.CompareTag("obstacle"))
        {
            Debug.Log($"BgLooper가 장애물 부딪힘.");
            // 장애물을 랜덤 배치
            //Obstacle obstacle = collision.gameObject.GetComponent<Obstacle>();
            //obstacle.SetRandomPosition();

            // 장애물과 부딪히면 장애물을 현재 위치의 *5로 이동하고, 장애물 사이 폭도 변경
            GameObject parentObj = collision.transform.parent.gameObject;
            obstacleManager.SetObstaclePosition(parentObj, collidingObjWidth);

            // 장애물 사이 폭 변경
            obstacleManager.SetChildObjDistance(parentObj);

            return;
        }
    }
}
