using System.Collections.Generic;
using NUnit.Framework;
using UnityEngine;
//trabajar las consultas del player
public class SkillManager : MonoBehaviour
{
    public static SkillManager Instance;

    [SerializeField] List<Skill> skillList;
    
    public void NameOfSkill<T>(T skill) where T : Skill // funcion generica
    {
        Debug.Log(skill.SkillName);
    }



    //    public bool TryLearnSkill<T , TResult>(Player sender, T target, out T Result) where T : Skill //-> funcion generica / out retornar más de 1 cosa

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
    private void Awake()
    {
        if(Instance == null)
            Instance = this;
        else 
            Destroy(gameObject);
    }
}
