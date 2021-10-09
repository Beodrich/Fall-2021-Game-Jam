using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PizzaHealth : MonoBehaviour
{
    public Image pizzaImage;
    public List<Sprite> pizzaSprites;
    public int pizzaSlices;
    private Vector3 startingPosition;
    public float shakingMagnitude;
    public float shakingTime;
    private float shakingTimeLeft;

    void Start()
    {
        startingPosition = transform.position;
        shakingTimeLeft = 5f;
    }

    // Update is called once per frame
    void Update()
    {
        if (shakingTimeLeft > 0)
        {
            transform.position = startingPosition + new Vector3(Random.Range(-shakingMagnitude, shakingMagnitude), Random.Range(-shakingMagnitude, shakingMagnitude), 0);
            shakingTimeLeft -= Time.deltaTime;
        }
        else
        {
            transform.position = startingPosition;
        }
    }

    public void RemovePizzaSlices(int value)
    {
        shakingTimeLeft = shakingTime;
        pizzaSlices -= value;
        pizzaImage.sprite = pizzaSprites[pizzaSlices];
    }


}
