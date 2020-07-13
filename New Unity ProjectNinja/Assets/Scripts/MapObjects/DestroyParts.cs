using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyParts : MonoBehaviour
{
    Rigidbody2D rb;
    //in what direction and with what force the fragment will move
    [SerializeField]
    Vector2 Forcedir;

    [SerializeField]
    int spin;
    // Start is called before the first frame update
    void Start()
    {
        rb = gameObject.GetComponent<Rigidbody2D>();
        rb.AddForce(Forcedir);
        rb.AddTorque(spin);
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
