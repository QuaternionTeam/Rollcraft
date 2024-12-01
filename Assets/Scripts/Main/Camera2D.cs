using UnityEngine;
using UnityEngine.UI;

internal class Camera2D : MonoBehaviour
{
    [SerializeField] private RawImage renderUITarget;
    private Vector2 lastRenderScreenSize;

    void Update()
    {
        Vector2 currentRenderScreeSize = GetScreenCoordinates(renderUITarget.rectTransform).size;
        if (lastRenderScreenSize != currentRenderScreeSize)
        {
            lastRenderScreenSize = currentRenderScreeSize;
            OnScreenSizeChanged(currentRenderScreeSize);
        }
    }

    private Rect GetScreenCoordinates(RectTransform uiElement)
    {
        var worldCorners = new Vector3[4];
        uiElement.GetWorldCorners(worldCorners);
        var result = new Rect(
                      worldCorners[0].x,
                      worldCorners[0].y,
                      worldCorners[2].x - worldCorners[0].x,
                      worldCorners[2].y - worldCorners[0].y);
        return result;
    }

    private void OnScreenSizeChanged(Vector2 newRenderScreenSize)
    {
        renderUITarget.texture.width = Mathf.CeilToInt(newRenderScreenSize.x);
        renderUITarget.texture.height = Mathf.CeilToInt(newRenderScreenSize.y);
    }
}
