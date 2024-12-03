using UnityEngine;

[RequireComponent (typeof(Camera))]
public class WorldSizeCamera : MonoBehaviour
{
    [Header("Target")]
    [SerializeField] private Vector2 targetWorldSize;
    [SerializeField] private RectTransform renderingArea;

    [Header("Current State (Debug)")]
    [SerializeField] private Vector2 screenSize; // Screen dimensions in pixels
    [SerializeField] private Vector2 cameraWorldViewSize; // Camera view size in world units
    [SerializeField] private Vector2 renderingAreaScreenSize; // Rendering area size in pixels
    [SerializeField] private Vector2 renderingAreaWorldViewSize; // Rendering area size in world units
    [SerializeField] private Vector4 renderingAreaScreenPadding; // Padding of the rendering area relative to the screen edges

    private Camera cameraComponent;

    private void Awake()
    {
        cameraComponent = GetComponent<Camera>();
        Update();
    }

    public Vector2 GetRenderingAreaScreenSize(RectTransform rectTransform)
    {
        Vector3[] corners = new Vector3[4];
        rectTransform.GetWorldCorners(corners);
        return new Vector2(
            Mathf.Abs(corners[2].x - corners[0].x),
            Mathf.Abs(corners[2].y - corners[0].y)
        );
    }

    public Vector4 GetRenderingAreaScreenPadding(RectTransform rectTransform)
    {
        Vector3[] corners = new Vector3[4];
        rectTransform.GetWorldCorners(corners);
        return new Vector4(
            corners[0].x, // Left
            -(Screen.width - corners[2].x), // Right
            corners[0].y, // Bottom
            -(Screen.height - corners[2].y) // Top
        );
    }

    private void Update()
    {
        UpdateScreenAndWorldSizes();
        AdjustCameraSize();
        AdjustCameraPosition();
    }

    private void UpdateScreenAndWorldSizes()
    {
        screenSize = new Vector2(Screen.width, Screen.height); // Screen dimensions
        renderingAreaScreenSize = GetRenderingAreaScreenSize(renderingArea); // Rendering area size in screen pixels
        renderingAreaScreenPadding = GetRenderingAreaScreenPadding(renderingArea); // Rendering area padding relative to screen
    }

    private void AdjustCameraSize()
    {
        // Orthographic size ratio based on camera aspect
        Vector2 orthographicSizeCameraRatio = new Vector2(2 * cameraComponent.aspect, 2);

        // Calculate required orthographic size to match the target world size
        Vector2 requiredOrthographicSize = targetWorldSize * screenSize / renderingAreaScreenSize / orthographicSizeCameraRatio;

        // Set the camera's orthographic size
        cameraComponent.orthographicSize = Mathf.Max(requiredOrthographicSize.x, requiredOrthographicSize.y);

        // Calculate camera world view size
        cameraWorldViewSize = orthographicSizeCameraRatio * cameraComponent.orthographicSize;

        // Calculate rendering area world view size
        renderingAreaWorldViewSize = cameraWorldViewSize * renderingAreaScreenSize / screenSize;
    }

    private void AdjustCameraPosition()
    {
        // Calculate rendering area screen offset
        Vector2 renderingAreaScreenOffset = new(
            renderingAreaScreenPadding.x + renderingAreaScreenPadding.y,
            renderingAreaScreenPadding.z + renderingAreaScreenPadding.w
        );

        // Convert screen offset to world offset
        Vector2 renderingAreaWorldViewOffset = renderingAreaWorldViewSize / renderingAreaScreenSize * renderingAreaScreenOffset;

        // Calculate additional offset if rendering area is smaller than the target size
        Vector2 extraWorldOffset = new(
            Mathf.Min(renderingAreaWorldViewSize.x - targetWorldSize.x, 0f),
            Mathf.Min(renderingAreaWorldViewSize.y - targetWorldSize.y, 0f)
        );

        // Calculate final camera offset
        Vector2 cameraOffset = - (renderingAreaWorldViewOffset + extraWorldOffset) / 2;

        // Apply position adjustment (preserve z-axis)
        transform.position = new(cameraOffset.x, cameraOffset.y, transform.position.z);
    }

    internal void SetTargetWorldSize(Vector2 newValue) => targetWorldSize = newValue;
}
