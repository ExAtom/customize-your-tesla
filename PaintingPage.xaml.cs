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
using TeslaCarConfigurator.Helpers;

namespace TeslaCarConfigurator
{
    /// <summary>
    /// Interaction logic for PaintingPage.xaml
    /// </summary>
    public partial class PaintingPage : PageBase
    {
        public PaintingPage()
        {
            InitializeComponent();
        }
        private void Windows_SizeChanged(object sender, SizeChangedEventArgs e)
        {
            Windows.Title = $"{Windows.ActualWidth} x {Windows.ActualHeight}";

            if (Windows.ActualWidth <= 710)
            {
                Menu.Width = 230;
            }
            else
            {
                Menu.Width = 400;
            }
        }

        private void rbColorSet_Checked(object sender, RoutedEventArgs e)
        {
            RadioButton currentColor = (RadioButton)sender;
            if (currentColor.Name == "rbColor1")
            {
                tbInfos.Text = "A kristályfehér az ártatlanság és a tökéletesség színe. Kiváló választás azon személyeknek, akik rendszeresen tisztítják autójukat és szeretik az egyszerűséget.";
                tbPrice.Text = "Alap Festés";
            }
            if (currentColor.Name == "rbColor2")
            {
                tbInfos.Text = "Máglyafekete fényezésünk a legelegánsabb. Tulajdonosa céltudatosságot sugall. Előnyös választás lehet, hiszen a szennyeződések nehezen vehetőek észre a kaszni felületen.";
                tbPrice.Text = "Ára: 20.000 Ft";
            }
            if (currentColor.Name == "rbColor3")
            {
                tbInfos.Text = "Impozáns szüke metál fényezésünk az elmúlt évek tapasztalatai alapján a legtöbbet választott szín. Tulajdonosa kreatív és társaságkedvelő valamint jó alkalmazkodóképességű.";
                tbPrice.Text = "Ára: 29.000 Ft";
            }
            if (currentColor.Name == "rbColor4")
            {
                tbInfos.Text = "A kék a víz, a harmónia, magabiztosság, kreativizmus és béke szimbóluma. Nagy valószínűséggel a járókelőknek is ez fog Önről eszükbe jutni, ha megláták a forgalomban.";
                tbPrice.Text = "Ára: 38.000 Ft";
            }
            if (currentColor.Name == "rbColor5")
            {
                tbInfos.Text = "Gyönyörű piros fényezésünk a szerelem és az energia színe. Tulajdonosa általában dinamikus és körültekintő, ugyanakkor hajlamos két végén égetni a gyertyát.";
                tbPrice.Text = "Ára: 40.500 Ft";
            }

            if (Config == null)
            {
                return;
            }

            byte index = (byte)(byte.Parse(currentColor.Name.Replace("rbColor", "")) - 1);
            Config.Painting.ColorIndex = index;
        }

        public override void OnAttachedToFrame()
        {
            byte chosenColorIndex = Config?.Painting?.ColorIndex ?? 0;
            RadioButton selected = null;

            if (chosenColorIndex == 0)
            {
                selected = rbColor1;
            }

            if (chosenColorIndex == 1)
            {
                selected = rbColor2;
            }

            if (chosenColorIndex == 2)
            {
                selected = rbColor3;
            }

            if (chosenColorIndex == 3)
            {
                selected = rbColor4;
            }

            if (selected == null)
            {
                return;
            }
            selected.IsChecked = true;
        }
    }
}
