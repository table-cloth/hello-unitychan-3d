using UnityEngine;
using System.Collections;
using UnityEditor.VersionControl;

public class BaseManager<T>
    : MonoBehaviour where T
    : Component
{
    private static T instance = null;
    public static T Instance
    {
        get
        {
            if (instance == null)
            {
                instance = FindObjectOfType<T>();
                if (instance == null)
                {
                    GameObject gameObject = new GameObject();
                    gameObject.name = typeof(T).Name;
                    gameObject.hideFlags = HideFlags.DontSave;
                    instance.gameObject.AddComponent<T>();
                }
            }
            return instance;
        }
    }
    protected float elapsedTime = 0.0f;

    /// <summary>
    /// Constructor
    /// Maybe
    /// </summary>
    public BaseManager()
    {
        if (instance == null)
        {
            instance = this as T;
        }
        else
        {
            Destroy(gameObject);
        }
        
        elapsedTime = 0.0f;
    }
	
	// Update is called once per frame
	public virtual void Update () {
        elapsedTime += Time.deltaTime;
	}
}
