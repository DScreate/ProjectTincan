using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ground : MonoBehaviour {

    public Planes plane = Planes.Material;
	
    public void Awake()
    {
        GroundController.AddToList(this);
    }

}
