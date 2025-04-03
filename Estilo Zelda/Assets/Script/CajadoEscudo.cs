using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro; 
public class CajadoEscudo : MonoBehaviour,IItem

{
    [SerializeField]  Sprite cajadoIcon;
    [SerializeField]  Sprite cajadoIconCooldown; 
    [SerializeField]  GameObject barreiraPrefab;
    [SerializeField]  float duracaoEscudo = 4f;
    [SerializeField]  float cooldown = 5f;

     bool emCooldown = false;
     GameObject barreiraAtiva;
     Inventario inventario;

     float cooldownTimer = 0f;

    void Start()
    {
        inventario = FindObjectOfType<Inventario>();
    }

    public GameObject GetGameObject()
    {
        return gameObject;
    }

    public Sprite GetIcon()
    {
        return cajadoIcon;
    }

    public bool PodeUsar()
    {
        return !emCooldown;
    }

    public IEnumerator AtivarEscudo(Transform player)
    {
        if (emCooldown) yield break;

        emCooldown = true;
        cooldownTimer = cooldown;

        if (inventario != null)
        {
            inventario.AtualizarIconeCajado(cajadoIconCooldown);
        }

        barreiraAtiva = Instantiate(barreiraPrefab, player.position, Quaternion.identity, player);

        PlayerStatus status = player.GetComponent<PlayerStatus>();
        if (status != null)
        {
            status.SetInvulneravel(true);
        }

        yield return new WaitForSeconds(duracaoEscudo);

        if (barreiraAtiva != null)
        {
            Destroy(barreiraAtiva);
        }

        if (status != null)
        {
            status.SetInvulneravel(false);
        }

        yield return new WaitForSeconds(cooldown);

        if (inventario != null)
        {
            inventario.AtualizarIconeCajado(cajadoIcon);
        }

        emCooldown = false;
    }
}