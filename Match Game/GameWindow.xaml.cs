using Match_Game.Controls;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Media;
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
using System.Windows.Threading;

namespace Match_Game
{
	public partial class GameWindow : Window
	{
		private readonly int maxMistakes = 5;
		private int mistakes;
		bool gameOver;

		private Random random = new Random();

		private DispatcherTimer timer = new DispatcherTimer();

		private List<Card> cards = new List<Card>();

		private List<string> symbols = new List<string>()
		{
			"!", "!", "N", "N", ",", ",",
			"b", "b", "v", "v", "w", "w",
		};

		private List<string> symbolsCopy = new List<string>()
		{
			"!", "!", "N", "N", ",", ",",
			"b", "b", "v", "v", "w", "w",
		};

		private Card card1 = null;
		private Card card2 = null;

		private SoundPlayer soundPlayer = new(Properties.Resources.card);

		public GameWindow()
		{
			InitializeComponent();
			timer.Interval = new TimeSpan(0, 0, 1);
			timer.Tick += TimerTick;
			txtTurns.Text = "Remaining Mistakes: " + (maxMistakes - mistakes);
		}

		public void RegisterCard(Card card)
		{
			card.Setup(symbols);
			cards.Add(card);
		}

		public void SelectCard(Card card)
		{
			if (gameOver) return;
			card.State = Card.eState.Flipped;
			soundPlayer.Play();

			if (card1 == null)
			{
				card1 = card;
			}
			else
			{
				card2 = card;

				bool win = true;
				if (card1.Symbol == card2.Symbol)
				{
					card1.State = Card.eState.Matched;
					card2.State = Card.eState.Matched;
					card1 = null;
					card2 = null;

					foreach (Card cardi in cards)
					{
						if (cardi.State != Card.eState.Matched)
						{
							win = false;
							break;
						}
					}

					if (win)
					{
						MessageBox.Show("You Win!");
						gameOver = true;
						return;
					}
				}
				else
				{
					foreach (Card cardi in cards)
					{
						if (cardi.State == Card.eState.Idle)
						{
							cardi.State = Card.eState.Inactive;
						}
					}
					timer.Start();
					mistakes++;
					txtTurns.Text = "Remaining Mistakes: " + (maxMistakes - mistakes);
				}
				if (mistakes == maxMistakes)
				{
					MessageBox.Show("You Lose");
					gameOver = true;
				}
			}
		}

		private void TimerTick(object sender, EventArgs e)
		{
			timer.Stop();
			foreach (Card card in cards)
			{
				if (card.State != Card.eState.Matched)
				{
					card.State = Card.eState.Idle;
				}
			}
			card1 = null;
			card2 = null;
		}

		private void btn_New_Game(object sender, RoutedEventArgs e)
		{
			gameOver = false;
			mistakes = 0;
			txtTurns.Text = "Remaining Mistakes: " + (maxMistakes - mistakes);
			foreach (string symbol in symbolsCopy)
			{
				symbols.Add(symbol);
			}

			foreach (Card card in cards)
			{
				card.Setup(symbols);
			}
		}
	}
}
