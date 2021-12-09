using Bot_Idosos.Views;
using ClosedXML.Excel;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Bot_Idosos
{
    static class Program
    {
        // Cada um dos módulos (instâncias das classes) será representado pela respetiva propriedade
        //com get público e set privado

        public static FormRegistar _FormRegistar { get; private set; }
        public static FormViewPrincipalApp _FormViewPrincipalApp { get; private set; }
   




        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {

            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            // Os objetos devem ser instanciados nesta zona do método Main e pela ordem M V C,
            //ou seja,instanciar primeiro todos os Models seguido de todas as Views e finalmente todos os Controllers

            // MODELS


            // VIEWS
            //depois tenho de apagar a linha abaixo e meter a view inicial
            _FormRegistar = new FormRegistar();
            _FormViewPrincipalApp = new FormViewPrincipalApp();
            
            // CONTROLLERS 
          
            //Primeira view  ser executada
            //se existir conta já criada abre a view principal, senão abre a FormResgistar
            StreamReader ler = new StreamReader("Contas.txt");
            string PrimeiraLinha = ler.ReadLine();
            ler.Close();

            // 
            bool sairDoWhile = false;
            
            if (PrimeiraLinha == "" || PrimeiraLinha == null)
            {
                _FormRegistar.ShowDialog();
                if(_FormRegistar.ContaCriadaCorretamente == true)
                {
                    _FormViewPrincipalApp.ShowDialog();

                    //antes de sair verificar sempre se a conta não foi apagada, pq se foi vai ter de abrir
                    //o menu de registar
                    while (_FormViewPrincipalApp.apagouConta == true && sairDoWhile == false)
                    {
                        _FormRegistar = new FormRegistar();
                        _FormRegistar.ShowDialog();

                        if (_FormRegistar.ContaCriadaCorretamente == true)
                        {
                            //se a conta for criada corretamente abre a view principal
                            _FormViewPrincipalApp = new FormViewPrincipalApp();
                            _FormViewPrincipalApp.ShowDialog();
                        }
                        else
                        {
                            //se não for criada corretamente vai sair do ciclo while e fecha tudo
                            sairDoWhile = true;
                        }
                    }
                }
                
            }
            else
            {
                
                _FormViewPrincipalApp.ShowDialog();
                
                //antes de sair verificar sempre se a conta não foi apagada, pq se foi vai ter de abrir
                //o menu de registar
                while(_FormViewPrincipalApp.apagouConta == true && sairDoWhile == false)
                {
                    _FormRegistar = new FormRegistar();
                    _FormRegistar.ShowDialog();
                    
                    if (_FormRegistar.ContaCriadaCorretamente == true)
                    {
                        //se a conta for criada corretamente abre a view principal
                        _FormViewPrincipalApp = new FormViewPrincipalApp();
                        _FormViewPrincipalApp.ShowDialog();
                    }
                    else
                    {
                        //se não for criada corretamente vai sair do ciclo while e fecha tudo
                        sairDoWhile = true;
                    }
                }
                
            }
           
            
        }
    }
}
