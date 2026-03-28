using System;
using System.Collections.Generic;
using NUnit.Framework;
using UnityEngine;
//trabajar las consultas del player
public class SkillManager : MonoBehaviour
{
    
    public static SkillManager Instance;

    [SerializeField] List<Skill> skillList;
    private void Awake()
    {
        if(Instance == null)
            Instance = this;
        else 
            Destroy(gameObject);
    }
    public void NameOfSkill<T>(T skill) where T : Skill // funcion generica
    {
        Debug.Log(skill.SkillName);
    }
    public void CostOfSkill<T>(T skill) where T : Skill
    {
        Debug.Log(skill.Cost);
    }
    public bool VerifyConditions<T>(Player sender,T target,Func<Player, T, bool> condition,out T result) where T : Skill
    {
        if (condition(sender, target) && sender.Level >= target.LevelRestriction && sender.Money >= target.Cost)
        {
            result = target;
            return true;
        }
        else
        {
            result = default;
            return false;
        }
    }
    
    public bool TryLearnSkill<T>(Player sender, T target, out T Result) where T : Skill //-> funcion generica / out retornar más de 1 cosa
    {
        if (sender.Level >= target.LevelRestriction && sender.Money >= target.Cost)
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
    public bool TryFindSkill<T>(T[] arraynames, Func<T ,bool> condition, out T result)
    {
        foreach (var item in arraynames)
        {
            if (condition(item))
            {
                result = item;
                return true;
            }
        }
        result = default;
        return false;
    }  
}
