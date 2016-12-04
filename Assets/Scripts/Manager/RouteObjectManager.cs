
using UnityEngine;
using System.Collections;

public class RouteObjectManager : BaseController {

    [SerializeField]
    private GameObject obstaclePrefab;

    private const float ObstacleStartPosZ = 3.0f;
    	
	// Update is called once per frame
	public override void Update () {
	
        base.Update();

        if (elapsedTime >= 1.5f)
        {
            elapsedTime = 0.0f;
//            InistantiateObstacle();
        }
	}
}
