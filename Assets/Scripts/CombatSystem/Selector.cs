using UnityEngine;

internal static class Selector
{
    internal static T GetOnClick<T>(LayerMask layer) where T : Unit
    {
        if (!Input.GetMouseButtonDown(0))
            return null; 
   
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);

        RaycastHit2D hit = Physics2D.Raycast(ray.origin, ray.direction, Mathf.Infinity, layer);

        if (!hit.collider)
            return null;
        
        T clicked = hit.collider.GetComponent<T>();

        if (!clicked)
            return null;

        return clicked;
    }
}