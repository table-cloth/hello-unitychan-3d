using UnityEngine;
using System.Collections;

public class UnityChanManager : BaseManager<UnityChanManager> {

    [SerializeField]
    private Animator animator;
    [SerializeField]
    private Transform unityChanObject;

    private int currentLane = 0;

    private Vector3 moveDist;
    private Vector3 moveDestinationPos;
    private float moveActionSec;
    private float moveRemainSec;
    private bool isMovingLane = true;

    private float animLengthJump;

    public void Awake()
    {
        float speedJump2Top = 2.0f;
        float speedJump2Ground = 1.0f;
        float exitTimeJump2Ground = 0.25f;

        animLengthJump = 
            AnimUtil.GetAnimationClipLength(animator, Const.Animation.Jump2Top) / speedJump2Top
            + AnimUtil.GetAnimationClipLength(animator, Const.Animation.Jump2Ground) / speedJump2Ground * exitTimeJump2Ground;
    }
        
    public override void Update()
    { 
        if (GameManager.Instance.IsGameOver)
        {
            return;
        }

        base.Update();
        HandleUserActions();

        // force unity chan to look straight ahead
        unityChanObject.localRotation =
            Quaternion.Euler(
                unityChanObject.localRotation.x,
                unityChanObject.localRotation.y,
                0.0f
            );

        if (isMovingLane)
        {
            moveRemainSec -= Time.deltaTime;
            if (moveRemainSec > 0.0f)
            {
                unityChanObject.transform.localPosition += (moveDist * Time.deltaTime / moveActionSec);
            }
            else
            {
                unityChanObject.transform.localPosition = moveDestinationPos;
                isMovingLane = false;
                animator.Play(Const.AnimatorState.Run);
            }
        }
    }

    /// <summary>
    /// Handle user actions related with Unity Chan
    /// </summary>
    private void HandleUserActions()
    {
        // Jump
        if (Input.GetMouseButtonDown(0))
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit raycastHit;

            if (Physics.Raycast(ray, out raycastHit))
            {
                if (raycastHit.transform.gameObject.tag.Contains(Const.Tag.UnityChan))
                {
                    JumpUnityChan(0);
                }
            }
        }
        else if (Input.GetKeyDown(KeyCode.UpArrow))
        {
            JumpUnityChan(0);
        }
        // Slide
        else if (Input.GetKeyDown(KeyCode.DownArrow))
        {
            // TODO slide
        }
        // Move Left
        else if (Input.GetKeyDown(KeyCode.LeftArrow))
        {
            JumpUnityChan(-1);
        }
        // Move Right
        else if (Input.GetKeyDown(KeyCode.RightArrow))
        {
            JumpUnityChan(1);
        }
    }

    /// <summary>
    /// Raises the collision enter event.
    /// </summary>
    /// <param name="collisionWith">Collided with.</param>
    public void OnCollisionEnter(Collision collisionWith)
    {
        if (collisionWith == null)
        {
            return;
        }
        switch (collisionWith.gameObject.tag)
        {
            case Const.Tag.Obstacle:
                OnCollidedWithObstacle();
                break;
            default:
                break;
        }
    }

    /// <summary>
    /// Jumps the unity chan.
    /// </summary>
    /// <param name="laneChange">Lane change.</param>
    public void JumpUnityChan(int laneChange)
    {
        if (isMovingLane)
        {
            return;
        }

        int destLane = currentLane + laneChange;
        if (GameManager.Instance.LaneMin > destLane
           || destLane > GameManager.Instance.LaneMax)
        {
            return;
        }
             

        isMovingLane = true;
        moveDist.x = laneChange * 1.0f;
        moveActionSec = animLengthJump;
        moveRemainSec = moveActionSec;

        moveDestinationPos = unityChanObject.transform.position + moveDist;
        animator.Play(Const.AnimatorState.Jump2Top);

        currentLane += laneChange;
    }

    /// <summary>
    /// Called when collides with obstacle
    /// </summary>
    public void OnCollidedWithObstacle()
    {
        GameManager.Instance.SetIsGameOver(true);
        animator.CrossFade(Const.AnimatorState.FallBack, 0.0f, 0, 0.1f);

//        animator.Play(Const.AnimatorState.FallBack);
    }
}
