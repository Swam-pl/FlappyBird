using System.Collections;
using System.Collections.Generic;
using System.Net;
using UnityEngine;

public class MoveController : MonoBehaviour
{
    public float speed;

    public float DespawnPointX;
    public float SpawnPointX;

    public float MinY;
    public float MaxY;

    // Start is called before the first frame update
    void Start()
    {
        transform.position = new Vector3(transform.position.x, Random.Range(MinY, MaxY), transform.position.z);
    }

    // Update is called once per frame
    void Update()
    {
        if (BirdController.GameOver || BirdController.HasStarted == false)
            return;
        transform.position = new Vector3(transform.position.x + speed * Time.deltaTime,
            transform.position.y, transform.position.z); //pozycja to wektor3?
        //Time.deltaTime - czas pomiêdzy ostatni¹ a obecn¹ klatk¹

        if (transform.position.x < DespawnPointX)
            transform.position = new Vector3(SpawnPointX, Random.Range(MinY, MaxY), transform.position.z);
    }
}
