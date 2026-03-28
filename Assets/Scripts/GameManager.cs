using UnityEngine;
using Wassup.Utils;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;
    public Player player;

    public void Awake()
    {
        if(Instance == null)
            Instance = this;
        else 
            Destroy(gameObject);
    }
    void Start()
    {
        int playerLife = GameUtils.Transform<Player, int>(player, z => z.Life);
        TestTakeDamage<Player>(player, Random.Range(5,15));      
    }

    
    void Update()
    {
        
    }
    public void TestTakeDamage<T>(T damageable, int damage) where T : IDamageable
    {
        damageable.TakeDamage(damage);
        int simpleReturn = SkillDescription(out _);
        //Debug.Log(simpleReturn);
    }
    public void BtnSelectSkill(Skill skill)
    {
        GameManager.Instance.player.Target = skill;      
        Debug.Log(skill.SkillName);
        
        int simpleReturn1 = SkillDescription(out string skillDescription);
        Debug.Log(skillDescription);      
    }

    public int SkillDescription(out string skillDescription)
    {
        skillDescription = "Skill Description :"+ " " + player.Target.SkillDescription;
        return 1;
    }
}
