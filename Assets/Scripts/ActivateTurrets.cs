using System.Collections.Generic;
using UnityEngine;

public class ActivateTurrets : MonoBehaviour
{
    public TurretSpecs noTurret, lvl1Tur, lvl2Tur, lvl3Tur, lvl4Tur;
    public TurretSpecs currentTurret;
    public List<TurretSpecs> turrets;

    private void Start()
    {
        turrets.Add(lvl1Tur);
        turrets.Add(lvl2Tur);
        turrets.Add(lvl3Tur);
        turrets.Add(lvl4Tur);
    }

    private void Update()
    {
        ActivateTurret();
    }

    void ActivateTurret()
    {
        if (currentTurret == null)
        {
            return;
        }
        else
        {
            if (currentTurret.type != 0f)
            {
                turrets[currentTurret.type - 1].turret.SetActive(true);
            }
            else
            {
                foreach (TurretSpecs turret in turrets)
                {
                    if (turret.turret.activeInHierarchy)
                        turret.turret.SetActive(false);
                }
            }
        }
    }
}
