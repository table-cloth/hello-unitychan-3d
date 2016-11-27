using UnityEngine;
using System.Collections;

public class UnityChanController : MonoBehaviour {

    /// <summary>
    /// Raises the tapped event.
    /// </summary>
    public void OnTapped()
    {
        this.GetComponent<Animator>().SetTrigger("Jump");
    }

    /// <summary>
    /// Called on the call change face.
    /// </summary>
    public void OnCallChangeFace()
    {
        // Do nothing for now
    }

}
