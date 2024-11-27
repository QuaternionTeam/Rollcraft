using UnityEngine;

internal class SpriteDuplicator : MonoBehaviour
{
    public int layer = 7; //Highlights
    public float scaleMultiplier = 1.2f; 
    public Color duplicateColor = Color.green;

    internal void Start()
    {
        SpriteRenderer originalSpriteRenderer = GetComponent<SpriteRenderer>();

        if (!originalSpriteRenderer)
            return;
        
        GameObject duplicate = new GameObject("DuplicateSprite");
        SpriteRenderer duplicateSpriteRenderer = duplicate.AddComponent<SpriteRenderer>();

        duplicateSpriteRenderer.sprite = originalSpriteRenderer.sprite;
        duplicate.transform.position = originalSpriteRenderer.transform.position;
        //new Vector3(transform.position.x, transform.position.y, transform.position.z - 0.1f); // -0.1f for depth behind the original
        duplicate.transform.localScale = originalSpriteRenderer.transform.localScale * scaleMultiplier;
        duplicateSpriteRenderer.color = duplicateColor;
        
    }
}
