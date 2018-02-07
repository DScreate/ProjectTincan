using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ground : MonoBehaviour {

    public Planes plane = Planes.Material;
	
    public void Awake()
    {
        Renderer renderer = gameObject.GetComponent<Renderer>();

        Material[] temp = renderer.materials;

        temp[0] = GroundController.groundController.materials[(int)plane];

        renderer.materials = temp;

        GroundController.AddToList(this);
    }

}
