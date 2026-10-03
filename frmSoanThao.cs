namespace Lab03_02
{
    public partial class frmSoanThao : Form
    {
        public frmSoanThao()
        {
            InitializeComponent();
            foreach (FontFamily font in FontFamily.Families)
            {
                cboFont.Items.Add(font.Name);
            }

            // Thêm danh sách cỡ chữ
            int[] sizes = { 8, 9, 10, 11, 12, 14, 16, 18, 20, 24, 28, 36, 48, 72 };

            foreach (int size in sizes)
            {
                cboSize.Items.Add(size);
            }

            // Giá trị mặc định
            cboFont.Text = "Tahoma";
            cboSize.Text = "14";
        }

        private void toolStripLabel1_Click(object sender, EventArgs e)
        {

        }

       

        private void statusStrip1_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {

        }

        private void toolStripStatusLabel1_Click(object sender, EventArgs e)
        {

        }

        private void New_Click(object sender, EventArgs e)
        {
            richTextBox1.Clear();
            richTextBox1.Focus();
        }

        private void Save_Click(object sender, EventArgs e)
        {
            SaveFileDialog save = new SaveFileDialog();

            save.Filter = "Rich Text File (*.rtf)|*.rtf|Text File (*.txt)|*.txt";
            save.Title = "Lưu văn bản";

            if (save.ShowDialog() == DialogResult.OK)
            {
                if (Path.GetExtension(save.FileName).ToLower() == ".rtf")
                    richTextBox1.SaveFile(save.FileName);
                else
                    File.WriteAllText(save.FileName, richTextBox1.Text);
            }
        }

        private void mởTậpTinToolStripMenuItem_Click(object sender, EventArgs e)
        {
            OpenFileDialog open = new OpenFileDialog();

            open.Filter = "Rich Text File (*.rtf)|*.rtf|Text File (*.txt)|*.txt";

            if (open.ShowDialog() == DialogResult.OK)
            {
                if (Path.GetExtension(open.FileName).ToLower() == ".rtf")
                {
                    richTextBox1.LoadFile(open.FileName);
                }
                else
                {
                    richTextBox1.Text = File.ReadAllText(open.FileName);
                }
            }
        }

        private void thoátToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Close();
        }


        private void tạoVănBảnMới_Click(object sender, EventArgs e)
        {
            New_Click(sender, e);
        }

        private void lưuNộiDungVănBảnToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Save_Click(sender, e);
        }

        private void địnhDạngToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FontDialog fontDlg = new FontDialog();

            fontDlg.ShowColor = true;
            fontDlg.ShowApply = true;
            fontDlg.ShowEffects = true;
            fontDlg.ShowHelp = true;

            if (fontDlg.ShowDialog() != DialogResult.Cancel)
            {
                richTextBox1.ForeColor = fontDlg.Color;
                richTextBox1.Font = fontDlg.Font;
            }
        }
            
        

        private void toolStripButton1_Click(object sender, EventArgs e)
        {
            if (richTextBox1.SelectionFont != null)
            {
                FontStyle style = richTextBox1.SelectionFont.Style;

                if (richTextBox1.SelectionFont.Bold)
                    style &= ~FontStyle.Bold;
                else
                    style |= FontStyle.Bold;

                richTextBox1.SelectionFont =
                    new Font(richTextBox1.SelectionFont, style);
            }
        }

        private void cboFont_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cboFont.SelectedItem != null)
            {
                float size = richTextBox1.SelectionFont?.Size ?? 14;

                richTextBox1.SelectionFont = new Font(
                    cboFont.SelectedItem.ToString(),
                    size
                );
            }
        }

        private void cboSize_SelectedIndexChanged(object sender, EventArgs e)
        {

            if (cboSize.SelectedItem != null)
            {
                float size = Convert.ToSingle(cboSize.SelectedItem);

                FontFamily fontFamily =
                    richTextBox1.SelectionFont?.FontFamily
                    ?? new FontFamily("Tahoma");

                richTextBox1.SelectionFont = new Font(fontFamily, size);
            }
        }

        private void toolStripButton2_Click(object sender, EventArgs e)
        {
            if (richTextBox1.SelectionFont != null)
            {
                FontStyle style = richTextBox1.SelectionFont.Style;

                if (richTextBox1.SelectionFont.Italic)
                    style &= ~FontStyle.Italic;
                else
                    style |= FontStyle.Italic;

                richTextBox1.SelectionFont =
                    new Font(richTextBox1.SelectionFont, style);
            }
        }

        private void toolStripButton3_Click(object sender, EventArgs e)
        {

            if (richTextBox1.SelectionFont != null)
            {
                FontStyle style = richTextBox1.SelectionFont.Style;

                if (richTextBox1.SelectionFont.Underline)
                    style &= ~FontStyle.Underline;
                else
                    style |= FontStyle.Underline;

                richTextBox1.SelectionFont =
                    new Font(richTextBox1.SelectionFont, style);
            }
        }

        private void richTextBox1_TextChanged_1(object sender, EventArgs e)
        {
            string text = richTextBox1.Text.Trim();

            int soTu = string.IsNullOrWhiteSpace(text)
                ? 0
                : text.Split(
                    new char[] { ' ', '\n', '\t' },
                    StringSplitOptions.RemoveEmptyEntries
                  ).Length;

            // Đưa kết quả xuống chỗ "Tổng số từ"
            toolStripStatusLabel1.Text = "Tổng số từ: " + soTu;
        }
    }
}
