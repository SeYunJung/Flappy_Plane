using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstacleManager : MonoBehaviour
{
    // ��ֹ��� �ڵ����� �����Ϸ��� �� �ؾ��ұ�? 
    // ���� �������� ��ġ�ϸ� ����. 
    // ��� ��ġ�ұ�? 
    // ���ǿ����� ��� ��ġ����? top�� bottom�� �Ÿ��� ���ϰ�, �� �Ÿ���ŭ top�� bottom�� �������� �߾�.
    // �׷��� �̷��� ����. 
    // top, bottom ���� �Ÿ��� ����.
    // �Ÿ��� 4���, top�� ���� ��ǥ�� (0, 2, 0) bottom�� ���� ��ǥ�� (0, -2, 0)�� �ϸ� top�� bottom ���� �Ÿ���
    // 4�� �ǰڳ�. 
    // �׷��� top�� bottom ���� �Ÿ��� ���߾�. 
    // ���� Obstacle�� ��ġ�ؾߵ�.
    // � ��ġ�� � ��Ģ���� Obstacle�� ��ġ�ұ�? 
    // �̰� �𸣰ھ�. ���� ������ ����. 
    // ���� ���뿡���� ���� ��ġ + ���� ������ŭ �ؼ� Obstacle�� ��ġ�� �����ϰ� �־�. 
    // ���� ��ġ? ó�� ��ġ�Ǵ� Obstacle�� ���� ��ġ�� 0���ݾ�. ó�� ��ġ�Ǵ� Obstacle�� (0,0,0) + ���� ����
    // �� ���� Obstacle�� ���� ��ġ + �������� ��ŭ ��ġ�ϸ��. 

    // Obstacle�� ó���� ��� �ұ�?
    // �̰� ���� ���ؾ���. 
    // 5���� ����. 5���� ��� ��Ȱ���ϸ� �ȴ�. 
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

    // ó�� ������ �� �� �Ʒ�(top, bottom) ��ġ ���� ��, ��ֹ�(Obstacle) ��ġ
    void Start()
    {
        if(obstacle != null)
        {
            prePosition = transform.position;
            for(int i = 0; i <  obstacleCount; i++)
            {
                Instantiate(obstacle, transform);

                // top, bottom ���� �Ÿ� ����
                // ������ ��ֹ�(Obstacle)�� top, bottom ���� �Ÿ� ����
                distance = Random.Range(4, 9);

                topTransform = obstacle.transform.GetChild(0);
                bottomTransform = obstacle.transform.GetChild(1);

                topTransform.localPosition = new Vector3(0, distance / 2, 0);
                bottomTransform.localPosition = new Vector3(0, -(distance / 2), 0);

                // ��ֹ�(Obstacle)�� ��ġ ���� 
                // ���� ��ġ + ���� ���� 
                // ��ġ ��ġ
                //transform.position = prePosition + new Vector3(xPadding, 0, 0);
                if (i == 0)
                    obstacle.transform.position = prePosition;
                else
                    obstacle.transform.position = prePosition + new Vector3(xPadding+2, 0, 0);

                // ���� ��ġ ����
                prePosition = obstacle.transform.position;
            }
        }
    }

    public void SetObstaclePosition(GameObject obstacle, float collidingObjWidth)
    {
        Transform collidingObjTransform = obstacle.GetComponent<Transform>(); // Transform�� �����ͼ� 
        Vector3 collidingObjPos = collidingObjTransform.position;
        collidingObjPos.x += (collidingObjWidth * 5f);
        collidingObjTransform.position = collidingObjPos; // ��ġ �̵�
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
