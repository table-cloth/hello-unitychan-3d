using UnityEngine;
using System.Collections;

public class UnityChanController : BaseController {

    [SerializeField]
    private Animator animator;
    [SerializeField]
    private Transform unityChanObject;

    public override void Update()
    { 
        if (IsGameOver())
        {
            return;
        }

        base.Update();
        HandleUserActions();
        unityChanObject.localRotation =
            Quaternion.Euler(
                unityChanObject.localRotation.x,
                unityChanObject.localRotation.y,
                0.0f
            );
    }

    /// <summary>
    /// Handle user actions related with Unity Chan
    /// </summary>
    private void HandleUserActions()
    {
        // Right click
        if (Input.GetMouseButtonDown(0))
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit raycastHit;

            if (Physics.Raycast(ray, out raycastHit))
            {
                if (raycastHit.transform.gameObject.tag.Contains(Const.Tag.UnityChan))
                {
                    OnTappedUnityChan();
                }
            }
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
    /// Called when unity chan is tapped
    /// </summary>
    public void OnTappedUnityChan()
    {
        this.GetComponent<Animator>().SetTrigger("Jump");
    }

    /// <summary>
    /// Called when collides with obstacle
    /// </summary>
    public void OnCollidedWithObstacle()
    {
        GameManager.Instance.SetIsGameOver(true);
        this.GetComponent<Animator>().SetTrigger("Collision");
    }

    /// <summary>
    /// Called on the call change face.
    /// </summary>
    public void OnCallChangeFace()
    {
        // Do nothing for now
    }

}
