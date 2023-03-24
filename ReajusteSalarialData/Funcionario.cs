using System.Runtime.CompilerServices;

namespace ReajusteSalarialData
{
    internal class Funcionario
    {
        public int Codigo { get; set; }
        public double Salario { get; set; }
        public double Percentual
        {
            get
            {
                if (this.Salario < 1000) return 15;
                else if (this.Salario < 1500) return 10;
                else
                    return 5;
            }
           
        }
        public double NovoSalario
        {
            get
            {
                return (this.Salario * this.Percentual /
                100) + this.Salario;
            }
           
        }
        public Funcionario(int codigo,double salario) {
            this.Codigo = codigo;
            this.Salario = salario;
        }
        public Funcionario()
        {

        }
    }
}

