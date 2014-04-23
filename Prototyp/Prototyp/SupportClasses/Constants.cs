using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Prototyp
{
/* Tänkt att vara samlingsplats för alla statiska variabler som både kan nås och förändras överallt i koden. Kan variabeln bara förändras lokalt i sin klass ska den ej placeras här! */
	static class Constants
	{
	// (Global)Variable(s)
	public static Random rand = new Random(); 
	public static int SCREEN_WIDTH = 1000, SCREEN_HEIGHT = 600; // Storleken på fönstret
	public static int PAD_WIDTH = 100, PAD_HEIGHT = 20, PAD_SIZEMOD = 5; // Grundstorlek och storleksförändringsfaktor för pads
	

	}
}
