using System.Collections.Generic;
using System.Media;

namespace FileWatcher
{
    internal class PalyWave
    {
        private PalyWave()
        {
        }

        private static PalyWave instance;

        public static PalyWave Instance
        {
            get { return instance ?? (instance = new PalyWave()); }
        }

        public List<PalyWave> list = new List<PalyWave>();

        public void Add()
        {
            list.Add(this);
        }

        public void Remove()
        {
            list.Remove(this);
        }

        private SoundPlayer player = new SoundPlayer();//C#������

        //-------------------------------------------------------------------
        /// <summary>
        /// ��������
        /// </summary>
        /// <param name="wfname">�����ļ�</param>
        public void Play(string wfname)//ֻ����һ��
        {
            player.SoundLocation = wfname;//ָ�������ļ�
            player.Load();//ͬ��
            player.Play();
            player.LoadCompleted += player_LoadCompleted;
        }

        private void player_LoadCompleted(object sender, System.ComponentModel.AsyncCompletedEventArgs e)
        {
            //System.Windows.Forms.MessageBox.Show("Test");
        }

        /// <summary>
        /// ѭ����������
        /// </summary>
        /// <param name="wfname">�����ļ�</param>
        public void RedoPlay(string wfname)//ѭ������
        {
            player.SoundLocation = wfname;//ָ�������ļ�

            player.Load();//ͬ��
            player.PlayLooping();//��ʼ����
        }

        //--------------------------------------------------------------------
        /// <summary>
        /// ֹͣ����
        /// </summary>
        public void StopPlay()
        {
            player.Stop();
        }
    }
}