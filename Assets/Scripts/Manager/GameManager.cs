using UnityEngine;
using System.Collections;

public class GameManager : BaseManager<GameManager> {

    public bool IsGameOver { get; set; }
    public int LaneMax { get; set; }
    public int LaneMin { get; set; }


//    [SerializeField]
//    private UnityChanManager unityChanController;

    /// <summary>
    /// Private constructor
    /// </summary>
    public GameManager() : base()
    {
        IsGameOver = false;
        LaneMin = -1;
        LaneMax = 1;
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
