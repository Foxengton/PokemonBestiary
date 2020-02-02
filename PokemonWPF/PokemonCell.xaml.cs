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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace PokemonWPF
{
	public partial class PokemonCell : UserControl
	{
		public PokemonCell()
		{
			InitializeComponent();

			////===== GET IMAGE =====//
			//string source = $"{Directory.GetCurrentDirectory()}\\resources\\pokemons\\{id}-00.png";
			//if (!File.Exists(source)) source = $"{Directory.GetCurrentDirectory()}\\resources\\pokemons\\000-00.png";
			//Image image = new Image
			//{
			//	Source = GetImageSourceFromBitmap(source),
			//	Height = 60,
			//	Width = 60
			//}; //Create box for image

			////===== GET NAME & ID =====//
			//StackPanel nameIdPanel = new StackPanel
			//{
			//	Orientation = Orientation.Horizontal,
			//	HorizontalAlignment = HorizontalAlignment.Center
			//}; //Create name & id panel 

			//nameIdPanel.Children.Add(new TextBlock
			//{
			//	Text = $"{name} ",
			//	FontSize = 14,
			//	FontFamily = new FontFamily("Roboto"),
			//	FontWeight = FontWeights.Bold,
			//	TextAlignment = TextAlignment.Right
			//}); //Add name block

			//nameIdPanel.Children.Add(new TextBlock
			//{
			//	Text = $" #{id}",
			//	FontSize = 14,
			//	Foreground = new SolidColorBrush(Colors.Silver),
			//	FontFamily = new FontFamily("Roboto"),
			//	FontWeight = FontWeights.Bold,
			//	TextAlignment = TextAlignment.Left
			//}); //Add id block

			////===== GET TYPES =====//
			//StackPanel typesPanel = new StackPanel()
			//{
			//	Orientation = Orientation.Horizontal,
			//	HorizontalAlignment = HorizontalAlignment.Center
			//}; //Create types panel

			//typesPanel.Children.Add(Type(type1)); //Add main type

			//if (type2 != "") typesPanel.Children.Add(Type(type2)); //Add secondary type

			//StackPanel memberPanel = new StackPanel(); //Create member panel
			//memberPanel.Children.Add(image);  //Add image
			//memberPanel.Children.Add(nameIdPanel); //Add name & id panel
			//memberPanel.Children.Add(typesPanel); //Add types panel
		}

		public static readonly DependencyProperty nameProperty = DependencyProperty.Register("name", typeof(string), typeof(PokemonCell));

		public static readonly DependencyProperty idProperty = DependencyProperty.Register("id", typeof(string), typeof(PokemonCell));

		public static readonly DependencyProperty type1Property = DependencyProperty.Register("type1", typeof(string), typeof(PokemonCell));

		public static readonly DependencyProperty type2Property = DependencyProperty.Register("type2", typeof(string), typeof(PokemonCell));

		public string name
		{
			get { return (string)GetValue(nameProperty); }
			set { SetValue(nameProperty, value); }
		}

		public string id
		{
			get { return (string)GetValue(idProperty); }
			set { SetValue(idProperty, value); }
		}

		public string type1
		{
			get { return (string)GetValue(type1Property); }
			set { SetValue(type1Property, value); }
		}

		public string type2
		{
			get { return (string)GetValue(type2Property); }
			set { SetValue(type2Property, value); }
		}

		public override void OnApplyTemplate()
		{
			base.OnApplyTemplate();

			(FindName("textName") as TextBlock).Text = name;

			(FindName("textId") as TextBlock).Text = $" #{id}";

			(FindName("imageIcon") as Image).Source = GetImageSource("resources/pokemons/000-00.png");

			(FindName("Types") as StackPanel).Children.Clear();

			(FindName("Types") as StackPanel).Children.Add(new Image
			{
				Height = 28,
				Width = 28,
				Source = GetImageSource($"resources/elements/{type1}.png")
			});
			
			if (type2 != null)
				(FindName("Types") as StackPanel).Children.Add(new Image
				{
					Height = 28,
					Width = 28,
					Source = GetImageSource($"resources/elements/{type2}.png")
				});

		}

		private static ImageSource GetImageSource(string imagePath)
		{
			ImageSourceConverter converter = new ImageSourceConverter();
			return (ImageSource)converter.ConvertFromString($"./PokemonWPF/{imagePath}");
		}
	}
}
