using UnityEngine;
using UnityEngine.UI;
using System.Collections.Generic;

public class DragDice : MonoBehaviour
{
    public bool dragging;

    public Vector3 initialPosition;

    public RawImage diceImage;

    public bool diceClicked;
    public bool target;


    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        initialPosition = diceImage.rectTransform.position;

    }

    // Update is called once per frame
    void Update()
    {
        if(dragging)
        {
            Vector3 mousePosition = new Vector2(Camera.main.ScreenToWorldPoint(Input.mousePosition).x,Camera.main.ScreenToWorldPoint(Input.mousePosition).y);

            diceImage.rectTransform.position = mousePosition;
        }
        
    }


    public void OnMouseOver()
    {

    }

    public void OnMouseDown()
    {
        dragging = true;
        print(dragging);
    }

    public void OnMouseUp()
    {
        dragging=false;
        if(target)
        {
            // utiliza poder del coso

        }

         diceImage.rectTransform.position = initialPosition;

    }

    void OnTriggerStay2D(Collider2D collider)
    {
        if(collider.gameObject.GetComponent<Rigidbody2D>() != null)
        target = true;
    }

}
