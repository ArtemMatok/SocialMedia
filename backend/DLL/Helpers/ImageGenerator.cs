using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Net.Mime.MediaTypeNames;
using System.Drawing;
using System.Drawing.Imaging;

namespace Data.Helpers
{
    public static class ImageGenerator
    {
        public static string GenerateRandomColor()
        {
            Random random = new Random();
            string color = String.Format("{0:X6}", random.Next(0x1000000)); // Генерує значення від 0 до 0xFFFFFF і перетворює в HEX
            return color;
        }

        public static string GetInitials(string fullName)
        {
            string[] nameParts = fullName.Split(' ');
            string initials = "";

            foreach (string part in nameParts)
            {
                if (!string.IsNullOrEmpty(part))
                {
                    initials += char.ToUpper(part[0]);
                }
            }

            return initials;
        }
    }
}
