using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WisdomPickUp : MonoBehaviour
{
    public AudioSource bottleOpening;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            GameObject Finder = GameObject.FindWithTag("Player");
            Finder.GetComponent<WisdomCounter>().IncreaseWisdomBottle();
            bottleOpening.Play();

            Destroy(this.gameObject);
        }
    }
}
