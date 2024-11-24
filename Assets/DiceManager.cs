using UnityEngine;
using UnityEngine.UI;

public class DiceManager : MonoBehaviour
{
    static DiceManager instance; 
    public bool dragging;
    public bool target;
    public GameObject targetGameObject;
    public Vector3 initialPosition;

    public bool diceClicked;

    public bool targetSelected;

    public int numDice;

    public Animator anim;

    public GameObject diceObject;
    public SpriteRenderer[] diceFaces;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        instance = this;

        initialPosition = gameObject.transform.position;
        anim = GetComponent<Animator>();

    }


    public void rollDice() //(int numDice, Face[] faces)
    {
        // for (int i = 0; i < faces.Length; i++) {
            // diceFaces[i].sprite = faces[i];
        // }

        /*
        numDice = ; //  aplicar lógica del número de dado
                    //  aplicar lógica de cambiar las caras
        */
        // canUseDice= true;
        playAnim();

    }


    // Update is called once per frame
    void Update()
    {

        if (true)
        {
            if (Input.GetKeyDown("p"))
                playAnim();

            if (dragging)
            {
                Vector3 mousePosition = new Vector2(Camera.main.ScreenToWorldPoint(Input.mousePosition).x, Camera.main.ScreenToWorldPoint(Input.mousePosition).y);

                gameObject.transform.position = mousePosition;
            }
            if (diceClicked)
            {
                print("Dado seleccionado");
                Vector3 mousePosition = new Vector2(Camera.main.ScreenToWorldPoint(Input.mousePosition).x, Camera.main.ScreenToWorldPoint(Input.mousePosition).y);
                RaycastHit2D ray = Physics2D.Raycast(mousePosition, mousePosition);
                if (ray.collider != null && ray.collider != gameObject.GetComponent<Collider2D>() && Input.GetMouseButtonDown(0))
                {
                    targetSelected = true;
                    print("objetivo seleccionado");
                    applyDiceEffect();
                }

            }
        }


    }

    public void OnMouseDown()
    {
        dragging = true;
        diceClicked = true;
        print("arrastrar objeto");
    }

    public void OnMouseUp()
    {
        print("soltar objeto");
        dragging = false;
        if (target)
        {
            // utiliza poder del coso
            print("seleccionaste objetivo");
            applyDiceEffect();
        }
        target = false;
        gameObject.transform.position = initialPosition;

    }

    void OnTriggerStay2D(Collider2D collider)
    {
        if (collider.gameObject.GetComponent<Rigidbody2D>() != null)
        {
            target = true;
            targetGameObject = collider.gameObject;
        }
    }



    public void applyDiceEffect()
    {
        if (targetGameObject.GetComponent<Unit>())
        {

        }
        diceObject.SetActive(false);
        // canUseDice = false;
        target= false;
        targetSelected= false;
    }

    public void playAnim()
    {

        print("reproducir animacion");
        diceObject.SetActive(true);
        anim.SetTrigger("reset");
        anim.SetInteger("Dice", numDice);
    }
}
