using System.Data;
using System.Media;
string couleurs = "RBVJ";
Random random = new();
int ChoixCouleur = random.Next(4);
List<char> OrdreCouleur = new List<char>();
int score = 0; double milliseconds = 1000;
static void PerduDommage()
{
	SoundPlayer FirstSound = new SoundPlayer(@"..\..\..\Wrong Buzzer - Sound Effect.wav");
	FirstSound.Load();
	FirstSound.PlaySync();
}
static void GagneBienJoue()
{
	SoundPlayer SecondSound = new SoundPlayer(@"..\..\..\nice meme.wav");
	SecondSound.Load();
	SecondSound.PlaySync();
}
static void Ambiance()
{
	SoundPlayer ThirdSound = new SoundPlayer(@"..\..\..\Question à 300 000 € Qui veut gagner des millions.wav");
	ThirdSound.PlayLooping();
}
Ambiance();
Console.WriteLine("Choisis la vitesse: ");
Console.WriteLine("1.Lent,2.Normal,3.Rapide");
string valeur = Console.ReadLine();
switch (valeur)
{
	case "1":
		milliseconds = 1500;
		break;
	case "2":
		milliseconds = 1000;
		break;
	case "3":
		milliseconds = 250;
		break;
}
Console.Clear();
while (true)
{
	ChoixCouleur = random.Next(4);
	OrdreCouleur.Add(couleurs[ChoixCouleur]);
	Console.WriteLine("Regardez:");
	foreach (var item in OrdreCouleur)
	{
		switch (item)
		{
			case 'R':
				Console.BackgroundColor = ConsoleColor.Red;
				Console.Write("  ");
				Console.ResetColor();
				Console.Write(" ");
				break;
			case 'B':
				Console.BackgroundColor = ConsoleColor.Blue;
				Console.Write("  ");
				Console.ResetColor();
				Console.Write(" ");
				break;
			case 'V':
				Console.BackgroundColor = ConsoleColor.Green;
				Console.Write("  ");
				Console.ResetColor();
				Console.Write(" ");
				break;
			case 'J':
				Console.BackgroundColor = ConsoleColor.Yellow;
				Console.Write("  ");
				Console.ResetColor();
				Console.Write(" ");
				break;
		}
		Thread.Sleep((int)milliseconds);
	}
	milliseconds *= 0.8;
	Console.Clear();
	Console.WriteLine("A vous: ");
	string answer = String.Join("", OrdreCouleur);
	string InputBeforeUp = Console.ReadLine();
	string input = InputBeforeUp.ToUpper();
	if (input != answer)
	{
		Console.WriteLine("Vous avez perdu !");
		PerduDommage();
		Console.WriteLine("Voulez vous rejouer ? (Y/N)");
		if (Console.ReadLine().ToUpper() == "Y")
		{
			Console.Clear();
			OrdreCouleur.Clear();
			score = 0;
			milliseconds = double.Parse(valeur);
			GagneBienJoue();
			Ambiance();
			Console.WriteLine("Choisis la vitesse: ");
			Console.WriteLine("1.Lent,2.Normal,3.Rapide");
			valeur = Console.ReadLine();
			switch (valeur)
			{
				case "1":
					milliseconds = 1500;
					break;
				case "2":
					milliseconds = 1000;
					break;
				case "3":
					milliseconds = 250;
					break;
			}
			Console.Clear();
			continue;
		}
		else
		{
			Console.Clear();
			break;
		}
	}
	score++;
	Console.Clear();
}

Console.WriteLine("votre score est de " + score + ":)");
