using PokemonLibrary;
using System;
using System.Collections.Generic;
using System.IO;
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

namespace PokemonWPF
{
	public partial class PokemonsList : UserControl
	{
		public PokemonsList()
		{
			InitializeComponent();

			//contentPresenter.Content = Pokemons();
		}

		private void SearchBox_TextChanged(object sender, TextChangedEventArgs e)
		{
			int[] familiesSelected = Pokemon.ForSearchBar(((TextBox)sender).Text);

			for (int i = 0; i < familiesArray.Length; i++)
			{
				if (familiesSelected.Contains(i))
					familiesArray[i].Visibility = Visibility.Visible;
				else
					familiesArray[i].Visibility = Visibility.Collapsed;
			}
		}

		private StackPanel Pokemons()
		{
			int familiesCount = Pokemon.GetFamiliesCount();
			familiesArray = new StackPanel[familiesCount];

			//Create pokemon panel and fill it
			StackPanel PokemonPanel = new StackPanel();
			for (int family = 0; family < familiesCount; family++)
			{
				//Create family panel and fill it
				StackPanel familyPanel = new StackPanel()
				{
					Margin = new Thickness(0, 5, 0, 5),
					Orientation = Orientation.Horizontal,
					HorizontalAlignment = HorizontalAlignment.Center,
					Background = new SolidColorBrush(Color.FromArgb(100, 0, 0, 0))
				};

				for (int stage = 0; stage < 3; stage++)
				{
					Pokemon[] pokemons = Pokemon.GetFamily(family, stage);

					//Create stage panel and fill this
					StackPanel stagePanel = new StackPanel()
					{
						Margin = new Thickness(5),
						Width = 140,
						Orientation = Orientation.Vertical,
						VerticalAlignment = VerticalAlignment.Center
					};

					for (int member = 0; member < pokemons.Length; member++)
					{
						string id = pokemons[member].Number.PadLeft(3, '0');
						string name = pokemons[member].Name;
						string[] types = pokemons[member].Type.Split(',');
						string type1 = types[0];
						string type2 = types.Length == 2 ? types[1] : "";

						//===== GET IMAGE =====//
						string source = $"{Directory.GetCurrentDirectory()}\\resources\\pokemons\\{id}-00.png";
						if (!File.Exists(source)) source = $"{Directory.GetCurrentDirectory()}\\resources\\pokemons\\000-00.png";
						Image image = new Image
						{
							Source = GetImageSourceFromBitmap(source),
							Height = 60,
							Width = 60
						}; //Create box for image

						//===== GET NAME & ID =====//
						StackPanel nameIdPanel = new StackPanel
						{
							Orientation = Orientation.Horizontal,
							HorizontalAlignment = HorizontalAlignment.Center
						}; //Create name & id panel 

						nameIdPanel.Children.Add(new TextBlock
						{
							Text = $"{name} ",
							FontSize = 14,
							FontFamily = new FontFamily("Roboto"),
							FontWeight = FontWeights.Bold,
							TextAlignment = TextAlignment.Right
						}); //Add name block

						nameIdPanel.Children.Add(new TextBlock
						{
							Text = $" #{id}",
							FontSize = 14,
							Foreground = new SolidColorBrush(Colors.Silver),
							FontFamily = new FontFamily("Roboto"),
							FontWeight = FontWeights.Bold,
							TextAlignment = TextAlignment.Left
						}); //Add id block

						//===== GET TYPES =====//
						StackPanel typesPanel = new StackPanel()
						{
							Orientation = Orientation.Horizontal,
							HorizontalAlignment = HorizontalAlignment.Center
						}; //Create types panel

						typesPanel.Children.Add(Type(type1)); //Add main type

						if (type2 != "") typesPanel.Children.Add(Type(type2)); //Add secondary type

						StackPanel memberPanel = new StackPanel(); //Create member panel
						memberPanel.Children.Add(image);  //Add image
						memberPanel.Children.Add(nameIdPanel); //Add name & id panel
						memberPanel.Children.Add(typesPanel); //Add types panel

						stagePanel.Children.Add(new Border()
						{
							Background = new SolidColorBrush(Colors.Wheat),
							BorderBrush = new SolidColorBrush(Color.FromArgb(100, 0, 0, 0)),
							BorderThickness = new Thickness(5),
							CornerRadius = new CornerRadius(8),
							Child = memberPanel
						});
					}

					familyPanel.Children.Add(stagePanel);
				}

				familiesArray[family] = familyPanel;
				PokemonPanel.Children.Add(familyPanel);
			}

			return PokemonPanel;
		}
		private Image Type(string type)
		{
			Image typeImage = new Image()
			{
				Margin = new Thickness(2),
				Source = GetImageSourceFromBitmap($"{Directory.GetCurrentDirectory()}\\resources\\elements\\{type}.png"),
				Height = 28,
				Width = 28,
				VerticalAlignment = VerticalAlignment.Center,
				HorizontalAlignment = HorizontalAlignment.Center
			};
			RenderOptions.SetBitmapScalingMode(typeImage, BitmapScalingMode.HighQuality);

			return typeImage;
		}

		//convert System.Drawing.Image to WPF image
		private ImageSource GetImageSourceFromBitmap(string imagePath) => System.Windows.Interop.Imaging.CreateBitmapSourceFromHBitmap(new System.Drawing.Bitmap(imagePath).GetHbitmap(), IntPtr.Zero, Int32Rect.Empty, BitmapSizeOptions.FromEmptyOptions());
		private StackPanel[] familiesArray;
	}
}
