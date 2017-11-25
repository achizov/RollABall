using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rotate : MonoBehaviour {
  private const int Y_MIN = 1;
  private const int Y_MAX = 5;


  private bool isUp = true;

  public void Start() {
    Vector3 rotate = new Vector3(
      Random.Range(0, 180),
      Random.Range(0, 180),
      Random.Range(0, 180)
      );

    Vector3 position = new Vector3(
      Random.Range(-9, 9),
      Random.Range(Y_MIN, Y_MAX),
      Random.Range(-9, 9)
      );

    transform.position = position;
    transform.Rotate(rotate);
  }

  void Update () {
    transform.Rotate(new Vector3(15f, 30f, 45f) * Time.deltaTime);

    Vector3 vec = transform.position;

    if (isUp) {
      vec.y += Time.deltaTime;
    } else {
      vec.y -= Time.deltaTime;
    }

    transform.position = vec;

    if(transform.position.y > Y_MAX) {
      isUp = false;
    }
    if(transform.position.y < Y_MIN) {
      isUp = true;
    }
  }
}