using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LIVEX.Class
{
    class Tabulador
    {
        /// <summary>
        /// Esta función calcula el salario base conforme al tabulador
        /// </summary>
        /// <param name="skills">0=500 TOEFL 1=Experiencia 2=Teacher Training 3=LIDILE o similar</param>
        /// <param name="Idioma">0=Inglés y 1=Francés</param>
        /// <returns></returns>
        public static int CalcularSalarioBase(int[] skills,int Idioma) {

            int salarioBase = 0;

            if (Idioma == 0) {//Inglés
              if(skills[0]==1&& skills[1] == 1&& skills[2] == 1&& skills[3] == 1)
                    salarioBase = 37;
              else if (skills[0] == 0 && skills[1] == 1 && skills[2] == 1 && skills[3] == 1)
                    salarioBase = 35;
              else if (skills[0] == 1 && skills[1] == 0 && skills[2] == 1 && skills[3] == 1)
                    salarioBase = 35;
              else if (skills[0] == 1 && skills[1] == 1 && skills[2] == 0 && skills[3] == 1)
                    salarioBase = 35;
              else if (skills[0] == 1 && skills[1] == 1 && skills[2] == 1 && skills[3] == 0)
                    salarioBase = 35;
              else if (skills[0] == 1 && skills[1] == 0 && skills[2] == 0 && skills[3] == 1)
                    salarioBase = 35;
              else if (skills[0] == 1 && skills[1] == 0 && skills[2] == 1 && skills[3] == 0)
                    salarioBase = 35;
              else if (skills[0] == 1 && skills[1] == 1 && skills[2] == 0 && skills[3] == 0)
                    salarioBase = 32;
              else if (skills[0] == 0 && skills[1] == 0 && skills[2] == 0 && skills[3] == 1)
                    salarioBase = 32;
              else if (skills[0] == 0 && skills[1] == 0 && skills[2] == 1 && skills[3] == 0)
                    salarioBase = 32;
              else if (skills[0] == 0 && skills[1] == 1 && skills[2] == 0 && skills[3] == 0)
                    salarioBase = 30;
              else if (skills[0] == 1 && skills[1] == 0 && skills[2] == 0 && skills[3] == 0)
                    salarioBase = 30;
            }
            else//Fránces
            {
                if (skills[0] == 1 && skills[1] == 1 && skills[2] == 1 && skills[3] == 1)
                    salarioBase = 42;
                else if (skills[0] == 0 && skills[1] == 1 && skills[2] == 1 && skills[3] == 1)
                    salarioBase = 40;
                else if (skills[0] == 1 && skills[1] == 0 && skills[2] == 1 && skills[3] == 1)
                    salarioBase = 40;
                else if (skills[0] == 1 && skills[1] == 1 && skills[2] == 0 && skills[3] == 1)
                    salarioBase = 40;
                else if (skills[0] == 1 && skills[1] == 1 && skills[2] == 1 && skills[3] == 0)
                    salarioBase = 40;
                else if (skills[0] == 1 && skills[1] == 0 && skills[2] == 0 && skills[3] == 1)
                    salarioBase = 40;
                else if (skills[0] == 1 && skills[1] == 0 && skills[2] == 1 && skills[3] == 0)
                    salarioBase = 40;
                else if (skills[0] == 1 && skills[1] == 1 && skills[2] == 0 && skills[3] == 0)
                    salarioBase = 37;
                else if (skills[0] == 0 && skills[1] == 0 && skills[2] == 0 && skills[3] == 1)
                    salarioBase = 37;
                else if (skills[0] == 0 && skills[1] == 0 && skills[2] == 1 && skills[3] == 0)
                    salarioBase = 37;
                else if (skills[0] == 0 && skills[1] == 1 && skills[2] == 0 && skills[3] == 0)
                    salarioBase = 35;
                else if (skills[0] == 1 && skills[1] == 0 && skills[2] == 0 && skills[3] == 0)
                    salarioBase = 35;
            }
            return salarioBase;
        }
    }
}
