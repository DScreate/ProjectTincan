using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlaneShifter : MonoBehaviour {

    public Planes plane = Planes.Material;

    private bool isActive = true;
    private BoxCollider2D _boxCollider2D;
    private Material _material;
    private Renderer _renderer;

    public void Awake()
    {
        _boxCollider2D = gameObject.GetComponent<BoxCollider2D>();
        _material = PlaneController.planeController.materials[(int)plane];
        _renderer = gameObject.GetComponent<Renderer>();

        SetRendererMaterial(1f);

        PlaneController.AddToList(this);
    }

    public void SetIsActive(bool active)
    {
        isActive = active;

        if(_boxCollider2D != null)
            _boxCollider2D.enabled = isActive;

        if (isActive && _renderer != null && _material != null)
            SetRendererMaterial(1f);
        else
            SetRendererMaterial(0.5f);
    }

    private void SetRendererMaterial(float alpha)
    {
        Material[] tempMats = _renderer.materials;
        Color tempColor = _material.color;
        tempColor.a = Mathf.Clamp01(alpha);
        tempMats[0] = _material;
        tempMats[0].color = tempColor; // We have to set this directly just like the material below
        _renderer.materials = tempMats;
    }

}
