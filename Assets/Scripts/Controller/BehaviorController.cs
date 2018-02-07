using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BehaviorController {

    private static GameObject _gameObject;

    public static GameObject GameObject {
        get
        {
            if (_gameObject == null)
                _gameObject = GameObject.GetComponent<GameObject>();
            return _gameObject;
        }
    }

    public BehaviorController()
    {
        BehaviorUpdater.AddToList(this);
    }

	public virtual void OnStart() { }

    public virtual void OnFixedUpdate() { }

    public virtual void OnUpdate() { }
}
