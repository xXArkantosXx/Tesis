using UnityEngine;
using System.Collections;
using System.IO;

public class IguanaUserController : MonoBehaviour
{
    IguanaCharacter iguanaCharacter;

    void Start()
    {
        iguanaCharacter = GetComponent<IguanaCharacter>();
    }

    //void Update () {	
    //    if (Input.GetButtonDown ("Fire1")) {
    //        iguanaCharacter.Attack();
    //    }

    //    if (Input.GetKeyDown (KeyCode.H)) {
    //        iguanaCharacter.Hit();
    //    }

    //    if (Input.GetKeyDown (KeyCode.E)) {
    //        iguanaCharacter.Eat();
    //    }

    //    if (Input.GetKeyDown (KeyCode.K)) {
    //        iguanaCharacter.Death();
    //    }

    //    if (Input.GetKeyDown (KeyCode.R)) {
    //        iguanaCharacter.Rebirth();
    //    }		



    //}

    bool eat = false;
    void Update()
    {
        if (eat)
        {
            Eat();
        }
        NoEat();
    }

    public void Eat()
    {
        eat = true;
        iguanaCharacter.Eat();
        Debug.Log("la iguana empieza a comer");
    }
    public void NoEat()
    {
        eat = false;
        Debug.Log("la iguana deja de comer");
    }


    //private void FixedUpdate()
    //{
    //    float h = Input.GetAxis ("Horizontal");
    //    float v = Input.GetAxis ("Vertical");
    //    iguanaCharacter.Move (v,h);
    //}
}
