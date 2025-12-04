#region Using...

using DarkModeForms;
using System.ComponentModel;

#endregion

namespace EasyMultiVideoCompare
{
    public partial class FormSettings : Form
    {
        #region --- Variables ---

        BindingList<string> SearchFileTypes = new BindingList<string>();

        #endregion

        #region --- Constructor and FormClosing ---

        public FormSettings()
        {
            InitializeComponent();
            new DarkModeCS(this);
            DialogResult = DialogResult.Abort;
            LoadConfig();
            lb_FileTypes.DataSource = SearchFileTypes;
            CConfig.LoadWindow(this);
        }

        private void FormSettings_FormClosing(object sender, FormClosingEventArgs e)
        {
            CConfig.SaveWindow(this);
        }

        #endregion

        #region --- Save/Load Config ---

        private void LoadConfig()
        {
            SearchFileTypes.Clear();
            foreach (string type in CConfig.SearchFileTypes)
                SearchFileTypes.Add(type);

            cb_SearchRecursive.Checked = CConfig.SearchRecursive;
            cb_SaveAndLoadCompareHashesOnDisk.Checked = CConfig.SaveAndLoadCompareHashesOnDisk;

            nud_PreviewBitmapCount.Value = Math.Max(nud_PreviewBitmapCount.Minimum, Math.Min(nud_PreviewBitmapCount.Maximum, CConfig.PreviewBitmapCount));
            nud_PreviewBitmapSize.Value = Math.Max(nud_PreviewBitmapSize.Minimum, Math.Min(nud_PreviewBitmapSize.Maximum, CConfig.PreviewBitmapSize));

            nud_MaxHammingDistance.Value = Math.Max(nud_MaxHammingDistance.Minimum, Math.Min(nud_MaxHammingDistance.Maximum, (decimal)CConfig.MaxHammingDistance));
            nud_MinMatchRatio.Value = Math.Max(nud_MinMatchRatio.Minimum, Math.Min(nud_MinMatchRatio.Maximum, (decimal)CConfig.MinMatchRatio));

        }

        private void SaveConfig()
        {
            CConfig.SearchFileTypes.Clear();
            foreach (string type in SearchFileTypes)
                CConfig.SearchFileTypes.Add(type);

            CConfig.SearchRecursive = cb_SearchRecursive.Checked;
            CConfig.SaveAndLoadCompareHashesOnDisk = cb_SaveAndLoadCompareHashesOnDisk.Checked;

            CConfig.PreviewBitmapCount = (int)nud_PreviewBitmapCount.Value;
            CConfig.PreviewBitmapSize = (int)nud_PreviewBitmapSize.Value;

            CConfig.MaxHammingDistance = (int)nud_MaxHammingDistance.Value;
            CConfig.MinMatchRatio = (double)nud_MinMatchRatio.Value;
        }

        #endregion

        #region --- Button Events ---

        private void btn_Ok_Click(object sender, EventArgs e)
        {
            SaveConfig();
            DialogResult = DialogResult.OK;
            Close();
        }

        private void btn_Abort_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void btn_AddFileType_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrWhiteSpace(tb_AddFileType.Text)&& !SearchFileTypes.Contains(tb_AddFileType.Text))
                SearchFileTypes.Add(tb_AddFileType.Text);
            tb_AddFileType.Text = "";
        }

        private void btn_RemoveSelectedFileType_Click(object sender, EventArgs e)
        {
            if (lb_FileTypes.SelectedItems.Count <= 0)
                return;

            SearchFileTypes.RemoveAt(lb_FileTypes.SelectedIndex);
        }

        #endregion
    }
}
