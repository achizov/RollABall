using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour {

  public GameObject playerBall;

  private Vector3 _offset;

  public void Start () {
    _offset = transform.position - playerBall.transform.position;
  }

  public void LateUpdate() {
    transform.position = playerBall.transform.position + _offset;
  }
}
