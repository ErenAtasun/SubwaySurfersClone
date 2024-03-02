using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]

public enum SIDE { Left, Mid, Right}

public class CharacterControl : MonoBehaviour
{
    public SIDE m_Side = SIDE.Mid;
    float NewXPos = 0f;
    [HideInInspector]
    public bool SwipeLeft, SwipeRight, SwipeUp, SwipeDown;
    public float XValue;
    private CharacterController m_char;
    private Animator anim;
    private float x;

    public float DodgeSpeed;
    public float JumpPower=7f;
    private float y;
    public bool InJump;
    public bool InRoll;
    public float ForwardSpeed = 5f;
    private float ColHeight;
    private float ColCenterY;
    public float AccelerationRate = 0.5f;
    public float MaxForwardSpeed = 10;

    

    void Start()
    {


        m_char = GetComponent<CharacterController>();
        ColHeight = m_char.height;
        ColCenterY = m_char.center.y;
        Vector3 newPosition = new Vector3(0f, 0f, -51f);
        transform.position = newPosition;
        anim = GetComponent<Animator>();

        
    }

    void Update()   
    {
        SwipeLeft = Input.GetKeyDown(KeyCode.A) || Input.GetKeyDown(KeyCode.LeftArrow);
        SwipeRight = Input.GetKeyDown(KeyCode.D) || Input.GetKeyDown(KeyCode.RightArrow);
        SwipeUp= Input.GetKeyDown(KeyCode.W) || Input.GetKeyDown(KeyCode.UpArrow);
        SwipeDown = Input.GetKeyDown(KeyCode.S) || Input.GetKeyDown(KeyCode.DownArrow);

        ForwardSpeed += AccelerationRate * Time.deltaTime;
        ForwardSpeed = Mathf.Min(ForwardSpeed, MaxForwardSpeed);

        if (SwipeLeft&& !InRoll)
        {
            if (m_Side == SIDE.Mid)
            {
                NewXPos = -XValue;
                m_Side = SIDE.Left;
                anim.Play("dodgeLeft");
            }
            else if (m_Side == SIDE.Right)
            {
                NewXPos = 0;
                m_Side = SIDE.Mid;
                anim.Play("dodgeLeft");
            }
        }
        else if (SwipeRight && !InRoll)
        {
            if (m_Side == SIDE.Mid)
            {
                NewXPos = XValue;
                m_Side = SIDE.Right;
                anim.Play("dodgeRight");
            }
            else if (m_Side == SIDE.Left)
            {
                NewXPos = 0;
                m_Side = SIDE.Mid;
                anim.Play("dodgeRight");
            }
        }
        Vector3 moveVector = new Vector3(x - transform.position.x, y * Time.deltaTime, ForwardSpeed * Time.deltaTime);
        x = Mathf.Lerp(x, NewXPos, Time.deltaTime * DodgeSpeed);
        m_char.Move(moveVector);
        Jump();
        Roll();
    }

    public void Jump()
    {
        if (m_char.isGrounded)
        {
            if (anim.GetCurrentAnimatorStateInfo(0).IsName("Falling"))
            {
                anim.Play("Landing");
                InJump = false;
            }
            if (SwipeUp)
            {
                y = JumpPower;
                anim.CrossFadeInFixedTime("Jump", 0.1f);
                InJump = true;
            }
        }
        else
        {
            y -= JumpPower * 2 * Time.deltaTime;
            if (m_char.velocity.y < -0.1f)
            anim.Play("Falling");
        }
    }
    internal float RollCounter;
    public void Roll()
    {
        RollCounter -= Time.deltaTime;
        if(RollCounter <= 0f)
        {
            RollCounter = 0f;
            m_char.center = new Vector3(0, ColCenterY, 0);
            m_char.height = ColHeight;
            InRoll = false;
        }

        if (SwipeDown)
        {
            RollCounter = 0.9f;
            y -= 10f;
            m_char.center = new Vector3(0, ColCenterY/2f, 0);
            m_char.height = ColHeight/2f;
            anim.CrossFadeInFixedTime("Roll", 0.1f);
            InRoll = true;
            InJump = false;       
        }
    }
}
