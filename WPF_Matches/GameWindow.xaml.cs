using MatchGame.Controls;
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
using System.Windows.Shapes;

namespace MatchGame
{
    /// <summary>
    /// Interaction logic for GameWindow.xaml
    /// </summary>
    public partial class GameWindow : Window
    {
        public GameWindow()
        {
            InitializeComponent();
        }

        public void RegisterCard(Card card)
        {
            //card.state = card.estate.idle;
            //int cardsymbolindex = random.next(0, symbols.count);
            //card.symbol = symbols[cardsymbolindex];
            //symbols.removeat(cardsymbolindex);
            //cards.add(card);

        }
    }
}