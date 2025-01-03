using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class ShootQueueDisplay : MonoBehaviour
{
    [SerializeField] private GameObject horizontalLayoutGroup;
    [SerializeField] private GameObject shootDisplayPrefab;
    [SerializeField] private List<Image> shootDisplayImage;
    

    public void UpdateShootQueue(List<Shoot> shootList)
    {
        shootDisplayImage.Clear();
        
        foreach (Transform child in horizontalLayoutGroup.transform)
        {
            shootDisplayImage.Add(child.GetComponent<Image>());
        }

        int amountToChange = shootList.Count - shootDisplayImage.Count;

        if (amountToChange < 0)
        {
            for (int i = 0; i < Math.Abs(amountToChange); i++)
            {
                Destroy(horizontalLayoutGroup.transform.GetChild(horizontalLayoutGroup.transform.childCount - 1).gameObject);
            }
        }

        if (amountToChange > 0)
        {
            for (int i = 0; i < amountToChange; i++)
            {
                Instantiate(shootDisplayPrefab, horizontalLayoutGroup.transform);
            }
        }

        shootDisplayImage.Clear();
        foreach (Transform child in horizontalLayoutGroup.transform)
        {
            shootDisplayImage.Add(child.GetComponent<Image>());
        }

        for (int i = 0; i < shootDisplayImage.Count; i++)
        {
            shootDisplayImage[i].sprite = shootList[i].GetComponent<SpriteRenderer>().sprite;
        }
}


    public void UpdateCurrentShoot(int currentIndex)
    {
        for(int i = 0; i < shootDisplayImage?.Count; i++)
        {
            if(i < currentIndex)
                shootDisplayImage[i].color = new Color(1, 1, 1, 0.1f);
            else
                shootDisplayImage[i].color = new Color(1, 1, 1, 1f);
        }
    }
    





}
