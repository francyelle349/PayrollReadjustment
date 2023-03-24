using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.Remoting.Messaging;

namespace ReajusteSalarialData
{
    internal class RepositorioFuncionario
    {
        private IList<Funcionario> funcionarios =
      new BindingList<Funcionario>();

        public void Inserir(Funcionario funcionario)
        {
            funcionarios.Add(funcionario);
        }
        public double ObterUmaPorcentagem(int position)
        {
            double posi = 0;
            if (position < funcionarios.Count)
            {
                
                for (int i = 0; i < funcionarios.Count;i++)
                {
                    if(i == position)
                    {
                        posi = funcionarios[i].Percentual;
                    }
                  


                }
                

            }
            return posi;


        }
        public double NovoSalario(int position)
        {
            double posi = 0;
            if(position < funcionarios.Count)
            {
                for (int i = 0; i < funcionarios.Count; i++)
                {
                    if (i == position)
                    {
                        posi = funcionarios[i].NovoSalario;
                    }



                }

            }

            return posi;
        }

        public double totalSemReajuste()
        {
            double totalsemajuste = 0;
            for (int i = 0; i < funcionarios.Count; i++)
            {
                totalsemajuste += funcionarios[i].Salario;
               
                
            }
            return totalsemajuste;
        }
        public double totalComReajuste()
        {
            double totalcomajuste = 0;
            for (int i = 0; i < funcionarios.Count; i++)
            {
                totalcomajuste += funcionarios[i].NovoSalario;


            }
            return totalcomajuste;

        }
        public double totalPercentual()
        {
            double percentual = (totalComReajuste() - totalSemReajuste()) * 100 / totalSemReajuste();
            
            return percentual;
            
        }
        

    }
}
