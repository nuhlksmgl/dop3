using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Raycast : MonoBehaviour
{
    [Header("Raycast Features")]
    public float rayLenght = 5;
    public Camera _camera;

    public NoteController _noteController;


    public Image crosshair;


    public KeyCode interactKey;

    void Start()
    {
        _camera = GetComponent<Camera>();
    }

    private void Update()
    {
        if (Physics.Raycast(_camera.ViewportToWorldPoint(new Vector3(0.5f, 0.5f)), transform.forward, out RaycastHit hit, rayLenght))
        {
            var readableItem = hit.collider.GetComponent<NoteController>();
            if (readableItem != null)
            {
                _noteController = readableItem;
                HighlightCrosshair(true);
            }
            else
            {
                ClearNote();
            }

        }

        else
        {
            ClearNote();
        }

        if (_noteController != null)
        {
            if (Input.GetKeyDown(interactKey))
            {
                _noteController.ShowNote();
            }
        }
    }

    void ClearNote()
    {
        if (_noteController != null)
        {
            HighlightCrosshair(false);
            _noteController = null;
        }
    }

    void HighlightCrosshair(bool on)
    {
        if (on)
        {
            crosshair.color = Color.red;
        }
        else
        {
            crosshair.color = Color.white;

        }
    }
}
