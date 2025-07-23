using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    // 플레이어가 움직여야 한다. 

    // 어떻게 움직여야 하지? 
    // 매 프레임마다 일정 속도로 이동하게 하면 되지
    // 매 프레임마다 이니까 Update? 아니. 나는 물리 이동을 할꺼니까 FixedUpdate에서 이동해보자. 

    // 근데 플레이어가 물리적으로 이동하려면 리지드 바디가 필요해. 
    // 리지드 바디를 가져오자. 
    // 플레이어는 충돌도 해야하니 콜라이더도 필요하다. 
    // 리지드 바디, 콜라이더는 어디서 가져올까? 

    // 내가 스페이스바, 마우스 왼쪽 클릭, 터치를 했을 때 점프하게 만들어보자. 
    // Input클래스를 사용해서 만들어보자. 
    // 입력은 내가 언제 할지 모르잖아? 
    // 그래서 입력 체크는 언제하는게 좋을까? 매 프레임마다 체크하는게 좋겠지. 
    // Update에서 입력 체크를 해보자. 

    // 회전도 적용해보자. 
    // 어떻게 할까?
    // 일단 회전의 범위를 정해야돼. 
    // 얼만큼으로 할까? 
    // O <- 얘가 비행기라 치면 최대 90도까지 최소 -90도까지 꺾이게 하면 될것 같아. 
    // 회전의 범위는 -90 ~ 90
    // 범위를 정했으니까 이 범위에서 벗어나지 않게 해줘야돼. 
    // 수업시간에 배웠어. Mathf.Clamp(값, 범위1, 범위2). 이 메서드를 사용하자. 
    // 그러면 값은 뭘로 채울까? 회전시킬 기준 값을 넣어야 한다.
    // 그 기준을 어떤 값으로 채울까? 
    // 생각보자. 아래로 떨어질때 아래로 회전하고, 위로 올라갈때 위로 회전한다. 
    // 그걸 표현하는 값이 뭐지? _rigid.velocity.y
    // 값에는 _rigid.velocity.y를 채우자. Mathf.Clamp(_rigid.velocity.y, -90, 90)
    // 이 메서드로 나온 값으로 회전을 시키면 된다. 
    // 회전도 x, y, z축 회전이 있다. 어떤 축으로 회전을 시켜야할까? 직접 봐야지. 그건. 
    // z축 회전을 해야한다. 
    // 회전을 하긴하는데 덜 회전하는 듯한 느낌이다. 회전각도에 10을 곱해주자. 
    // 이제야 회전하는 느낌이 난다. 

    // 플레이어가 땅과 충돌했을 때 죽게 만들어 보자. 
    // 충돌했을 때 시점을 알아야 죽게 만들 수 있다. 
    // 그 시점이 OnCollisionEnter2D, OnTriggerEnter2D
    // 플레이어는 땅과 충돌이 되게 만들고 싶다. 그러니 OnCollisionEnter2D를 사용하자. 
    // 충돌을 하면 움직이지 못하게 하고 죽은 애니메이션을 보이게 해보자. 
    // 죽음을 구분하는 값이 필요하다. 왜? 죽었을 때는 움직이면 안된다. 
    // 이게 없으면 fixedupdate에서 캐릭터가 계속 이동한다. 그래서 죽음을 구분하는 변수가 필요하다. 

    private Rigidbody2D _rigid;
    private CircleCollider2D _collider;

    public float moveSpeed = 1.0f;
    public float jumpForce = 1.0f;

    private bool _isJump;

    private bool _isDead;

    private Animator _animator;

    private void Awake()
    {
        _rigid = GetComponent<Rigidbody2D>();
        _collider = GetComponent<CircleCollider2D>();
        _animator = GetComponentInChildren<Animator>();

        if (_rigid == null)
            Debug.LogError("_rigid 초기화 에러");
        if (_collider == null)
            Debug.LogError("_collider 초기화 에러");
    }

    private void FixedUpdate()
    {
        //float velocityX = moveSpeed;
        //_rigid.velocity = new Vector3(velocityX, 0);

        // 수정
        //Vector2 velocity = new Vector2(moveSpeed, 0); // 이동 가속도 설정 -> 이렇게 하니 _rigid.velocity.y값이 씹힘. -> 포함시켜야 할 값을 포함하지 않으니 움직임이 어색해짐. 

        if (!_isDead)
        {
            Vector3 velocity = _rigid.velocity;
            velocity.x = moveSpeed;

            if (_isJump)
            {
                velocity.y += jumpForce; // 점프 가속도 더해주고 
                _isJump = false;
            }

            // 다 계산 후에 적용
            _rigid.velocity = velocity;

            // 회전
            float angle = Mathf.Clamp(_rigid.velocity.y * 10f, -90, 90);
            transform.rotation = Quaternion.Euler(0, 0, angle);
        }
    }

    private void Update()
    {
        if(Input.GetKey(KeyCode.Space) || Input.GetMouseButtonDown(0))
        {
            _isJump = true;
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        // 충돌을 하면 움직이지 못하게 하고 죽은 애니메이션을 보이게 해보자. 
        if (collision.gameObject.CompareTag("background"))
        {
            _isDead = true; // 움직이지 못하게 하기 

            // 죽은 애니메이션 보이게 하기 -> 애니메이터가 필요하다. 
            _animator.SetInteger("isDead", 1);
        }
    }
}
