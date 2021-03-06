﻿using System.Collections;
using System.Collections.Generic;
using System.Text;
using UnityEngine;

namespace ELGame
{
    public class BattleTeam
    {
        public int teamID;
        public List<BattleUnit> battleUnits = new List<BattleUnit>();

        //添加战斗单位
        public void AddBattleUnit(BattleUnit battleUnit)
        {
            if (battleUnit == null)
                return;
            
            if (battleUnit.battleTeam != null)
            {
                //重复加入
                if (battleUnit.battleTeam.Equals(this))
                    return;

                UtilityHelper.LogError("Add battle unit failed.Battle unit already joined a team.");
                return;
            }

            //重复添加
            if (battleUnits.Contains(battleUnit))
                return;

            //加入
            battleUnits.Add(battleUnit);
            battleUnit.battleTeam = this;
        }

        //移除战斗单位
        public void RemoveBattleUnit(BattleUnit battleUnit)
        {
            if (battleUnit.battleTeam == null || !battleUnit.battleTeam.Equals(this))
            {
                UtilityHelper.LogError("Remove battle unit failed.");
                return;
            }

            battleUnits.Remove(battleUnit);
            battleUnit.battleTeam = null;
        }
        
        public override bool Equals(object obj)
        {
            if (obj != null && obj is BattleTeam) 
            {
                return teamID == ((BattleTeam)obj).teamID;
            }
            return false;
        }

        public string Desc()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendFormat("Team id = {0}\n", teamID);
            for (int i = 0; i < battleUnits.Count; ++i)
            {
                sb.AppendFormat(" {0}\n", battleUnits[i].Desc());
            }
            return sb.ToString();
        }
    }
}