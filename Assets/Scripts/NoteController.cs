using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.Events;
public class NoteController : MonoBehaviour
{
    [Header("Input")]
    [SerializeField] private KeyCode closeKey;

    [Space(10)]
    [SerializeField] private PlayerMovement player;

    [Header("UI Text")]
    [SerializeField] private GameObject noteCanvas;
    [SerializeField] private TMP_Text noteTextAreaUI;

    [Space(10)]
    [SerializeField] [TextArea] private string noteText;

    [Space(10)]
    [SerializeField] private UnityEvent openEvent;
    private bool isopen = false;

    public void ShowNote()
    {
        noteTextAreaUI.text = noteText;
        noteCanvas.SetActive(true);
        openEvent.Invoke();
        DisablePlayer(true);
        isopen = true;

    }

    void DisableNote()
    {
        noteCanvas.SetActive(false);
        noteTextAreaUI.text = null;
        DisablePlayer(false);
        isopen = false;
    }

    void DisablePlayer(bool disable)
    {
        player.enabled = !disable;

    }

    private void Update()
    {
        if (isopen)
        {
            if (Input.GetKeyDown(closeKey))
            {
                DisableNote();
            }
        }
    }
}
