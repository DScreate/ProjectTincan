using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BehaviorUpdater : MonoBehaviour {

    private static List<BehaviorController> _bcList;

    private static BehaviorUpdater _behaviorUpdater;

    public static BehaviorUpdater behaviorUpdater
    {
        get
        {
            if (_behaviorUpdater == null)
            {
                _behaviorUpdater = FindObjectOfType<BehaviorUpdater>();
            }

            return _behaviorUpdater;
        }
    }

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		foreach(BehaviorController bc in _bcList)
        {
            bc.OnUpdate();
        }
	}

    void FixedUpdate ()
    {
        foreach (BehaviorController bc in _bcList)
        {
            bc.OnFixedUpdate();
        }
    }

    public static void AddToList (BehaviorController bc)
    {
        if (!_bcList.Contains(bc))
        {
            bc.OnStart();
            _bcList.Add(bc);
        }
        else
            throw new System.Exception("AddToList -> BC already exists");
    }
}
