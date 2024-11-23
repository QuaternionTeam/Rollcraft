using UnityEngine;

public class DragDice : MonoBehaviour
{
    public bool dragging;

    public Vector3 initialPosition;


    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        //initialPosition = 
    }

    // Update is called once per frame
    void Update()
    {
        if(dragging)
        {
            Vector3 mousePOsition = new Vector2(Camera.main.ScreenToWorldPoint(Input.mousePosition).x,Camera.main.ScreenToWorldPoint(Input.mousePosition).y);
        }
    }


    public void OnMouseDown()
    {
        dragging = true;
        print(dragging);
    }

}
