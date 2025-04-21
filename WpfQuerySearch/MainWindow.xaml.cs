using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Globalization;
using System.Runtime.InteropServices.JavaScript;
using System.Text.RegularExpressions;
using System.Threading;
using System.Windows.Media.Media3D;

namespace WpfQuerySearch
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        #region Properties
        string[] monsters ={"Abaia","Almas","Aqrabuamelu","Baba Yaga","Bakunawa","Banshee","Basilisk","Beast of Gévaudan","Behemoth","Bigfoot","Bogeyman","Centaur","Cerberus","Changeling","Charybdis","Chimera","Chupacabra","Cryptozoology","Cthulhu","Cyclopes","Cetus","Cockatrice","Demogorgon","Demon","Devil","Draugr","Dragon","Dr. Jekyll and Mr. Hyde","Elemental","Piranha","Shark","Elf","Extraterrestrial life","Familiar","Fairy","Frankenstein","Gargoyle","Gashadokuro","Giant","Goblin","Ghoul","Ghost","Gorgon","Gremlin","Griffin","Grim Reaper","Gnome","Headless Horseman","Horned Serpent","Halfling","Hobgoblin","Imp","Invisible Stalker","Hydra","Jiangshi","Jinn","Kaiju","Kappa","Kelpie","Kraken","Krampus","Kobold","Loch Ness monster","Leprechaun","Leviathan","Lich","Manananggal","Manticore","Mapinguari","Merfolk","Mermaid","Midgard Serpent","Mind Flayer","Minokawa","Minotaur","Mothman","Merman","Mutant","Mummy","Nymphs","Ogre","Oni","Orc","Pontianak","Scylla","Sea Serpent","Slime","Siren","Skin-walker","Skeleton","Slenderman","Spirit","Tengu","Therianthropes","Tiamat","Troll","Tikbalang","Typhon","Unicorn","Vampire","Vecna","Virtue","Warg","Wendigo","Werecats","Werehyena","Werewolf","Witch","Yaksha","Yamata no Orochi","Yaoguai","Yeti","Yokai","Yowie","Yara-ma-yha-who","Zombie "};

        IEnumerable<string> query;
        TextInfo culturalAdapt = new CultureInfo("en-US", false).TextInfo;
        bool light = false;

        #endregion
        public MainWindow()
        {
            InitializeComponent();
        }
        #region Methods
        private string defaultQueryResult()
        {
            query = from monster in monsters orderby monster select monster;
            string output = "";
            foreach (string monster in query)
            {
                output += monster + Environment.NewLine;
            }

            return output;
        }

        private void Start()

        {

            OutputTxtBlck.Text = defaultQueryResult();
            showLight();
        }

        private void showLight()
        {
            if (light == true)
            {
                LightSource.Visibility = Visibility.Visible;
                return; //kicks out of the method
            }
           
                LightSource.Visibility = Visibility.Collapsed;
            
        }


        private void SubmitBtn_Click(object sender, RoutedEventArgs e)
        {
            string output = "Search Results:\n";
            query = from monster
                    in monsters
                    where monster.Contains(InputTxtBlck.Text)
                    orderby monster
                    select monster;

            foreach (string monster in query)
            {
                output += $"{monster}\n";
            }
            OutputTxtBlck.Text = output;
            InputTxtBlck.Text = "";
        }

        private void Grid_Loaded(object sender, RoutedEventArgs e)
        {
            Start();
        }

        private void TitleCaseBtn_Click(object sender, RoutedEventArgs e)
        {
           
            OutputTxtBlck.Text = culturalAdapt.ToTitleCase(defaultQueryResult()); 
        }

        private void ResetBtn_Click(object sender, RoutedEventArgs e)
        {
            Start();
        }

        private void SearchLength_Click(object sender, RoutedEventArgs e)
        {
            string output = "";
            query = from monster
                        in monsters
                        orderby monster
                        descending
                        select monster;
            foreach (string monster in query)
            {
                output += monster + Environment.NewLine;
            }

            OutputTxtBlck.Text= output;
        }

        private void LengthBtn_Click(object sender, RoutedEventArgs e)
        {

            string output = "";
            
            query = from monster in monsters orderby monster.Length select monster;

            foreach (string monster in query)
            {
                output += monster + Environment.NewLine;
            }

            OutputTxtBlck.Text = output;
        }

        private void LightToggleBtn_Click(object sender, RoutedEventArgs e)
        {
            
            if (light)
            {
                LightToggleBtn.Content = "On";
                
            }
            else { LightToggleBtn.Content = "Off"; }
           

            light = !light;
            showLight();
        }
        #endregion
    }
}