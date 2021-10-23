using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace RandomNumbersGenerator.WPF
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void BtnGenerate_Click(object sender, RoutedEventArgs e)
        {
            var lotteryNumbersGenerator = new LotteryNumbersGenerator.LotteryNumbersGenerator();
            var noOfSets = txtNumberOfSets.Text != "" ? Convert.ToInt32(txtNumberOfSets.Text) : 1;
            var lotteryType = ddlLotteryTypes.SelectedIndex + 1;
            var generatedNosDto = lotteryNumbersGenerator.GenerateNumbers(noOfSets, lotteryType).ToList();

            textBlock.Text = "";

            if (generatedNosDto.Count() > 0)
            {
                var firstRow = generatedNosDto.FirstOrDefault();

                foreach (var mainNumbers in firstRow.MainNumbers)
                {
                    textBlock.Inlines.Add("Main Number\t");
                    textBlock.Background = Brushes.Yellow;
                }

                foreach (var luckyStars in firstRow.LuckyStars)
                {
                    textBlock.Inlines.Add("Lucky Star\t");
                }

                textBlock.Inlines.Add("\r");

                foreach (var no in generatedNosDto)
                {
                    foreach(var mainNumber in no.MainNumbers)
                    {
                        textBlock.Inlines.Add(mainNumber.ToString());
                        textBlock.Inlines.Add("\t\t");
                    }
                    foreach (var luckyStar in no.LuckyStars)
                    {
                        textBlock.Inlines.Add(luckyStar.ToString());
                        textBlock.Inlines.Add("\t\t");
                    }

                    textBlock.Inlines.Add("\r");


                }
            }
        }
    }
}
