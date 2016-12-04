
using UnityEngine;
using System.Collections;

public class RouteObjectManager : BaseManager<RouteObjectManager> {

    [SerializeField]
    private GameObject obstaclePrefab;

    private const float ObstacleStartPosZ = 10.0f;
    	
	// Update is called once per frame
	public override void Update ()
    {
        if (GameManager.Instance.IsGameOver)
        {
            return;
        }

        base.Update();

        if (elapsedTime >= 1.5f)
        {
            elapsedTime = 0.0f;
            InistantiateObstacle();
        }
	}

    /// <summary>
    /// Inistantiates the obstacle.
    /// </summary>
    private void InistantiateObstacle()
    {
        GameObject obstacle = Instantiate(this.obstaclePrefab);
        ObstacleController obstacleController = obstacle.GetComponent<ObstacleController>();

        obstacleController.CollidedWithUnityChan += UnityChanManager.Instance.OnCollidedWithObstacle;
        obstacle.transform.position = new Vector3(0.0f, 0.0f, ObstacleStartPosZ);
    }

}
