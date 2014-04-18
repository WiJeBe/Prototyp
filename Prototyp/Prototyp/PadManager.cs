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
        // Konstruktorn
        public PadManager()
        {
            pads = new List<Pad>(); // skapar listan

            for (int i = 0; i < 10; i++)
            {
                CreateAPad(new Vector2(100, 100), new Point(50, 10));
            }
            
        }

        /// <summary>
        /// Skapar en plattform
        /// </summary>
        /// <param name="pos">Positionen på plattformen</param>
        /// <param name="size">Width och height på plattformen</param>
        public void CreateAPad(Vector2 pos, Point size)
        {
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
