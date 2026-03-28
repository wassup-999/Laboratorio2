using NUnit.Framework.Internal;
using System;
using System.Diagnostics;
using UnityEngine;
namespace Wassup.Utils
{
    public class GameUtils
    {
        public static TResult Transform<T , TResult>(T element , Func<T , TResult> func)
        {
              return func(element);
        }
        /*public static TResult CoolDownQuantity<T , TResult>(T skill, Func<T,TResult> cooldown  ) where T : Skill
        {
            return cooldown(skill);
           
        }*/
    }      
}
