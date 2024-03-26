using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using UnityEngine.Events;

public class progressBar : MonoBehaviour
{
    private Slider slider;
    private float maxHealth;
    private float curHealth;

    public float fillSpeed;
    public static int slider_count = 0;

    // Update is called once per frame
    void Update()
    {
        if (!slider || slider.value == 0)
        {
            Cursor.lockState = CursorLockMode.None;
            GameManager.player.GoToNextPoint();
            GameObject.FindGameObjectWithTag("ItemDisplay").SetActive(false);
            GameObject.FindGameObjectWithTag("GoblinDisplay").transform.localPosition = new Vector3(-750, -90, 0);
            GameObject.FindGameObjectWithTag("GoblinDisplay").SetActive(false);
            Destroy(this.transform.parent.parent.gameObject);
            return;
        }

        // Space bar near area
        if (slider.value > slider.minValue && Input.GetKeyDown(KeyCode.RightShift))
        {
            slider.value -= fillSpeed * Time.deltaTime;
        }
    }

    public void SetUpTheSlider()
    {
        slider = GetComponent<Slider>();
        Obstacle curRef = GameManager.player.GetCurrentObstacle();
        if (!curRef)
        {
            Debug.LogError("No object has been passed");
            return;
        }

        Cursor.lockState = CursorLockMode.Locked;
        float newFillSpeed = FindObjectOfType<ItemProbabilityDistributor>().GetSelectedItem().fillSpeed;
        BehaviorManager.Reset();
        fillSpeed = newFillSpeed;
        maxHealth = curRef.GetHealthValue();
        curHealth = maxHealth;
        slider.value = curHealth;
    }
}
