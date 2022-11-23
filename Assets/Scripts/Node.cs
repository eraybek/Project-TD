using System;
using UnityEngine;
using UnityEngine.EventSystems;

public class Node : MonoBehaviour
{
   public Color hoverColor;
   public Color notEnoughMoneyColor;

   [Header("Optional")]
   public GameObject defender;
   
   private Renderer rend;
   private Color startColor;

   private Vector3 pos = new Vector2(-0.1f,0.25f);

   BuildManager buildManager;

   public AudioSource _audio;
   private void Start()
   {
      rend = GetComponent<Renderer>();
      startColor = rend.material.color;
      buildManager = BuildManager.instance;
   }

   public Vector3 GetBuildPosition()
   {
      return transform.position;
   }
   

   private void OnMouseDown()
   {
      _audio.Play();
      if (EventSystem.current.IsPointerOverGameObject())
         return;
      
      if (!buildManager.CanBuild) 
         return;
      
      if (defender != null)
      {
         Debug.Log("Can't build there! - TODO: Display on screen");
         return;
      }

      buildManager.BuildDefenderOn(this);

   }

   private void OnMouseEnter()
   {
      if (EventSystem.current.IsPointerOverGameObject())
         return;
      
      if (!buildManager.CanBuild) 
         return;
      
      if (buildManager.HasMoney)
      {
         rend.material.color = hoverColor;
         
      } else
      {
         rend.material.color = notEnoughMoneyColor;
      }
      
   }

   private void OnMouseExit()
   {
      rend.material.color = startColor;
   }
}
