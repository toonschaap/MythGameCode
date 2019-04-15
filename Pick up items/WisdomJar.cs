using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WisdomJar : MonoBehaviour
{
    public AudioSource JarOpening;
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
            Finder.GetComponent<WisdomCounter>().IncreaseWisdomJar();
            JarOpening.Play();
            Destroy(this.gameObject);
        }
    }
}
