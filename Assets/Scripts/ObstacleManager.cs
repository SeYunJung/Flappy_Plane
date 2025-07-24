using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstacleManager : MonoBehaviour
{
    // 장애물을 자동으로 생성하려면 뭘 해야할까? 
    // 일정 간격으로 배치하면 되지. 
    // 어떻게 배치할까? 
    // 강의에서는 어떻게 배치했지? top과 bottom의 거리를 구하고, 그 거리만큼 top과 bottom이 떨어지게 했어.
    // 그러면 이렇게 하자. 
    // top, bottom 사이 거리를 정해.
    // 거리가 4라면, top의 로컬 좌표를 (0, 2, 0) bottom의 로컬 좌표를 (0, -2, 0)로 하면 top과 bottom 사이 거리가
    // 4가 되겠네. 
    // 그러면 top과 bottom 사이 거리는 구했어. 
    // 이제 Obstacle을 배치해야돼.
    // 어떤 위치에 어떤 규칙으로 Obstacle을 배치할까? 
    // 이걸 모르겠어. 강의 내용을 보자. 
    // 강의 내용에서는 이전 위치 + 일정 공간만큼 해서 Obstacle의 위치를 설정하고 있어. 
    // 이전 위치? 처음 배치되는 Obstacle의 이전 위치는 0이잖아. 처음 배치되는 Obstacle은 (0,0,0) + 일정 공간
    // 그 다음 Obstacle은 이전 위치 + 일정공간 만큼 배치하면돼. 

    // Obstacle은 처음에 몇개로 할까?
    // 이건 내가 정해야지. 
    // 5개로 하자. 5개로 계속 재활용하면 된다. 
    // 

    public int obstacleCount = 5;

    public GameObject obstacle;
    private Transform topTransform;
    private Transform bottomTransform;

    private float distance;

    private Vector3 prePosition;
    public float xPadding = 2f;

    private static ObstacleManager _instance;
    public static ObstacleManager Instance {  get { return _instance; } }

    private void Awake()
    {
        _instance = this;
    }

    // 처음 시작할 때 위 아래(top, bottom) 위치 조정 후, 장애물(Obstacle) 배치
    void Start()
    {
        if(obstacle != null)
        {
            prePosition = transform.position;
            for(int i = 0; i <  obstacleCount; i++)
            {
                Instantiate(obstacle, transform);

                // top, bottom 사이 거리 지정
                // 생성된 장애물(Obstacle)의 top, bottom 사이 거리 지정
                distance = Random.Range(4, 9);

                topTransform = obstacle.transform.GetChild(0);
                bottomTransform = obstacle.transform.GetChild(1);

                topTransform.localPosition = new Vector3(0, distance / 2, 0);
                bottomTransform.localPosition = new Vector3(0, -(distance / 2), 0);

                // 장애물(Obstacle)의 위치 지정 
                // 이전 위치 + 일정 간격 
                // 위치 배치
                //transform.position = prePosition + new Vector3(xPadding, 0, 0);
                if (i == 0)
                    obstacle.transform.position = prePosition;
                else
                    obstacle.transform.position = prePosition + new Vector3(xPadding+2, 0, 0);

                // 이전 위치 저장
                prePosition = obstacle.transform.position;
            }
        }
    }

    public void SetObstaclePosition(GameObject obstacle, float collidingObjWidth)
    {
        Transform collidingObjTransform = obstacle.GetComponent<Transform>(); // Transform을 가져와서 
        Vector3 collidingObjPos = collidingObjTransform.position;
        collidingObjPos.x += (collidingObjWidth * 5f);
        collidingObjTransform.position = collidingObjPos; // 위치 이동
    }

    public void SetChildObjDistance(GameObject obstacle)
    {
        distance = Random.Range(4, 9);

        topTransform = obstacle.transform.GetChild(0);
        bottomTransform = obstacle.transform.GetChild(1);

        topTransform.localPosition = new Vector3(0, distance / 2, 0);
        bottomTransform.localPosition = new Vector3(0, -(distance / 2), 0);

        obstacle.transform.position = prePosition + new Vector3(xPadding, 0, 0);

        prePosition = obstacle.transform.position;
    }
}
