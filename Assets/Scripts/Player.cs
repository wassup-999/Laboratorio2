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
        CheckName(Target);
        CheckCost(Target);        
    }




    public void CheckName(Skill target)
    {
        if(target == null)
        {
            Debug.LogWarning("Target skill is null");
            return;
        }
        SkillManager.Instance.NameOfSkill(target);

    }
    public void CheckCost(Skill target)
    {
        if(target == null)
        {
            Debug.LogWarning("Target Cost is null");
        }
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
    /*public void TryToBuySkill(Skill target)
    {
        if(SkillManager.Instance.TryBuySkill(this, target, out Skill result))
        {
            if (LearndSkills.Contains(target))
            {
                Debug.Log("Ya has comprado esta habilidad");
                return;
            }
            LearndSkills.Add(result);
            Debug.Log("Habilidad añadida");
        }
        else
        {
            Debug.Log("Cant buy right now , requieres el dinero : " + target.Cost);
        }
    }*/

}
