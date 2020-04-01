using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EpicEvents
{
    //"anim_name", "animation@dictionary@name"
    public static class Animation
    {
        private static Random m_Random = new Random();

        private static AnimationType[] m_LookOutAnimations = new AnimationType[]
        {
            new AnimationType("_car_b_lookout", "random@street_race"),
            new AnimationType("rcmme_amanda1_stand_loop_cop", "anim@amb@nightclub@peds@"),
            new AnimationType("base","amb@code_human_police_investigate@base"),
            new AnimationType("idle_a","amb@code_human_police_investigate@idle_a"),
            new AnimationType("base","amb@world_human_drug_dealer_hard@male@base")
        };

        public static AnimationType GetRandomLookOutAnimation()
        {
            return m_LookOutAnimations[m_Random.Next(0, m_LookOutAnimations.Length)];
        }

        private static AnimationType[] m_IdleAnimations = new AnimationType[]
        {
            new AnimationType("idle_a", "amb@world_human_drug_dealer_hard@male@idle_a"),
            new AnimationType("idle_b", "amb@world_human_drug_dealer_hard@male@idle_a"),
            new AnimationType("idle_c", "amb@world_human_drug_dealer_hard@male@idle_a")
        };

        public static AnimationType GetRandomIdleAnimation()
        {
            return m_IdleAnimations[m_Random.Next(0, m_IdleAnimations.Length)];
        }

         /* private static AnimationType[] m_IdleAnimations = new AnimationType[]
        {
            new AnimationType("", ""),
            new AnimationType("", ""),
            new AnimationType("",""),
            new AnimationType("",""),
            new AnimationType("","")
        };*/
    }

    public struct AnimationType
    {
        public string Animation;
        public string Dictionary;

        public AnimationType(string animation, string dictionary)
        {
            Animation = animation;
            Dictionary = dictionary;
        }
    }
}
