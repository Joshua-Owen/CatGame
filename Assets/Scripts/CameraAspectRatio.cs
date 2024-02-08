using System.Collections;
using System.Collections.Generic;
using System.Numerics;
using UnityEngine;
using UnityEngine.InputSystem;
public class CameraAspectRatio : MonoBehaviour
{
    public GameObject image;
    
    /// <summary>
    /// Update is called every frame, if the MonoBehaviour is enabled.
    /// </summary>
  /// <summary>
  /// Start is called on the frame when a script is enabled just before
  /// any of the Update methods is called the first time.
  /// </summary>
  private void Start()
  {
    
  }

    public void ChangeRatio(InputAction.CallbackContext ctx)
    {
        transform.position = new UnityEngine.Vector3(0f, 0f, -10);
        float spriteWidth = image.transform.localScale.x; // Width of the sprite
        float spriteHeight = image.transform.localScale.y; // Height of the sprite
        float spriteAspect = spriteWidth / spriteHeight;

        Camera.main.aspect = -spriteAspect;
    }
}
