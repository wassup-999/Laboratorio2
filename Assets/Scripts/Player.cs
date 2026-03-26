using System.Collections.Generic;
using UnityEngine;
using static UnityEngine.GraphicsBuffer;

//hacer consultas skillManager
public class Player : MonoBehaviour
{
    public Skill Target;
    public int Level;
    public int Money;    
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
            if (SkillManager.Instance.TryFindSkill(Target.SkillName, out Skill result))
            {
                Debug.Log("Skill found: " + result.SkillName);
            }
            else
            {
                Debug.Log("Skill not found: " + Target.SkillName);
            }
    }
    /*public void TryVerifyConditions(Skill Target)
    {
        
        if (SkillManager.Instance.VerifyConditions<bool>(this, Target))
        {
            Debug.Log("You can use this skill");
        }
        else
        {
            Debug.Log("You can't use this skill, check your level and money");
        }
    }*/
    
    public void LevelUpPlayer()
    {
        Level ++;
        Debug.Log("Player leveled up! Current level: " + Level);
        if(Level >= 10)
        {
            Level = 10;           
            Debug.Log("Player reached max level! Current level: " + Level );
        }
    }

}
