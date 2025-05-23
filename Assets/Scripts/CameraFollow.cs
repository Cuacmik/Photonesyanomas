using System;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public static CameraFollow Singleton {
        get => _singleton;

        set {
            if (value == null)
                _singleton = null;
            else if (_singleton == null)
                _singleton = value;
            else if (_singleton != value) {
                Destroy(value);
                Debug.LogError($"Deberia haber solamente una instancia de {nameof(CameraFollow)}!");
            }
        }
    }
    private static CameraFollow _singleton;

    private Transform target;

    private void Awake()
    {
        Singleton = this;
    }

    private void OnDestroy()
    {
        if (Singleton == this)
            Singleton = null;
    }

    private void LateUpdate()
    {
        if (target != null) {
            transform.SetPositionAndRotation(target.position, target.rotation);
        }
    }

    public void SetTarget (Transform newTarget) {
        target = newTarget;
    }
}
