using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TargetComponent : MonoBehaviour
{

    public void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Projectile"))
        {
            GameManager.Instance.IncrementScore();

            // Hide target after 5 seconds
            Invoke("HideTarget", 5f);
            Renderer parentRenderer = transform.parent.GetComponent<Renderer>();
            if (parentRenderer != null)
            {
                parentRenderer.material.color = Color.green;
                Invoke("ChangeColorBack", 5f); // Change color back after 5 seconds
            }
        }
    }

    void HideTarget()
    {
        gameObject.SetActive(false);
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    void ChangeColorBack()
    {
        Renderer parentRenderer = transform.parent.GetComponent<Renderer>();
        if (parentRenderer != null)
        {
            parentRenderer.material.color = Color.red;
        }
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
