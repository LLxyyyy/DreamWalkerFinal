using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SkillManager : MonoBehaviour
{
    public void UseSkill(Character caster, Skill skill, Character target = null)
    {
        // ��鼼���Ƿ����
        if (!IsSkillAvailable(caster, skill))
        {
            return;
        }

        // ���ļ�����Դ
        ConsumeSkillResource(caster, skill);

        // ���ż��ܶ���
        PlaySkillAnimation(caster, skill);

        // ������Ч��
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
        // ��鼼���Ƿ�����ȴ��
        // ��鼼���Ƿ����㹻����Դ
        // ...

        return true;
    }

    private void ConsumeSkillResource(Character caster, Skill skill)
    {
        // ���ļ�����Դ
        // ...
    }

    private void PlaySkillAnimation(Character caster, Skill skill)
    {
        // ���ż��ܶ���
        // ...
    }

    private void ProcessTargetedSkillEffect(Character caster, Skill skill, Character target)
    {
        // ����ָ���Լ���Ч��
        // ...
    }

    private void ProcessUntargetedSkillEffect(Character caster, Skill skill)
    {
        // �����ָ���Լ���Ч��
        // ...
    }
}