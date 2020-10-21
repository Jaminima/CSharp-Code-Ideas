using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSharp_Code_Ideas
{
    public static class Ceasar_Cipher
    {
        public static string SingleShift(string Raw, int offset = 1)
        {
            Raw = Raw.ToLower(); //Make all the string lowercase

            char[] Characters = Raw.ToCharArray(); //Get every single character in the string

            string Out = ""; //Will store the output

            foreach (char C in Characters) //For every character in the Characters array
            {
                //This uses ASCII http://www.asciitable.com/

                /*Take the ascii value of the character and minus 97
                 *This makes the value of a 0 and z 25*/
                int tempC = C - 97; 

                /*Move the letter by offset through the alphabet
                 By Default a->b y->z */
                tempC += offset;

                /*Perform modulous on the character value
                 This forces the values to loop
                 So that z becomes a and not just overflowing into other symbols*/
                tempC = tempC % 26;

                /*Move the values back up to their correct ASCII values
                 Undos line 25*/
                tempC += 97;

                //Add the character onto the out string
                Out += (char) tempC;
            }

            return Out;
        }
    }
}
