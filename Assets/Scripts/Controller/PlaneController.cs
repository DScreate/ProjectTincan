using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlaneController : MonoBehaviour {

    private static PlaneController _planeController;

    public static PlaneController planeController
    {
        get
        {
            if (_planeController == null)
                _planeController = FindObjectOfType<PlaneController>();

            return _planeController;
        }
    }

    private static List<PlaneShifter> _planeShifters = new List<PlaneShifter>();

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

    public static void AddToList(PlaneShifter ground)
    {
        if (!_planeShifters.Contains(ground))
            _planeShifters.Add(ground);
    }

    private static void SetGroundPlanes()
    {
        //Debug.Log("Set Ground Planes");

        foreach(PlaneShifter planeShifter in _planeShifters)
        {
            planeShifter.SetIsActive(planeShifter.plane == activePlane);
        }
    }

}
