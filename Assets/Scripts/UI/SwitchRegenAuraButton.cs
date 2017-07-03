using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SwitchRegenAuraButton : MonoBehaviour {
    public Creature Creature;
    public float RegenPerSecond;
    HealthRegenAura regenAura;
    HealthRegenAura RegenAura
    {
        get
        {
            if (regenAura == null)
            {
                regenAura = new HealthRegenAura(Creature, Creature, RegenPerSecond);
            }
            return regenAura;
        }
        set
        {
            regenAura = value;
        }
    }
    bool turnedOn;
    public Text buttonText;
    Button button;
    private void Start()
    {
        turnedOn = false;
        button = GetComponent<Button>();
        SetButtonColor(Color.red);
    }
    public void OnClick()
    {
        turnedOn = !turnedOn;
        if (turnedOn)
        {
            RegenAura.AttachTo(Creature);
            Debug.Log("Regen aura (" + RegenPerSecond + ") active!");
        }
        else
        {
            RemoveAura();
        }
        buttonText.text = "HP Regen " + (turnedOn ? "[ON]" : "[OFF]");
        SetButtonColor(turnedOn ? Color.green : Color.red);
    }
    void RemoveAura()
    {
        if (regenAura != null)
        {
            RegenAura.Destroy();
            Debug.Log("Regen aura (" + RegenPerSecond + ") inactive.");
        }
    }
    void SetButtonColor(Color c)
    {
        ColorBlock colorBlock = button.colors;
        colorBlock.normalColor = c;
        button.colors = colorBlock;
    }
}
