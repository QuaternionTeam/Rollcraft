using System.Collections.Generic;
using UnityEngine;

internal class Selector : MonoBehaviour
{
    private Camera mainCamera;
    private readonly List<Selectable> selectedOnes = new();
    public LayerMask selectableLayer;

    internal void Start()
    {
        mainCamera = Camera.main;
    }

    internal void Update()
    {
        HandleSelection();
    }

    internal void HandleSelection()
    {
        if (!Input.GetMouseButtonDown(0))
            return; 

        Ray ray = mainCamera.ScreenPointToRay(Input.mousePosition);

        RaycastHit2D hit = Physics2D.Raycast(ray.origin, ray.direction, Mathf.Infinity, selectableLayer);

        if (!hit.collider)
            return;
        
        Selectable clickedOne = hit.collider.GetComponent<Selectable>();

        if (!clickedOne)
            return;
        
        if (selectedOnes.Contains(clickedOne))
            Deselect(clickedOne);
        
        else
            Select(clickedOne);
    }

    private void Select(Selectable selectable)
    {
        selectedOnes.Add(selectable);
        selectable.SelectObject(true);
    }

    private void Deselect(Selectable selectable)
    {
        selectedOnes.Remove(selectable);
        selectable.SelectObject(false);
    }
}
