using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GroundController : MonoBehaviour {

    private static GroundController _groundController;

    public static GroundController groundController
    {
        get
        {
            if (_groundController == null)
                _groundController = FindObjectOfType<GroundController>();

            return _groundController;
        }
    }

    private static List<Ground> _groundList = new List<Ground>();

    public static Planes activePlane;

    public Planes startPlane = Planes.Material;

    public Material[] materials;

    public void Awake()
    {
        activePlane = startPlane;
        SetGroundPlanes();
    }

    public static void SetActivePlane(Planes plane)
    {
        activePlane = plane;

        SetGroundPlanes();
    }

    public static void AddToList(Ground ground)
    {
        if (!_groundList.Contains(ground))
            _groundList.Add(ground);
    }

    private static void SetGroundPlanes()
    {
        //Debug.Log("Set Ground Planes");

        foreach(Ground ground in _groundList)
        {
            ground.gameObject.SetActive(ground.plane == activePlane);
        }
    }

}
