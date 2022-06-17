using UnityEngine;
using UnityEngine.UI;

public class SwitchWeapon : MonoBehaviour
{
    public int selectedWeapon = 0;
    public Image machinegun;

    // Start is called before the first frame update
    void Start()
    {
        SelectWeapon();
        machinegun.enabled = true;
    }

    // Update is called once per frame
    void Update()
    {
        if (Time.timeScale == 1)
        {
            int previousSelectedWeapon = selectedWeapon;

            if (Input.GetAxis("ScrollWheel") > 0f)
            {
                if (selectedWeapon >= transform.childCount - 1)
                {
                    selectedWeapon = 0;
                    machinegun.enabled = false;
                }
                else
                {
                    selectedWeapon++;
                    machinegun.enabled = true;
                }
            }

            if (Input.GetAxis("ScrollWheel") < 0f)
            {
                if (selectedWeapon <= 0)
                {
                    selectedWeapon = transform.childCount - 1;
                    machinegun.enabled = true;
                }
                else
                {
                    selectedWeapon--;
                    machinegun.enabled = false;
                }
            }

            if (Input.GetKeyDown(KeyCode.Alpha1))
            {
                selectedWeapon = 0;
                machinegun.enabled = true;
            }

            if (Input.GetKeyDown(KeyCode.Alpha2) && transform.childCount >= 2)
            {
                selectedWeapon = 1;
            }

            if (Input.GetKeyDown(KeyCode.Alpha3) && transform.childCount >= 3)
            {
                selectedWeapon = 2;
            }

            if (Input.GetKeyDown(KeyCode.Alpha4) && transform.childCount >= 4)
            {
                selectedWeapon = 3;
            }

            if (previousSelectedWeapon != selectedWeapon)
            {
                SelectWeapon();
            }
        }
    }

    void SelectWeapon()
    {
        int i = 0;
        foreach (Transform weapon in transform)
        {
            if(i == selectedWeapon)
            {
                weapon.gameObject.SetActive(true);
            }
            else
            {
                weapon.gameObject.SetActive(false);
            }
            i++;
        }
    }
}
