using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    // �÷��̾ �������� �Ѵ�. 

    // ��� �������� ����? 
    // �� �����Ӹ��� ���� �ӵ��� �̵��ϰ� �ϸ� ����
    // �� �����Ӹ��� �̴ϱ� Update? �ƴ�. ���� ���� �̵��� �Ҳ��ϱ� FixedUpdate���� �̵��غ���. 

    // �ٵ� �÷��̾ ���������� �̵��Ϸ��� ������ �ٵ� �ʿ���. 
    // ������ �ٵ� ��������. 
    // �÷��̾�� �浹�� �ؾ��ϴ� �ݶ��̴��� �ʿ��ϴ�. 
    // ������ �ٵ�, �ݶ��̴��� ��� �����ñ�? 

    // ���� �����̽���, ���콺 ���� Ŭ��, ��ġ�� ���� �� �����ϰ� ������. 
    // InputŬ������ ����ؼ� ������. 
    // �Է��� ���� ���� ���� ���ݾ�? 
    // �׷��� �Է� üũ�� �����ϴ°� ������? �� �����Ӹ��� üũ�ϴ°� ������. 
    // Update���� �Է� üũ�� �غ���. 

    // ȸ���� �����غ���. 
    // ��� �ұ�?
    // �ϴ� ȸ���� ������ ���ؾߵ�. 
    // ��ŭ���� �ұ�? 
    // O <- �갡 ������ ġ�� �ִ� 90������ �ּ� -90������ ���̰� �ϸ� �ɰ� ����. 
    // ȸ���� ������ -90 ~ 90
    // ������ �������ϱ� �� �������� ����� �ʰ� ����ߵ�. 
    // �����ð��� �����. Mathf.Clamp(��, ����1, ����2). �� �޼��带 �������. 
    // �׷��� ���� ���� ä���? ȸ����ų ���� ���� �־�� �Ѵ�.
    // �� ������ � ������ ä���? 
    // ��������. �Ʒ��� �������� �Ʒ��� ȸ���ϰ�, ���� �ö󰥶� ���� ȸ���Ѵ�. 
    // �װ� ǥ���ϴ� ���� ����? _rigid.velocity.y
    // ������ _rigid.velocity.y�� ä����. Mathf.Clamp(_rigid.velocity.y, -90, 90)
    // �� �޼���� ���� ������ ȸ���� ��Ű�� �ȴ�. 
    // ȸ���� x, y, z�� ȸ���� �ִ�. � ������ ȸ���� ���Ѿ��ұ�? ���� ������. �װ�. 
    // z�� ȸ���� �ؾ��Ѵ�. 
    // ȸ���� �ϱ��ϴµ� �� ȸ���ϴ� ���� �����̴�. ȸ�������� 10�� ��������. 
    // ������ ȸ���ϴ� ������ ����. 

    // �÷��̾ ���� �浹���� �� �װ� ����� ����. 
    // �浹���� �� ������ �˾ƾ� �װ� ���� �� �ִ�. 
    // �� ������ OnCollisionEnter2D, OnTriggerEnter2D
    // �÷��̾�� ���� �浹�� �ǰ� ����� �ʹ�. �׷��� OnCollisionEnter2D�� �������. 
    // �浹�� �ϸ� �������� ���ϰ� �ϰ� ���� �ִϸ��̼��� ���̰� �غ���. 
    // ������ �����ϴ� ���� �ʿ��ϴ�. ��? �׾��� ���� �����̸� �ȵȴ�. 
    // �̰� ������ fixedupdate���� ĳ���Ͱ� ��� �̵��Ѵ�. �׷��� ������ �����ϴ� ������ �ʿ��ϴ�. 

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
            Debug.LogError("_rigid �ʱ�ȭ ����");
        if (_collider == null)
            Debug.LogError("_collider �ʱ�ȭ ����");
    }

    private void FixedUpdate()
    {
        //float velocityX = moveSpeed;
        //_rigid.velocity = new Vector3(velocityX, 0);

        // ����
        //Vector2 velocity = new Vector2(moveSpeed, 0); // �̵� ���ӵ� ���� -> �̷��� �ϴ� _rigid.velocity.y���� ����. -> ���Խ��Ѿ� �� ���� �������� ������ �������� �������. 

        if (!_isDead)
        {
            Vector3 velocity = _rigid.velocity;
            velocity.x = moveSpeed;

            if (_isJump)
            {
                velocity.y += jumpForce; // ���� ���ӵ� �����ְ� 
                _isJump = false;
            }

            // �� ��� �Ŀ� ����
            _rigid.velocity = velocity;

            // ȸ��
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
        // �浹�� �ϸ� �������� ���ϰ� �ϰ� ���� �ִϸ��̼��� ���̰� �غ���. 
        if (collision.gameObject.CompareTag("background"))
        {
            _isDead = true; // �������� ���ϰ� �ϱ� 

            // ���� �ִϸ��̼� ���̰� �ϱ� -> �ִϸ����Ͱ� �ʿ��ϴ�. 
            _animator.SetInteger("isDead", 1);
        }
    }
}
