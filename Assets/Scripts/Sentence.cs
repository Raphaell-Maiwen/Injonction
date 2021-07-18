using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sentence : MonoBehaviour
{
    public float minSpeed;
    public float maxSpeed;

    float timer = 0f;
    float percent = 0f;
    float speed;
    Vector3 startingPos;
    Vector3 endingPos;
    Vector3 difference;

    public List<Color> colors;
    public GameObject mesh;

    void Awake()
    {
        speed = Random.Range(minSpeed, maxSpeed);

        //TODO: Randomize startingPos + adjust angle
        startingPos = this.gameObject.transform.position;
        endingPos = startingPos + this.gameObject.transform.forward * 30f;

        difference = endingPos - startingPos;
        mesh.GetComponent<Renderer>().material.color = colors[(int)Random.Range(0, colors.Count-1)];
    }

    void Update() {
        timer += Time.deltaTime;
        percent = timer / speed;

        this.transform.position = startingPos + difference * percent;

        if (percent >= 1) Debug.Log(100 + "!!!");
    }

    private void OnTriggerEnter(Collider other) {
        if (other.tag == "Player") RestartPath();

    }

    void RestartPath() {
        Debug.Log("Restart");
        this.transform.position = startingPos;
        timer = 0f;
        percent = 0f;
    }
}
