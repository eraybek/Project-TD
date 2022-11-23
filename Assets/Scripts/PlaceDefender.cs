using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlaceDefender : MonoBehaviour
{
    public GameObject defenderPrefab;
    private GameObject defender;
    private Vector3 pos = new Vector2(-0.1f,0.25f);
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
    }
    
    private bool CanPlaceMonster()
    {
        print("Defender Null.");
        return defender == null;
    }
    
    void OnMouseUp()
    {
        //2
        if (CanPlaceMonster())
        {
            
            print("Instantiate Defender.");
            defender = Instantiate(defenderPrefab, transform.position - pos, Quaternion.identity);
            
            //AudioSource audioSource = gameObject.GetComponent<AudioSource>();
            //audioSource.PlayOneShot(audioSource.clip);

            // Gold'u Azalt !!
        }
    }
}
