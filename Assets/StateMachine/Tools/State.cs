﻿namespace Anderson.Tools
{
    public class State
    {
        private int m_StateId;
        private EnterState m_Enter;
        private UpdateState m_Update;
        private ExitState m_Exit;
        private bool m_SkipFirstUpdate;
        private bool m_FirstUpdateSkipped;

        public State(int aId, EnterState aEnter, UpdateState aUpdate, ExitState aExit, bool aSkipFirstUpdate)
        {
            m_StateId = aId;
            m_Enter = aEnter;
            m_Update = aUpdate;
            m_Exit = aExit;
            m_SkipFirstUpdate = true;
        }

        public int GetStateId()
        {
            return m_StateId;
        }

        public void Enter()
        {
            if (m_Enter != null)
            {
                m_Enter();
            }
        }

        public void Update()
        {
            if(m_SkipFirstUpdate && !m_FirstUpdateSkipped)
            {
                m_FirstUpdateSkipped = true;
                return;
            }

            if (m_Update != null)
            {
                m_Update();
            }
        }

        public void Exit()
        {
            if (m_Exit != null)
            {
                m_Exit();
            }
        }

    }
}