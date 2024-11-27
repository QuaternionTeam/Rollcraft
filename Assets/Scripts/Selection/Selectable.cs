using UnityEngine;

internal class Selectable : MonoBehaviour
{
    private Renderer rendererComponent;
    private Color originalColor;
    //private static Material defaultMaterial;

    internal void Start()
    {
        rendererComponent = GetComponent<Renderer>();
        originalColor = rendererComponent.material.color;

        //if (!defaultMaterial)
        //    defaultMaterial = new Material(Shader.Find("Standard")) { color = originalColor};
        
    }

    internal void SelectObject(bool isSelected)
    {
        Debug.Log("I was Selected");
        rendererComponent.material.color = isSelected ? Color.green: originalColor;
    }
}
