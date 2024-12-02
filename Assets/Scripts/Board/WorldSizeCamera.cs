using Unity.VisualScripting;
using UnityEngine;

[RequireComponent (typeof(Camera))]
public class WorldSizeCamera : MonoBehaviour
{
    [Header("Target")]
    [SerializeField] private Vector2 targetWorldSize;
    [SerializeField] private RectTransform worldView;

    [Header("Current state")]
    [SerializeField] private Vector2 screenSize;
    [SerializeField] private Vector2 worldViewSize;
    [SerializeField] private Vector2 realScreenSize;
    [SerializeField] private Vector2 realWorldViewSize;
    [SerializeField] private Vector4 screenPadding;
    [SerializeField] private Vector2 cameraOffset;

    private Camera cameraComponent;
    private Vector2 orthographicSizeCameraRatio;

    private void Awake()
    {
        cameraComponent = GetComponent<Camera>();
        Update();
    }

    public Vector2 GetRealSceenViewSize(RectTransform rectTransform)
    {
        Vector3[] corners = new Vector3[4];
        rectTransform.GetWorldCorners(corners);

        float width = Mathf.Abs(corners[2].x - corners[0].x);
        float height = Mathf.Abs(corners[2].y - corners[0].y);

        return new Vector2(width, height);
    }

    public Vector4 GetRealSceenPadding(RectTransform rectTransform)
    {
        Vector3[] corners = new Vector3[4];
        rectTransform.GetWorldCorners(corners);
        return new Vector4(corners[0].x, -(Screen.width - corners[2].x), corners[0].y, -(Screen.height - corners[2].y));
    }

    private void CalculateCurrentState()
    {
        orthographicSizeCameraRatio = new Vector2(2 * cameraComponent.aspect, 2);

        screenSize = new Vector2(Screen.width, Screen.height);
        worldViewSize = cameraComponent.orthographicSize * orthographicSizeCameraRatio;

        realScreenSize = GetRealSceenViewSize(worldView);
        realWorldViewSize = worldViewSize / screenSize * realScreenSize;
    }

    private void Update()
    {
        CalculateCurrentState();

        // Set orthographic size
        Vector2 requiredOrthographicSize = targetWorldSize * screenSize / realScreenSize / orthographicSizeCameraRatio;
        cameraComponent.orthographicSize = Mathf.Max(requiredOrthographicSize.x, requiredOrthographicSize.y);

        // Move camera
        screenPadding = GetRealSceenPadding(worldView);
        Vector2 screenOffset = new(screenPadding.x + screenPadding.y, screenPadding.z + screenPadding.w);
        cameraOffset = screenOffset * (realWorldViewSize / realScreenSize);
        transform.position = new Vector3(cameraOffset.x, cameraOffset.y, transform.position.z);
    }

    internal void SetTargetWorldSize(Vector2 newValue) => targetWorldSize = newValue;
}
