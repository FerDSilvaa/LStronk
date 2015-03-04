using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LeagueSharp;
using LeagueSharp.Common;
using SharpDX;

namespace StronkVladi_The_Blood_Sucker
{
    internal class CHLL : Program
    {

        public override void Game_OnGameUpdate(EventArgs args)
        {
           
            if (menu.Item("ComboActive").IsActive())
            {
                Combo();
            }

            if (menu.Item("HarassActive").IsActive())
            {
                Harass();
            }

            if (menu.Item("LC").IsActive())
            {
                LaneClear();
            }


            if (menu.Item("LH").IsActive())
            {
                LastHit();
            }


        }

            public void Combo()
            {
                Obj_AI_Hero Target = TargetSelector.GetTarget(450, TargetSelector.DamageType.Magical);
                if (Target == null) return;

                if (Target.IsValidTarget(Q.Range) && Q.IsReady() && Program.menu.Item("ComboActive").GetValue<KeyBind>().Active && Program.menu.Item("useQ").IsActive())

                { 
                Q.Cast(Target);
                }
                if (Target.IsValidTarget(E.Range) && E.IsReady() && Program.menu.Item("ComboActive").GetValue<KeyBind>().Active && Program.menu.Item("useE").IsActive())
                { 
                E.Cast();
                }
                if (R.IsReady() && Target.IsValidTarget() && R.GetDamage(Target) + E.GetDamage(Target) + Q.GetDamage(Target) >= Target.Health + Target.HPRegenRate && Program.menu.Item("ComboActive").GetValue<KeyBind>().Active && Program.menu.Item("useR").IsActive())
                {
                    R.Cast(Target.Position);
                }
                else
                    return;
            }
            public void Harass()
            {
                Obj_AI_Hero Target = TargetSelector.GetTarget(450, TargetSelector.DamageType.Magical);
                if (Target == null) return;

                if (Target.IsValidTarget(Q.Range) && Q.IsReady() && Program.menu.Item("HarassActive").GetValue<KeyBind>().Active && Program.menu.Item("harQ").IsActive())
                {
                    Q.Cast(Target);
                }

                if (Target.IsValidTarget(E.Range) && E.IsReady() && Program.menu.Item("HarassActive").GetValue<KeyBind>().Active && Program.menu.Item("harE").IsActive())
                {
                    E.Cast(Target);
                }
                else
                    return;
            

            }

            public void LaneClear()
            {                
                
                Obj_AI_Base minion = MinionManager.GetMinions(450).FirstOrDefault();
                if (minion == null) return;

                if (minion.IsValidTarget(Q.Range) && Q.GetDamage(minion) > minion.Health && Q.IsReady() && Program.menu.Item("LC").GetValue<KeyBind>().Active && Program.menu.Item("laneQ").IsActive())
                {
                    Q.Cast(minion);
                }

                if (minion.IsValidTarget(E.Range) && E.IsReady() && Program.menu.Item("LC").GetValue<KeyBind>().Active && Program.menu.Item("laneE").IsActive())
                {
                    E.Cast(minion);
                }
                else
                    return;
            }




             public void LastHit()
             {
                Obj_AI_Base minion = MinionManager.GetMinions(450).FirstOrDefault();
                if (minion == null) return;

                if (minion.IsValidTarget(Q.Range) && Q.GetDamage(minion) > minion.Health && Q.IsReady() && Program.menu.Item("LH").GetValue<KeyBind>().Active && Program.menu.Item("lastQ").IsActive())
                {
                    Q.Cast(minion);
                }
                else
                    return;
             }

             


         }
    
      
    
       
    
    
}
