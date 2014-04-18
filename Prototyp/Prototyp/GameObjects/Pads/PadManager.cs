using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Prototyp
{
    /* 
     PadManager sköter allt som rör plattformarna. 
     */

    class PadManager
    {
        List<Pad> pads; // Lista med plattformar
        Unit_Char p1; // Håller reda på kollision med spelare
        Point padSize;
        Random random;
        float startPosPadsY = 100f; // Var plattformarna startar i Y-led
        int column = 150; // Skärmen är indelad i kolumner och detta är bredden på kolumnen

        // Konstruktorn
        public PadManager(Unit_Char p1)
        {
            this.p1 = p1;
            pads = new List<Pad>(); // skapar listan
            random = new Random();

            padSize = new Point(100, 10);

            StartingPads();

            

        }

        // Stamdard mall för plattformarna vid start av spel
        private void StartingPads()
        {
            pads.Add(new Pad(new Vector2(column * 0, 500), padSize));
            pads.Add(new Pad(new Vector2(column * 1, 300), padSize));
            pads.Add(new Pad(new Vector2(column * 2, 100), padSize));
            pads.Add(new Pad(new Vector2(column * 3, 200), padSize));
            pads.Add(new Pad(new Vector2(column * 4, 500), padSize));
            pads.Add(new Pad(new Vector2(column * 5, 400), padSize));
            pads.Add(new Pad(new Vector2(column * 1, 200), padSize));
            pads.Add(new Pad(new Vector2(column * 2, 200), padSize));
            pads.Add(new Pad(new Vector2(column * 2, 100), padSize));
            pads.Add(new Pad(new Vector2(column * 5, 300), padSize));
            pads.Add(new Pad(new Vector2(column * 4, 200), padSize));
            pads.Add(new Pad(new Vector2(column * 3, 300), padSize));
            pads.Add(new Pad(new Vector2(column * 1, 500), padSize));

        }

        /// <summary>
        /// Skapar en plattform. Jag har delat in skrämen i 5 delar och slumpar ut vart de ska dyka upp.
        /// </summary>
        /// <param name="pos">Positionen på plattformen</param>
        /// <param name="size">Width och height på plattformen</param>
        public void CreateAPad(Vector2 prevPos, Point size)
        {
            Vector2 pos = new Vector2();

            int randomNr = random.Next(1, 6);


            random.Next(1, 6);
            if (randomNr == 1)
            {
                pos = new Vector2(column * 1, startPosPadsY);
            }
            else if (randomNr == 2)
            {
                pos = new Vector2(column * 2, startPosPadsY);
            }
            else if (randomNr == 3)
            {
                pos = new Vector2(column * 3, startPosPadsY);
            }
            else if (randomNr == 4)
            {
                pos = new Vector2(column * 4, startPosPadsY);
            }
            else if (randomNr == 5)
            {
                pos = new Vector2(column * 5, startPosPadsY);
            }

            pads.Add(new Pad(pos, size));
        }

        public void Update(GameTime gameTime)
        {
            // Uppdaterar listan med plattformar
            foreach (Pad p in pads)
            {
                p.Update(gameTime);

                if (p.pos.Y > Game1.screenHeight)
                {
                    CreateAPad(p.pos, padSize);
                    pads.Remove(p);
                    break;
                }
            }
        }

        public void Draw(SpriteBatch sB)
        {
            // ritar ut plattformarna
            foreach (Pad p in pads)
            {
                p.Draw(sB);
            }
        }
    }
}
