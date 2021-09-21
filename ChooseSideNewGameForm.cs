using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Warcaby
{
    public partial class ChooseSideNewGameForm : Form
    {
        public string Color;
        public string DifficultyLevel;
        public bool wasButtonClicked;
        public ChooseSideNewGameForm()
        {
            InitializeComponent();
            wasButtonClicked = false;
        }

        private void richTextBox1_TextChanged(object sender, EventArgs e)
        {

        }
        
        public void btnStartNewGame_Click(object sender, EventArgs e)
        {
            Color = (string)cbColor.SelectedItem;
            
            wasButtonClicked = true;
            Close();
        }
    }
}
