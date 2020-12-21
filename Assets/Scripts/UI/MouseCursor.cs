using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class MouseCursor : MonoBehaviour
{
    void Start()
    {
        Cursor.visible = false;
    }
    void Update()
    {
        Vector2 cursorPos = Input.mousePosition;
        transform.position = cursorPos;
    }

    public GameObject hoveredOver;

    public GameObject infoBox;

    public TextMeshProUGUI infoText;

    public void StartCheck(GameObject go, float seconds, string tooltip)
    {
        if (go == hoveredOver) return;

        infoBox.SetActive(false);
        hoveredOver = go;

        StartCoroutine(ShowTooltip(go, seconds, tooltip));
    }

    public void CallEnd(GameObject go)
    {
        StartCoroutine(EndCheck(go));
    }

    public IEnumerator EndCheck(GameObject go)
    {
        yield return new WaitForSeconds(0.05f);

        if (go == hoveredOver)
        {
            infoBox.SetActive(false);
            hoveredOver = null;
        }
    }

    public IEnumerator ShowTooltip(GameObject go, float seconds, string tooltip)
    {
        yield return new WaitForSeconds(seconds);

        if (hoveredOver == go)
        {
            infoText.text = tooltip;
            infoBox.SetActive(true);
        }
    }
}
