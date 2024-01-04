using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SkillManager : MonoBehaviour
{
    public void UseSkill(Character caster, Skill skill, Character target = null)
    {
        // 检查技能是否可用
        if (!IsSkillAvailable(caster, skill))
        {
            return;
        }

        // 消耗技能资源
        ConsumeSkillResource(caster, skill);

        // 播放技能动画
        PlaySkillAnimation(caster, skill);

        // 处理技能效果
        if (skill.isTargeted)
        {
            ProcessTargetedSkillEffect(caster, skill, target);
        }
        else
        {
            ProcessUntargetedSkillEffect(caster, skill);
        }
    }

    private bool IsSkillAvailable(Character caster, Skill skill)
    {
        // 检查技能是否处于冷却中
        // 检查技能是否有足够的资源
        // ...

        return true;
    }

    private void ConsumeSkillResource(Character caster, Skill skill)
    {
        // 消耗技能资源
        // ...
    }

    private void PlaySkillAnimation(Character caster, Skill skill)
    {
        // 播放技能动画
        // ...
    }

    private void ProcessTargetedSkillEffect(Character caster, Skill skill, Character target)
    {
        // 处理指向性技能效果
        // ...
    }

    private void ProcessUntargetedSkillEffect(Character caster, Skill skill)
    {
        // 处理非指向性技能效果
        // ...
    }
}