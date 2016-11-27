using UnityEngine;
using System.Collections;

public class RunUnityChanController : MonoBehaviour {

    [SerializeField]
    private UnityChanController unityChanController;

    void Update()
    {
        // Right click
        if (Input.GetMouseButtonDown(0))
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit raycastHit;

            if (Physics.Raycast(ray, out raycastHit))
            {
                if (raycastHit.transform.gameObject.tag.Contains("UnityChan"))
                {
                    this.unityChanController.OnTapped();
                }
            }
        }
    }
}
