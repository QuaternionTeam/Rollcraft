using UnityEngine;
using UnityEngine.UI;

public class BlackFilter : MonoBehaviour
{
    private Canvas canvas;
    private Image blackFilterImage;

    internal void Start()
    {
        canvas = GetComponent<Canvas>();

        GameObject filterObject = new GameObject("BlackFilter");
        filterObject.transform.SetParent(canvas.transform, false);

        blackFilterImage = filterObject.AddComponent<Image>();
        blackFilterImage.color = new Color(0f, 0f, 0f, 0.9f);

        RectTransform rt = filterObject.GetComponent<RectTransform>();
        rt.anchorMin = new Vector2(0, 0);
        rt.anchorMax = new Vector2(1, 1);
        rt.offsetMin = new Vector2(0, 0);
        rt.offsetMax = new Vector2(0, 0);
    }
}
