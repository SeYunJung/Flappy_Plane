using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstacleGenerator : MonoBehaviour
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

    void Start()
    {
        if(obstacle != null)
        {
            for(int i = 0; i <  obstacleCount; i++)
            {
                Instantiate(obstacle, transform);

                // top, bottom ���� �Ÿ� ����
                
            }
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
