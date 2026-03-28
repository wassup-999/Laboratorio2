using System.Collections.Generic;
using UnityEngine;
using static UnityEngine.GraphicsBuffer;

//hacer consultas skillManager
public class Player : MonoBehaviour , IDamageable
{
    public Skill Target;
    public int Level;
    public int Money;
    public int Life;
    public List<Skill> LearndSkills;
    
    void Start()
    {
        CheckNameAndCost(Target);       
        
    }

    public void CheckNameAndCost(Skill target)
    {
        if(target == null)
        {
            Debug.LogWarning("Target skill is null");
            return;
        }
        SkillManager.Instance.NameOfSkill(target);
        SkillManager.Instance.CostOfSkill(target);  
    }   
    public void TryToLearnSkill(Skill target)
    {
        if (SkillManager.Instance.TryLearnSkill(this, target, out Skill result))
        {
            if (LearndSkills.Contains(target))
            {
                Debug.Log("Ya has aprendido esta habilidad");
                return;
            }
            LearndSkills.Add(result);
            Debug.Log("Habilidad añadida");
        }
        else
        {
              
            Debug.Log("Cant learn or buy right now , requieres el nivel and cost : " + target.LevelRestriction + " - " + target.Cost);
        }
    }
    public void TryToFindSkill()
    {         
            Skill[] skillsArray = LearndSkills.ToArray();
            if (SkillManager.Instance.TryFindSkill(skillsArray, skill => skill.SkillName == Target.SkillName, out Skill result))
            {
                Debug.Log("Habilidad encontrada: " + result.SkillName);
            }
            else
            {
                Debug.Log("Habilidad no encontrada");
            }

    }
    public void TryVerifyConditions()
    {   
         if (SkillManager.Instance.VerifyConditions(this, Target, (sender, target) => target, out Skill result))
         {
            
            Debug.Log("Condiciones verificadas para la habilidad: " + result.SkillName);
                                      
         }
         else
         {
            
            Debug.Log("No se cumplen las condiciones para la habilidad: " + Target.SkillName);
         }
    }   
    public void LevelUpPlayer()
    {
        Level ++;
        Debug.Log("Player leveled up! Current level: " + Level);
        if(Level >= 10)
        {
            Level = 10;           
            Debug.Log("Player reached max level! " );
        }
    }
    public void EarMoney()
    {
        Money++;
        Debug.Log("Player ear money! Current money: " + Money);
        if(Money>= 10)
        {
            Money = 10;
            Debug.Log("Player reach max money!");
        }
    }

    public void TakeDamage(int damage)
    {
        damage = Random.Range(5, 15);
        Life -= damage;
        Debug.Log ("Recieve damage: " + damage + " " + "Current player life :" + Life);
    }
}
