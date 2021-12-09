using Bot_Idosos.Models;
using DocumentFormat.OpenXml.Spreadsheet;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.IO;
using System.Linq;
using System.Media;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Bot_Idosos.Views
{
    public partial class FormViewPrincipalApp : Form
    {
        public FormViewPrincipalApp()
        {
            InitializeComponent();

        }
        Pessoa pessoa = new Pessoa();
        Horario[] CriarHorarios = new Horario[20000];
        //cenas do calendario
        Horario[] PosicaoDoListBoxDia = new Horario[20000];
        int numeroDeLembreteslistBoxDia = 0;
        //
        DateTime DataCalendarioSelecionada;
        SoundPlayer AlarmeSound = new SoundPlayer();

        Medicamentos medicamentos = new Medicamentos();
        //Proximo evento
        DateTime ProximoEvento; // se não existir vai ficar a null
        TimeSpan TempoParaOProximoEvento;
        //proximo evento menos 5 min
        DateTime ProximoEvento5min; // se não existir vai ficar a null
        TimeSpan TempoParaOProximoEvento5min;
        bool alarme5minJaTocou = false;
        //---------------------------
        bool existeProximoEvento;
        int posicaoProximoEvento;
        int numeroDeHorariosDepoisDaDataAtual;
        int numeroDeProximosEventosQueAparecem = 5;//neste caso 5, se quisermos mais atualizar
        public bool apagouConta = false;
        public bool jaPassouAoProximoEventoAlarme = false;

        //listbox cores -------------------------------------------------------------

        //--------------------------------------------------------------------------

        private void FormViewPrincipalApp_Load(object sender, EventArgs e)
        {
            
            //atualizaz label horas
            labelHorasViewPrincipal.Text = DateTime.Now.ToString();
            //atualiza o nome do idoso e imagem
            AtualizarParametroDoPerfilDaConta();
            //atualizar os pendetes anteriores à data atual para não
            medicamentos.MeterTomasDeMedicamentoPendentesAVermelho();
            //Inicializar o som do Alarme
            AtualizarSomAlarme();
            //ao dar o load vai ao ficheiro e vai procurar os eventos mais próximos
            AtualizarEventosMaisProximos();
            //no load preencher a textBoxListaMedicamentoDia
            AtualizarListBoxListaMedicamentoDia(DateTime.Today.ToString());
        }

        private void AtualizarParametroDoPerfilDaConta()
        {
            //inicializar Pessoa
            pessoa.AtualizarDadosPessoa();

            textBoxNomeIdoso.Text = pessoa.Nome + " " + pessoa.Apelido;
            //atualizar a imagem
            if(pessoa.Foto == "default")
            {
                //imagem por default a anonima
                pictureBoxFotoViewPrincipal.Image = Bot_Idosos.Properties.Resources.anonimo;
            }          
            else
            {
                pictureBoxFotoViewPrincipal.ImageLocation = pessoa.Foto;
            }
        }

        private void StripMenuItemSairViewPrincipal_Click(object sender, EventArgs e)
        {
            apagouConta = false;
            this.Close();       
        }

        private void StripMenuItemAjudaViewPrincipal_Click(object sender, EventArgs e)
        {
            FormMenuAjuda dlgFormMenuAjuda = new FormMenuAjuda(pessoa.Nome);
            dlgFormMenuAjuda.ShowDialog();
        }


        private void buttonRemoverMedicamento_Click(object sender, EventArgs e)
        {
            FormRemoverMedicamento dlgFormRemoverMedicamento = new FormRemoverMedicamento();
            dlgFormRemoverMedicamento.ShowDialog();
            if (dlgFormRemoverMedicamento.RemoveuMedicamentoCorretamente == true)
            {
                AtualizarEventosMaisProximos();
                AtualizarListBoxListaMedicamentoDia(DataCalendarioSelecionada.ToString());
            }
        }

        private void buttonAdicionarMedicamento_Click(object sender, EventArgs e)
        {
            FormAdicionarMedicamento dlgFormAdicionarMedicamento = new FormAdicionarMedicamento();
            dlgFormAdicionarMedicamento.ShowDialog();

            if (dlgFormAdicionarMedicamento.AdicionouMedicamentoCorretamente == true)
            {
                AtualizarEventosMaisProximos();
            }
        }

      
        private void pesquisarMedicamentoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FormPesquisarMedicamento dlgFormPesquisarMedicamento = new FormPesquisarMedicamento();
            dlgFormPesquisarMedicamento.ShowDialog();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            DateTime DataAgora = DateTime.Now;
            labelHorasViewPrincipal.Text = DataAgora.ToString();

            
            //função eventos mais proximos

            //labelEventosMaisProximos
            if(existeProximoEvento == false)
            {                
                labelEventosMaisProximos.Text = "Não existe nenhum evento";
            }
            else
            {
                //verificar se proximo evernto existe
                TempoParaOProximoEvento = ProximoEvento.Subtract(DataAgora);
                labelEventosMaisProximos.Text = "Proximo evento daqui a: " + TempoParaOProximoEvento.ToString(@"dd\.hh\:mm\:ss");
                //quando o tempo fica a 0 vai ter de passar para o evento seguinte
                if (TempoParaOProximoEvento.TotalSeconds <=0 )
                {
                    //passa-se para o evento seguinte e mete-se a informação do evento anterior
                    passarAoEventoSeguinte();

                    playAlarme(0);
                    
                }
                if(alarme5minJaTocou == false)
                {
                    
                    TempoParaOProximoEvento5min = ProximoEvento5min.Subtract(DataAgora);
                    //tempo proximo evento menos 5 min
                    
                    if (TempoParaOProximoEvento5min.TotalSeconds <= 0)
                    {
                        playAlarme(1);//no modo de aviso apenas
                        //quando toca o alarme5minJaTocou vai passar a true, depois só troca para false quando passar ao proximo evento
                        
                    }
                }
               
            }
            
            //No mesmo timer vai haver o toque 5 min antes do alrme do medicamento

        }

        private void buttonAdicionarLembreteViewPrincipal_Click(object sender, EventArgs e)
        {
            FormAdicionarLembrete dlgFormAdicionarLembrete = new FormAdicionarLembrete();
            dlgFormAdicionarLembrete.ShowDialog();

            if(dlgFormAdicionarLembrete.AdicionouLembreteCorretamente == true)
            {
                AtualizarEventosMaisProximos();
                AtualizarListBoxListaMedicamentoDia(DataCalendarioSelecionada.ToString());
            }
        }

        //procurar os n eventos mais proximos
        //os eventos mais proximos vão ser atualizados nas seguintes situações:
        //-quando se adiciona um medicamento
        //-quando se remove um medicamento
        //-quando se adiciona um lembrete
        //-quando se remove um lembrete
        //-quando o proximo evento acaba e já não há mais nenhum a seguir
        private void AtualizarEventosMaisProximos()
        {
            //no inicio apagar todos os horarios que existem:

            //apagar todos os criarHorarios que existem
            int a = 0;
            while (CriarHorarios[a] != null)
            {
                CriarHorarios[a] = null;
                a++;
            }

            //ler o ficheiro e guardar todos os eventos que a data sejam superiores à atual
            // no inicio vamos ter de ler o ficheiro e passar todos os parametros para o vetor de horario HorasToma
            int i = 0;// o i vai ser o numero a seguir do ultimo Horario existente no vetor
            using (StreamReader leitor = new StreamReader("Horario.txt"))
            {
                while (!leitor.EndOfStream)
                {
                    string linha = leitor.ReadLine();
                    string[] valores = linha.Split(';');

                    //aqui esta as 4 parcelas que existem no horario
                    //passar a data em string para datetime
                    DateTime Data = DateTime.ParseExact(valores[0], "dd/MM/yyyy HH:mm:ss", System.Globalization.CultureInfo.InvariantCulture);
                    if (DateTime.Compare(Data, DateTime.Now) > 0)
                    {
                        CriarHorarios[i] = new Horario();
                        CriarHorarios[i].HoraToma = valores[0];
                        CriarHorarios[i].Tipo = valores[1];
                        CriarHorarios[i]._Medicamento.nomeMedicamento = valores[2];
                        CriarHorarios[i].TextoLembrete = valores[3];
                        CriarHorarios[i].TomouMedicamento = valores[4];
                        i++;
                    }
                           
                }
                leitor.Close();
            }
            numeroDeHorariosDepoisDaDataAtual = i - 1;

            //ordenar lista por data
            //a ordenaçao esta a ser feita aqui mas isto estava a por o programa lento
            //a maneira de a meter o programa mais rapido foi ordenar o ficheiro quando se adiciona medicamentos
            //e não a atualizar
   

            //não vai ordenar pois o ficheiro já está ordenado
            int j;

            //dar clear a listviewantes de escrever
            listViewProximosEventos.Items.Clear();

            int posicaoDaList = 0;
            for (j = 0; j < numeroDeProximosEventosQueAparecem; j++)
            {
                if (CriarHorarios[j] != null)
                {
                    if (CriarHorarios[j].Tipo == "Lembrete")
                    {
                        string[] pr = new string[100];
                        pr[0] = CriarHorarios[j].HoraToma.Remove(10, 9);
                        pr[1] = CriarHorarios[j].HoraToma.Remove(0, 11);
                        pr[2] = CriarHorarios[j].TextoLembrete;

                        ListViewItem novoItem = new ListViewItem(pr);
                        listViewProximosEventos.Items.Add(novoItem);

                        AtribuirCoresAosLembretes(0, posicaoDaList, 3);
                        posicaoDaList++;

                    }
                    if (CriarHorarios[j].Tipo == "Medicamento")
                    {
                        string[] pr = new string[100];
                        pr[0] = CriarHorarios[j].HoraToma.Remove(10, 9);
                        pr[1] = CriarHorarios[j].HoraToma.Remove(0, 11);
                        pr[2] = "Tomar " + CriarHorarios[j]._Medicamento.nomeMedicamento;

                        ListViewItem novoItem = new ListViewItem(pr);
                        listViewProximosEventos.Items.Add(novoItem);

                        if (CriarHorarios[j].TomouMedicamento == "Sim")
                        {
                            AtribuirCoresAosLembretes(0, posicaoDaList, 0);//cor verde
                        }
                        if (CriarHorarios[j].TomouMedicamento == "Pendente")
                        {
                            AtribuirCoresAosLembretes(0, posicaoDaList, 1);//cor amarelo
                        }
                        if (CriarHorarios[j].TomouMedicamento == "Nao")
                        {
                            AtribuirCoresAosLembretes(0, posicaoDaList, 2);//cor vermelho
                        }

                        posicaoDaList++;
                    }
                }
            }
            
            //no final meter a posicao do proximo evento a 0;
            posicaoProximoEvento = 0;

            if (CriarHorarios[0] == null)
            {
                existeProximoEvento = false;
            }
            else
            {
                ProximoEvento = DateTime.ParseExact(CriarHorarios[0].HoraToma, "dd/MM/yyyy HH:mm:ss", System.Globalization.CultureInfo.InvariantCulture);
                ProximoEvento5min = ProximoEvento.AddMinutes(-5);
                existeProximoEvento = true;
            }
          
        }

        //vou fazer para aparecer on proximos n eventos
        private void passarAoEventoSeguinte()
        {
            //em primeiro vai verificar se existe evento seguinte            
            //se não existir vai meter que não existe evento seguinte
            
            if (CriarHorarios[posicaoProximoEvento + 1] == null)
            {
                existeProximoEvento = false;
                posicaoProximoEvento++;
            }//se existir
            else
            {
                existeProximoEvento = true;
                posicaoProximoEvento++;
                //vai converter o tempo do proximo evento
                ProximoEvento = DateTime.ParseExact(CriarHorarios[posicaoProximoEvento].HoraToma, "dd/MM/yyyy HH:mm:ss", System.Globalization.CultureInfo.InvariantCulture);
                ProximoEvento5min = ProximoEvento.AddMinutes(-5);
            }
            //no final atualiza a textBoxEventosMaisProximos
            //clear da listbox
            listViewProximosEventos.Items.Clear();

            //escreber de novo

            int posicaoDaList = 0;
            for (int j = posicaoProximoEvento; j < posicaoProximoEvento + numeroDeProximosEventosQueAparecem; j++)
            {
                if (CriarHorarios[j] != null)
                {
                    if (CriarHorarios[j].Tipo == "Lembrete")
                    {
                        string[] pr = new string[100];
                        pr[0] = CriarHorarios[j].HoraToma.Remove(10, 9);
                        pr[1] = CriarHorarios[j].HoraToma.Remove(0, 11);
                        pr[2] = CriarHorarios[j].TextoLembrete;

                        ListViewItem novoItem = new ListViewItem(pr);
                        listViewProximosEventos.Items.Add(novoItem);
                        //atribuir cor 
                        AtribuirCoresAosLembretes(0, posicaoDaList, 3);
                        posicaoDaList++;
                    }
                    if (CriarHorarios[j].Tipo == "Medicamento")
                    {
                        string[] pr = new string[100];
                        pr[0] = CriarHorarios[j].HoraToma.Remove(10, 9);
                        pr[1] = CriarHorarios[j].HoraToma.Remove(0, 11);
                        pr[2] = "Tomar " + CriarHorarios[j]._Medicamento.nomeMedicamento;

                        ListViewItem novoItem = new ListViewItem(pr);
                        listViewProximosEventos.Items.Add(novoItem);

                        if (CriarHorarios[j].TomouMedicamento == "Sim")
                        {
                            AtribuirCoresAosLembretes(0, posicaoDaList, 0);//cor verde
                        }
                        if (CriarHorarios[j].TomouMedicamento == "Pendente")
                        {
                            AtribuirCoresAosLembretes(0, posicaoDaList, 1);//cor amarelo
                        }
                        if (CriarHorarios[j].TomouMedicamento == "Nao")
                        {
                            AtribuirCoresAosLembretes(0, posicaoDaList, 2);//cor vermelho
                        }

                        posicaoDaList++;
                    }
                }
            }
            //meter que o alarme de 5 min ainda não tocou
            alarme5minJaTocou = false;

        }

        private void editarPerfilToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FormEditarPerfil dlgFormEditarPerfil = new FormEditarPerfil();
            dlgFormEditarPerfil.ShowDialog();
            //No final de editar o perfil vai ter de atualizar a text box do nome
            if (dlgFormEditarPerfil.PerfilEditadoCorretamente == true)
            {
                AtualizarParametroDoPerfilDaConta();
            }
        }

        private void apagarTodosOsHorariosToolStripMenuItem_Click(object sender, EventArgs e)
        {
            DialogResult ConfirmarApagarHorarios = new DialogResult();
            ConfirmarApagarHorarios = MessageBox.Show("Tem a certeza que pretende apagar todos os Horários ?", "Atenção", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);

            if(ConfirmarApagarHorarios == DialogResult.Yes)
            {
                medicamentos.removerTodosHorarios();
                AtualizarEventosMaisProximos();
                AtualizarListBoxListaMedicamentoDia(DataCalendarioSelecionada.ToString());
                MessageBox.Show("Horarios removidos da agenda com sucesso !!!");
            }

        }

        private void apagarTodosMedicamentosToolStripMenuItem_Click(object sender, EventArgs e)
        {
            DialogResult ConfirmarApagarMedicamentos = new DialogResult();
            ConfirmarApagarMedicamentos = MessageBox.Show("Tem a certeza que pretende apagar todos os Lembretes de medicamentos ?", "Atenção", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);

            if (ConfirmarApagarMedicamentos == DialogResult.Yes)
            {
                medicamentos.removerTodosMedicamentos();
                AtualizarEventosMaisProximos();
                AtualizarListBoxListaMedicamentoDia(DataCalendarioSelecionada.ToString());
                MessageBox.Show("Lembretes de medicamentos removidos da agenda com sucesso !!!");
            }
        }

        private void apagarOsLembretesTodosToolStripMenuItem_Click(object sender, EventArgs e)
        {
            DialogResult ConfirmarApagarLembretes = new DialogResult();
            ConfirmarApagarLembretes = MessageBox.Show("Tem a certeza que pretende apagar todos os Lembretes pessoais ?", "Atenção", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);

            if (ConfirmarApagarLembretes == DialogResult.Yes)
            {
                medicamentos.removerTodosLembretes();
                AtualizarEventosMaisProximos();
                AtualizarListBoxListaMedicamentoDia(DataCalendarioSelecionada.ToString());
                MessageBox.Show("Lembretes pessoais removidos da agenda com sucesso !!!");
            }
        }

        private void monthCalendar1_DateChanged(object sender, DateRangeEventArgs e)
        {
            //Atualiza conforme a data que selecionar
            AtualizarListBoxListaMedicamentoDia(monthCalendar1.SelectionRange.Start.Date.ToString());
        }

        private void apagarTodosOsLembretesAntigosToolStripMenuItem_Click(object sender, EventArgs e)
        {
            DialogResult ConfirmarApagarLembretesAntigos = new DialogResult();
            ConfirmarApagarLembretesAntigos = MessageBox.Show("Tem a certeza que pretende apagar todos os Lembretes Antigos?", "Atenção", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);

            if (ConfirmarApagarLembretesAntigos == DialogResult.Yes)
            {
                medicamentos.removerLembretesAntigos();
                AtualizarEventosMaisProximos();
                AtualizarListBoxListaMedicamentoDia(DataCalendarioSelecionada.ToString());
                MessageBox.Show("Lembretes Antigos removidos da agenda com sucesso !!!");
            }
        }

        private void apagarContaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            DialogResult ConfirmarApagarConta = new DialogResult();
            ConfirmarApagarConta = MessageBox.Show("Tem a certeza que pretende apagar a sua conta?", "Atenção", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);

            if (ConfirmarApagarConta == DialogResult.Yes)
            {
                pessoa.ApagarConta();
                MessageBox.Show("Conta Apagada Com Sucesso");
                apagouConta = true;
                this.Close();
            }
        }
      
        //basicamente esta função vai ser universal de modo dar tanto para o inicializar, atualizar e para o calendar picker
        private void AtualizarListBoxListaMedicamentoDia(string Data)//esta string contem a data completa
        {
            labelLembretesDia.Text = "Lembretes do dia :" + Data.Remove(10, 9);
            //usar a listbox

            //exeperimentar listview
            listViewMedicamentoDia.Items.Clear();
            //guardar a data inicial
            DataCalendarioSelecionada = DateTime.ParseExact(Data, "dd/MM/yyyy HH:mm:ss", System.Globalization.CultureInfo.InvariantCulture); ;
            //-----
            int i = 0;
            
            int nHorariosComEssaData = 0;
            using (StreamReader leitor = new StreamReader("Horario.txt"))
            {
                while (!leitor.EndOfStream)
                {

                    string linha = leitor.ReadLine();
                    string[] valores = linha.Split(';');

                    if (valores[0].Remove(10, 9) == Data.Remove(10, 9))
                    {
                        PosicaoDoListBoxDia[i] = new Horario();
                        PosicaoDoListBoxDia[i].HoraToma = valores[0];
                        PosicaoDoListBoxDia[i].Tipo = valores[1];
                        PosicaoDoListBoxDia[i]._Medicamento.nomeMedicamento = valores[2];
                        PosicaoDoListBoxDia[i].TextoLembrete = valores[3];
                        PosicaoDoListBoxDia[i].TomouMedicamento = valores[4];

                        i++;
                        nHorariosComEssaData++;
                    }
                }
                leitor.Close();
            }
            //antes de preencher a listbox tenho de ordenar por ordem das horas
            for (int j = 0; j < nHorariosComEssaData - 1; j++)
            {
                for (int h = 0; h < nHorariosComEssaData - 1; h++)
                {
                    DateTime Data0 = DateTime.ParseExact(PosicaoDoListBoxDia[h].HoraToma, "dd/MM/yyyy HH:mm:ss", System.Globalization.CultureInfo.InvariantCulture);
                    DateTime Data1 = DateTime.ParseExact(PosicaoDoListBoxDia[h + 1].HoraToma, "dd/MM/yyyy HH:mm:ss", System.Globalization.CultureInfo.InvariantCulture);
                    if (DateTime.Compare(Data0, Data1) > 0)
                    {
                        Horario HorarioFor = new Horario();
                        HorarioFor = PosicaoDoListBoxDia[h + 1];
                        PosicaoDoListBoxDia[h + 1] = PosicaoDoListBoxDia[h];
                        PosicaoDoListBoxDia[h] = HorarioFor;
                    }
                }
            }
            //preencher a listbox
            numeroDeLembreteslistBoxDia = nHorariosComEssaData;
            int posicaoDaList = 0;
            for (i = 0; i < nHorariosComEssaData; i++)
            {
                if (PosicaoDoListBoxDia[i].Tipo == "Lembrete")
                {             
               
                    //listViewMedicamentoDia.Items.Add("Hora: " + PosicaoDoListBoxDia[i].HoraToma.Remove(0, 11) + "  " +
                    //"Lembrete: " + PosicaoDoListBoxDia[i].TextoLembrete);

                    string[] pr = new string[100];
                    pr[0] = PosicaoDoListBoxDia[i].HoraToma.Remove(0, 11);
                    pr[1] = PosicaoDoListBoxDia[i].TextoLembrete;
                    
                    ListViewItem novoItem = new ListViewItem(pr);
                    listViewMedicamentoDia.Items.Add(novoItem);
                    //depois atualizar a função das cores
                    //listViewMedicamentoDia.Items[0].BackColor = System.Drawing.Color.Purple;
                    AtribuirCoresAosLembretes(1, posicaoDaList, 3);
                    posicaoDaList++;
                }
                if (PosicaoDoListBoxDia[i].Tipo == "Medicamento")
                {
                    string[] pr = new string[100];
                    pr[0] = PosicaoDoListBoxDia[i].HoraToma.Remove(0, 11);
                    pr[1] = "Tomar " + PosicaoDoListBoxDia[i]._Medicamento.nomeMedicamento;

                    ListViewItem novoItem = new ListViewItem(pr);
                    listViewMedicamentoDia.Items.Add(novoItem);

                    //atribuir cor ao medicamento, ver se é verde amarelo ou vermelho
                    if(PosicaoDoListBoxDia[i].TomouMedicamento == "Sim")
                    {
                        AtribuirCoresAosLembretes(1, posicaoDaList, 0);//cor verde
                    }
                    if (PosicaoDoListBoxDia[i].TomouMedicamento == "Pendente")
                    {
                        AtribuirCoresAosLembretes(1, posicaoDaList, 1);//cor amarelo
                    }
                    if (PosicaoDoListBoxDia[i].TomouMedicamento == "Nao")
                    {
                        AtribuirCoresAosLembretes(1, posicaoDaList, 2);//cor vermelho
                    }
                    posicaoDaList++;
                }
            }
            //se não existir eventos nesse dia aparece adiciona na listbox um item a dizer que não existe

            //no final vai limpar todas as posiçoes da PosicaoDoListBoxDia[i] que não existem
            while (PosicaoDoListBoxDia[nHorariosComEssaData] != null)
            {
                PosicaoDoListBoxDia[nHorariosComEssaData] = null;
            }
          
        }
        //criar o som do alarme
        private void playAlarme(int Modo)// 0- alarme, 1- alarme 5min antes
        {
          
            //vai lançar um message box com o que é para fazer
            //e só quando fechar essa messaage box é que vai parar de tocar
            //vai lançar a info do anterior
            if(Modo == 0)
            {
                DialogResult MensagemAlarme = new DialogResult();
                AlarmeSound.Play();
                Horario horario = CriarHorarios[posicaoProximoEvento - 1];
                if (CriarHorarios[posicaoProximoEvento - 1].Tipo == "Medicamento")
                {
                    MensagemAlarme = MessageBox.Show("Lembrete: Tomar " + CriarHorarios[posicaoProximoEvento - 1]._Medicamento.nomeMedicamento + Environment.NewLine + "Tomou o Medicamento ?", "Atenção", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
                    if (MensagemAlarme == DialogResult.Yes)
                    {

                        AlarmeSound.Stop();//pára o som
                                           //depois vai ter de ir ao medicamento e meter "TomouMedicamento" a verde
                        AlterarTomouMedicamento(horario, "Sim");
                    }
                    else
                    {
                        AlarmeSound.Stop();//pára o som
                                           //depois vai ter de ir ao medicamento e meter "TomouMedicamento" a verde
                        AlterarTomouMedicamento(horario, "Nao");
                    }
                }
                else
                {
                    MensagemAlarme = MessageBox.Show("Lembrete: " + CriarHorarios[posicaoProximoEvento - 1].TextoLembrete, "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    if (MensagemAlarme == DialogResult.OK)
                    {
                        AlarmeSound.Stop();
                    }
                }
                // o som vai ser tocado até o idoso clicar no ok ou até 1 min depois  
            }
            if (Modo == 1)
            {
               
                alarme5minJaTocou = true;
                if (CriarHorarios[posicaoProximoEvento] != null)
                {
                    if (CriarHorarios[posicaoProximoEvento].Tipo == "Medicamento")
                    {
                        AlarmeSound.Play();
                        DialogResult MensagemAlarme = new DialogResult();
                        AlarmeSound.Play();
                        MensagemAlarme = MessageBox.Show("Lembrete: Daqui a 5 minutos tomar " + CriarHorarios[posicaoProximoEvento]._Medicamento.nomeMedicamento, "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        if (MensagemAlarme == DialogResult.OK)
                        {
                            AlarmeSound.Stop();
                        }
                    }
                }
              

            }

        }

        //int a vai ser 0 ou 1, 0 para a list box proximos eventos e 1 para a listbox do calendario
        //int b vai ser a posição do index da listbox
        //int c vai ser a cor, 0-verde, 1-amarelo, 2-vermelho, 3-roxo
        private void AtribuirCoresAosLembretes(int a,int b,int c)
        {
            //lista proximos
            if (a == 0)
            {
                if (c == 0)
                {
                    listViewProximosEventos.Items[b].BackColor = System.Drawing.Color.Green;
                }
                if (c == 1)
                {
                    listViewProximosEventos.Items[b].BackColor = System.Drawing.Color.Yellow;
                }
                if (c == 2)
                {
                    listViewProximosEventos.Items[b].BackColor = System.Drawing.Color.Red;
                }
                if (c == 3)
                {
                    listViewProximosEventos.Items[b].BackColor = System.Drawing.Color.Purple;
                }
            }
            //lista de medicamento dia
            if (a == 1)
            {
                if (c == 0)
                {
                    listViewMedicamentoDia.Items[b].BackColor = System.Drawing.Color.Green;
                  

                }
                if (c == 1)
                {
                    listViewMedicamentoDia.Items[b].BackColor = System.Drawing.Color.Yellow;

                }
                if (c == 2)
                {
                    listViewMedicamentoDia.Items[b].BackColor = System.Drawing.Color.Red;
                }
                if (c == 3)
                {
                    listViewMedicamentoDia.Items[b].BackColor = System.Drawing.Color.Purple;
                }
            }
        }

        private void buttonEditar_Click(object sender, EventArgs e)
        {
            if (listViewMedicamentoDia.SelectedItems.Count > 0)
            {
                //ver qual a posição

                    int index = listViewMedicamentoDia.SelectedIndices[0];
                    FormEditarLembrete dlgFormEditarLembrete = new FormEditarLembrete(PosicaoDoListBoxDia[index].HoraToma, PosicaoDoListBoxDia[index].Tipo, PosicaoDoListBoxDia[index]._Medicamento.nomeMedicamento, PosicaoDoListBoxDia[index].TextoLembrete, PosicaoDoListBoxDia[index].TomouMedicamento);
                    dlgFormEditarLembrete.ShowDialog();
                    //No final de editar o perfil vai ter de atualizar a text box do nome
                    if (dlgFormEditarLembrete.LembreteEditadoCorretamente == true)
                    {
                        //no final vai atualizar as duas listboxs
                        AtualizarListBoxListaMedicamentoDia(DataCalendarioSelecionada.ToString());
                        //depois meter os eventos mais proximos em listbox
                        AtualizarEventosMaisProximos();
                    }                
            }
            else
            {
                MessageBox.Show("Não selecionou item nenhum!!", "ERRO!!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }

        private void buttonApagar_Click(object sender, EventArgs e)
        {
            if (listViewMedicamentoDia.SelectedItems.Count > 0)
            {
                //string curItem = listViewMedicamentoDia.SelectedItems.ToString();
                //int index = listViewMedicamentoDia.fi    //   FindString(curItem);
                //int index = listViewMedicamentoDia.SelectedIndices.; 
                DialogResult ConfirmarApagarLembrete = new DialogResult();
                ConfirmarApagarLembrete = MessageBox.Show("Tem a certeza que pretende apagar esse lembrete?", "Atenção", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);

                if (ConfirmarApagarLembrete == DialogResult.Yes)
                {
                    ApagarDaListBox(listViewMedicamentoDia.SelectedIndices[0]);
                    MessageBox.Show("Lembrete apagado com sucesso");
                }

            }
            else
            {
                MessageBox.Show("Não selecionou item nenhum!!", "ERRO!!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }

        private void ApagarDaListBox(int posiçãoApagar)
        {
            //vai ler o ficheiro e apagar o que é igual aquela posição, depois vai atualizar os proximos eventos
            // e a listbox do calendar picker

            //vamos ler e não vamos escrever os que são lembretes
            Horario[] horarios = new Horario[20000];
            // no inicio vamos ter de ler o ficheiro e passar todos os parametros para o vetor de horario HorasToma
            int i = 0;// o i vai ser o numero a seguir do ultimo jogador existente no vetor
            using (StreamReader leitor = new StreamReader("Horario.txt"))
            {
                while (!leitor.EndOfStream)
                {
                    string linha = leitor.ReadLine();
                    string[] valores = linha.Split(';');

                    //aqui esta as 4 parcelas que existem no horario
                    horarios[i] = new Horario();
                    horarios[i].HoraToma = valores[0];
                    horarios[i].Tipo = valores[1];
                    horarios[i]._Medicamento.nomeMedicamento = valores[2];
                    horarios[i].TextoLembrete = valores[3];                 
                    horarios[i].TomouMedicamento = valores[4];

                    i++;
                }
                leitor.Close();
            }
            //não vai escrever no ficheiro o lembrete que queremos eliminar
            int a;
            StreamWriter escritor = new StreamWriter("Horario.txt");
            bool JaApagou = false;
            for (a = 0; a < i; a++)
            {
                if (horarios[a].HoraToma != PosicaoDoListBoxDia[posiçãoApagar].HoraToma 
                    || horarios[a].Tipo != PosicaoDoListBoxDia[posiçãoApagar].Tipo
                    || horarios[a]._Medicamento.nomeMedicamento != PosicaoDoListBoxDia[posiçãoApagar]._Medicamento.nomeMedicamento
                    || horarios[a].TextoLembrete != PosicaoDoListBoxDia[posiçãoApagar].TextoLembrete
                    || horarios[a].TomouMedicamento != PosicaoDoListBoxDia[posiçãoApagar].TomouMedicamento
                    || JaApagou == true)
                    //se já apagou 1 vai escrever em todos
                { 
                    //se for diferente em apenas uma vai escrever senão não escreve
                    escritor.WriteLine(horarios[a].HoraToma + ";" + horarios[a].Tipo + ";"
                                       + horarios[a]._Medicamento.nomeMedicamento + ";" + horarios[a].TextoLembrete + ";"
                                       + horarios[a].TomouMedicamento + ";");
                    //adicionar o tomou medicamento
                }
                else
                {
                    JaApagou = true;
                }
            }
            escritor.Close();

            //no final vai atualizar as duas listboxs
            AtualizarListBoxListaMedicamentoDia(DataCalendarioSelecionada.ToString());
            //depois meter os eventos mais proximos em listbox
            AtualizarEventosMaisProximos();
        }

        private void listViewMedicamentoDia_SelectedIndexChanged(object sender, EventArgs e)
        {
            //MessageBox.Show(listViewMedicamentoDia.SelectedIndices.ToString());
           
        }
        
        //alterar o tomou medicamento para sim ou para não
        private void AlterarTomouMedicamento(Horario _horario, string _SimOuNao)
        {
            Horario[] horarios = new Horario[20000];
            int i = 0;
            using (StreamReader leitor = new StreamReader("Horario.txt"))
            {
                while (!leitor.EndOfStream)
                {
                    string linha = leitor.ReadLine();
                    string[] valores = linha.Split(';');

                    horarios[i] = new Horario();
                    horarios[i].HoraToma = valores[0];
                    horarios[i].Tipo = valores[1];
                    horarios[i]._Medicamento.nomeMedicamento = valores[2];
                    horarios[i].TextoLembrete = valores[3];
                    horarios[i].TomouMedicamento = valores[4];

                    i++;
                }
                leitor.Close();
            }

            int a;
            StreamWriter escritor = new StreamWriter("Horario.txt");
            bool JaAlterou = false;
            for (a = 0; a < i; a++)
            {
                if (horarios[a].HoraToma == _horario.HoraToma
                    && horarios[a].Tipo == _horario.Tipo
                    && horarios[a]._Medicamento.nomeMedicamento == _horario._Medicamento.nomeMedicamento
                    && horarios[a].TextoLembrete == _horario.TextoLembrete
                    && horarios[a].TomouMedicamento == _horario.TomouMedicamento
                    && JaAlterou == false)
                //se já alterou for true não vai alterar mais nenhum
                {
                   if(_SimOuNao == "Sim")
                    {
                        //vai alterar aquela posição para sim
                        escritor.WriteLine(horarios[a].HoraToma + ";" + horarios[a].Tipo + ";"
                                     + horarios[a]._Medicamento.nomeMedicamento + ";" + horarios[a].TextoLembrete + ";"
                                     + "Sim;");
                        
                        JaAlterou = true;
                      
                    }
                   if(_SimOuNao == "Nao")
                    {
                        escritor.WriteLine(horarios[a].HoraToma + ";" + horarios[a].Tipo + ";"
                                    + horarios[a]._Medicamento.nomeMedicamento + ";" + horarios[a].TextoLembrete + ";"
                                    + "Nao;");
                    
                    }
                }
                else
                {
                    //vai escrever igual
                    escritor.WriteLine(horarios[a].HoraToma + ";" + horarios[a].Tipo + ";"
                                   + horarios[a]._Medicamento.nomeMedicamento + ";" + horarios[a].TextoLembrete + ";"
                                   + horarios[a].TomouMedicamento);
                }
            }
            escritor.Close();

            //no final vai atualizar as duas listViews
            AtualizarListBoxListaMedicamentoDia(DataCalendarioSelecionada.ToString());
            //depois meter os eventos mais proximos em listbox
            AtualizarEventosMaisProximos();
        }

        private void trocarSomDoAlarmeToolStripMenuItem_Click(object sender, EventArgs e)
        {

            FormTrocarSomAlarme dlgFormTrocarSomAlarme = new FormTrocarSomAlarme();
            dlgFormTrocarSomAlarme.ShowDialog();

            if(dlgFormTrocarSomAlarme.AlarmeTrocadoComSucesso == true)
            {
                //atualizaar a pessoa
                pessoa.AtualizarDadosPessoa();
                AtualizarSomAlarme();
            }
  
        }

        //inicializar o som do alarme
        private void AtualizarSomAlarme()
        {
            int nAlarme = pessoa.Alarme;

            if(nAlarme == 1)
            {
                AlarmeSound = new SoundPlayer(Bot_Idosos.Properties.Resources.Alarme1);
            }
            if (nAlarme == 2)
            {
                AlarmeSound = new SoundPlayer(Bot_Idosos.Properties.Resources.AlarmeGalo);
            }
            if (nAlarme == 3)
            {
                AlarmeSound = new SoundPlayer(Bot_Idosos.Properties.Resources.AlarmeEminem);
            }
            if (nAlarme == 4)
            {
                AlarmeSound = new SoundPlayer(Bot_Idosos.Properties.Resources.AlarmeTornado);
            }
            if (nAlarme == 5)
            {
                AlarmeSound = new SoundPlayer(Bot_Idosos.Properties.Resources.AlarmeStillDre);
            }
        }

        private void estatísticasToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FormEstatisticas dlgFormEstatisticas = new FormEstatisticas();
            dlgFormEstatisticas.ShowDialog();
        }

        private void meuPerfilToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FormMeuPerfil dlgFormMeuPerfil = new FormMeuPerfil();
            dlgFormMeuPerfil.ShowDialog();

        }
    }
}
