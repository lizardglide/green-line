using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpriteIdleAnim : MonoBehaviour
{
    [SerializeField]
    private float amplitude = 10f;
    [SerializeField]
    private float speed = 1f;

    float rand;
    float t;
    Vector3 orgVect3;
    // Start is called before the first frame update
    void Start()
    {
        rand = Random.Range(0f, 100f);
        orgVect3 = this.transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        this.transform.position = new Vector3(
            orgVect3.x,
            orgVect3.y + (Mathf.Sin(t + rand)/2f + 0.5f) * amplitude,
            orgVect3.z
        );
        t += Time.deltaTime * speed;
    }
}
