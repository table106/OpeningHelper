using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace OpeningHelper
{
    public partial class OHMain : Form
    {
        public static readonly Random random = new Random();
        private static readonly string[] wear = { "battle-scarred", "well worn", "field tested", "minimal wear", "factory new" };
        public static readonly string[] splash = { 
            "or you could just use a calculator",
            "gold gold gold", 
            "daring today, aren't we?",
            "99% of gamblers quit before their big win",
            $"this text is {wear[random.Next(wear.Length)]}!",
            "what do you mean i won't profit?",
            "t",
            "circle square, circle square...",
            "POW! haha",
            "dQw4w9WgXcQ",
            "now that's class",
            "you call shooting a coin a martial art??",
            "exquisite software",
            "honestly quite incredible",
            "chat is this fr?",
            "hi",
            "it helps openly",
            "the hobby",
            "zis is a flammenwerfer, it werfs flammens",
            "vegan!",
            "one does not simply win",
            "mirror mirror on the wall, who's the gambler of them all",
            "you know that buying skins is an option too, right?",
            "silksong when", // should probably remove this when it arrives
            "peak",
            "apples my beloved",
            "consider this a blessing",
            "where did you even find this",
            "scattered across space and time... is the person who asked",
            "helpful!",
            "sent to Bydgoszcz",
            "i love Poland",
            "crazy to think 2002 was 6 years ago",
            "opening cases at 3am!!! (gone wrong)"
        };

        public OHMain()
        {
            InitializeComponent();
            GenerateSplashText();
        }

        public void GenerateSplashText()
        {
            SplashText.Text = splash[random.Next(splash.Length)];
        }

        private void Calculate_Click(object sender, EventArgs e)
        {
            GenerateSplashText();
            if (!double.TryParse(KeyPrice.Text, NumberStyles.Any, CultureInfo.InvariantCulture, out double keyPrice))
            {
                KeyPrice.Focus();
                MessageBox.Show("Expected decimal point value for key price", "Value error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            else if (keyPrice <= 0)
            {
                KeyPrice.Focus();
                MessageBox.Show("Price cannot be less than or 0", "Value error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            if (!double.TryParse(CasePrice.Text, NumberStyles.Any, CultureInfo.InvariantCulture, out double casePrice))
            {
                CasePrice.Focus();
                MessageBox.Show("Expected decimal point value for case price", "Value error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            else if (casePrice <= 0)
            {
                CasePrice.Focus();
                MessageBox.Show("Price cannot be less than or 0", "Value error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            if (!int.TryParse(CaseCount.Text, NumberStyles.Any, CultureInfo.InvariantCulture, out int caseCount))
            {
                CaseCount.Focus();
                MessageBox.Show("Expected integer (whole number)", "Value error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            else if (caseCount <= 0)
            {
                CaseCount.Focus();
                MessageBox.Show("Count cannot be less than or 0", "Value error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            FinalPrice.Text = "Final price: " + (keyPrice * caseCount + casePrice * caseCount).ToString();
        }
    }
}
