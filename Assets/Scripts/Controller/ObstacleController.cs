using UnityEngine;
using System.Collections;
using System;

public class ObstacleController : BaseController {

    public event Action CollidedWithUnityChan = delegate {};
    private bool isMoving = true;
    private Vector3 moveSpeed = new Vector3(0.0f, 0.0f, 6.0f);

    public override void Update()
    {
        if (IsGameOver())
        {
            return;
        }

        if (this.isMoving)
        {
            Vector3 diff = moveSpeed * Time.deltaTime;
            this.gameObject.transform.position = this.gameObject.transform.position - diff;
        }

        if (this.gameObject.transform.position.z <= -1.0f)
        {
            Destroy(this.gameObject);
        }
    }

    void OnCollisionEnter(Collision collision)
    {
        if (IsGameOver())
        {
            return;
        }

        if(collision.gameObject.tag.Contains(Const.Tag.UnityChan))
		{
            this.isMoving = false;
            CollidedWithUnityChan();
		}
    }
}
