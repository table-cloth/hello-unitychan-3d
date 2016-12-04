using UnityEngine;
using System.Collections;
using UnityEditor.VersionControl;

public class BaseController : MonoBehaviour
{
    protected float elapsedTime = 0.0f;

    /// <summary>
    /// Constructor
    /// Maybe
    /// </summary>
    public BaseController()
    {
        elapsedTime = 0.0f;
    }
	
    /// <summary>
    /// Checks if game is over
    /// </summary>
    /// <returns><c>true</c> if this instance is game over; otherwise, <c>false</c>.</returns>
    protected bool IsGameOver()
    {
        return GameManager.Instance.IsGameOver;
    }

	// Update is called once per frame
	public virtual void Update () {
        elapsedTime += Time.deltaTime;
	}
}
