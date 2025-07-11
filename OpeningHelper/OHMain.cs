﻿using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Windows.Forms;

namespace OpeningHelper
{
    public partial class OHMain : Form
    {
        public static readonly Random random = new Random();
        private static readonly string[] WEAR = { "battle-scarred", "well worn", "field tested", "minimal wear", "factory new" };
        public static readonly string[] splash = { 
            "or you could just use a calculator",
            "gold gold gold", 
            "daring today, aren't we?",
            "99% of gamblers quit before their big win",
            $"this text is {WEAR[random.Next(WEAR.Length)]}!",
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
            SplashText.Text = splash[random.Next(splash.Length)];
        }

        /// <summary>
        /// Try to parse text from a <c>TextBox</c>.
        /// </summary>
        /// <param name="textBox">Text source</param>
        /// <param name="result">Result of parsing</param>
        private bool ParseTextBox(TextBox textBox, out double result)
        {
            if (!double.TryParse(textBox.Text, NumberStyles.Any, CultureInfo.InvariantCulture, out result))
            {
                textBox.Focus();
                MessageBox.Show("Expected decimal point value", "Value error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
            else if (result <= 0)
            {
                textBox.Focus();
                MessageBox.Show("Price cannot be less than or 0", "Value error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }
            return true;
        }

        /// <summary>
        /// Try to parse text from a <c>TextBox</c>.
        /// </summary>
        /// <param name="textBox">Text source</param>
        /// <param name="result">Result of parsing</param>
        private bool ParseTextBox(TextBox textBox, out int result)
        {
            if (!int.TryParse(textBox.Text, NumberStyles.Any, CultureInfo.InvariantCulture, out result))
            {
                textBox.Focus();
                MessageBox.Show("Expected whole number", "Value error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            } 
            else if (result <= 0)
            {
                textBox.Focus();
                MessageBox.Show("Count cannot be less than or 0", "Value error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }
            return true;
        }

        private void Calculate_Click(object sender, EventArgs e)
        {
            if (!ParseTextBox(KeyPrice, out double keyPrice)) return;
            if (!ParseTextBox(CasePrice, out double casePrice)) return;
            if (!ParseTextBox(CaseCount, out int caseCount)) return;
            FinalPrice.Text = "Final price: " + (keyPrice * caseCount + casePrice * caseCount).ToString();
        }

        private void HelpButton_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Key price - The price of a singular key.\n" +
                "Case price - The price of a singular case.\n" +
                "Case count - The amount of cases to be opened.",
                "Help menu", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
    }
}
