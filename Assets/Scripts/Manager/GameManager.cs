using UnityEngine;
using System.Collections;

public class GameManager : BaseManager<GameManager> {

    public bool IsGameOver { get; set; }

    [SerializeField]
    private UnityChanController unityChanController;

    /// <summary>
    /// Private constructor
    /// </summary>
    public GameManager() : base()
    {
        IsGameOver = false;
    }

    /// <summary>
    /// Set is game over.
    /// </summary>
    /// <param name="isGameOver">If set to <c>true</c> is game over.</param>
    public void SetIsGameOver(bool isGameOver)
    {
        IsGameOver = isGameOver;        
    }

    public override void Update()
    {
        if (this.IsGameOver)
        {
            return;
        }

        base.Update();
    }

//    public void OnUnityChanCollideWithObject(int objectType)
//    {
//        switch (objectType)
//        {
//            case Const.ObjectType.Obstacle:
//            default:
//                UnityChanController.Instance.OnCollidedWithObstacle();
//                break;
//        }
//    }


//    private void InistantiateObstacle()
//    {
//        GameObject obstacle = Instantiate(this.obstaclePrefab);
//        ObstacleController obstacleController = obstacle.GetComponent<ObstacleController>();
//
//        obstacleController.CollidedWithUnityChan += this.ObstacleCollidedWithUnityChan;
//        obstacle.transform.position = new Vector3(0.0f, 0.0f, ObstacleStartPosZ);
//    }
//
//    private void ObstacleCollidedWithUnityChan()
//    {
//        if (this.isGameOver)
//        {
//            return;
//        }
//        this.unityChanController.OnCollidedWithObstacle();
//        this.isGameOver = true;
//    }
}
