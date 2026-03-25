using System;
using System.Collections.Generic;
using NUnit.Framework;
using UnityEngine;
//trabajar las consultas del player
public class SkillManager : MonoBehaviour
{
    private void Awake()
    {
        if(Instance == null)
            Instance = this;
        else 
            Destroy(gameObject);
    }
    public static SkillManager Instance;

    [SerializeField] List<Skill> skillList;

    public void NameOfSkill<T>(T skill) where T : Skill // funcion generica
    {
        Debug.Log(skill.SkillName);
    }
    public void CostOfSkill<T>(T skill) where T : Skill
    {
        Debug.Log(skill.Cost);
    }


    //public bool VerifyCondition<T>(Player sender , T target , Func< T , bool> )

    public bool TryLearnSkill<T>(Player sender, T target, out T Result) where T : Skill //-> funcion generica / out retornar más de 1 cosa
    {
        if (sender.Level >= target.LevelRestriction)
        {
            Result = target;
            return true;

        }
        
        else
        {
            Result = default;
            return false;
        }
            
    }
    public bool TryBuySkill<T>(Player sender, T target, out T Result) where T : Skill
    {
        if(sender.Money >= target.Cost)
        {
            Result = target;
            return true;
        }
        else
        {
            Result = default;
            return false;
        }
    }
    
}
