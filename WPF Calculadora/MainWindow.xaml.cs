using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace WPF_Calculadora
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        double valor1,resultado;
        int contadorDecimal=0;
        int contadorCambioSigno = 0;
        int contadorExepcion = 0;
        int selectorSuma=0;
        int selectorResta = 0;
        int selectorMult = 0;
        int selectorDivision = 0;
        
        public MainWindow()
        {
            InitializeComponent();
        }

        private void BotonRetroceso_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                if (contadorExepcion>=1)
                {
                    TextoResultado.Text = "";
                }
                else
                {
                    string txtOriginal = TextoResultado.Text;
                    TextoResultado.Text = txtOriginal.Remove(txtOriginal.Length - 1);
                }
            }catch (Exception)
            {

            }

        }

        private void BotonBorrar_Click(object sender, RoutedEventArgs e)
        {
            TextoResultado.Text = "";
            NumerosIngresados.Text = "";
            valor1 = 0;
            contadorDecimal = 0;

        }

        private void Boton0_Click(object sender, RoutedEventArgs e)
        {
            numPostExepcion("0");
        }

        private void Boton1_Click(object sender, RoutedEventArgs e)
        {
            numPostExepcion("1");
        }

        private void Boton2_Click(object sender, RoutedEventArgs e)
        {
            numPostExepcion("2");
        }

        private void Boton3_Click(object sender, RoutedEventArgs e)
        {
            numPostExepcion("3");
        }

        private void Boton4_Click(object sender, RoutedEventArgs e)
        {
            numPostExepcion("4");
        }

        private void Boton5_Click(object sender, RoutedEventArgs e)
        {
            numPostExepcion("5");
        }

        private void Boton6_Click(object sender, RoutedEventArgs e)
        {
            numPostExepcion("6");
        }

        private void Boton7_Click(object sender, RoutedEventArgs e)
        {
            numPostExepcion("7");
        }

        private void Boton8_Click(object sender, RoutedEventArgs e)
        {
            numPostExepcion("8");
        }

        private void Boton9_Click(object sender, RoutedEventArgs e)
        {
            numPostExepcion("9");
        }
        private void BotonDecimal_Click(object sender, RoutedEventArgs e)
        {
            if (contadorDecimal == 0)
            {
                TextoResultado.Text += ",";
                contadorDecimal++;
            }
            else { }
        }

        private void BotonCambioSigno_Click(object sender, RoutedEventArgs e)
        {
            string txtOriginal = TextoResultado.Text;
            string txtFinal = TextoResultado.Text = "-" + TextoResultado.Text;
            if (contadorCambioSigno == 0)
            {
                TextoResultado.Text = txtFinal;
                contadorCambioSigno++;
            }
            else
            {
                TextoResultado.Text = txtOriginal.Remove(0, 1);
                contadorCambioSigno--;
            }
        }

        private void BotonPorcentaje_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                double resultadoPorcentaje = double.Parse(TextoResultado.Text) / 100;
                TextoResultado.Text = resultadoPorcentaje.ToString();
            } catch (Exception) { contadorExepcion++; }
        }

        private void BotonSuma_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                valor1 = double.Parse(TextoResultado.Text);
                CajaDeTexto("+");
                TextoResultado.Text = "";
                selectorSuma = 1;
                contadorDecimal = 0;
            }
            catch (Exception) { GenericoExepcion(); }
        }

        private void BotonResta_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                valor1 = double.Parse(TextoResultado.Text);
                CajaDeTexto("-");
                TextoResultado.Text = "";
                selectorResta = 1;
                contadorDecimal = 0;
            }
            catch (Exception) { GenericoExepcion(); }
        }


        private void BotonMultiplicacion_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                valor1 = double.Parse (TextoResultado.Text);
                CajaDeTexto("×");
                TextoResultado.Text = "";
                selectorMult=1;
                contadorDecimal = 0;
            }
            catch (Exception) { GenericoExepcion(); }
        }

        private void BotonDivision_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                valor1=double.Parse(TextoResultado.Text);
                CajaDeTexto("÷");
                TextoResultado.Text = "";
                selectorDivision = 1;
                contadorDecimal = 0;
            }
            catch (Exception) { GenericoExepcion(); }
        }

        private void BotonSqrt_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                valor1 = double.Parse(TextoResultado.Text);
                string resultadoSqrt = Math.Sqrt(valor1).ToString();
                TextoResultado.Text = resultadoSqrt;
            }
            catch (Exception) { GenericoExepcion(); }
        }

        private void BotonPow_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                valor1 = double.Parse(TextoResultado.Text);
                string resultadoPow = Math.Pow(valor1, 2).ToString();
                TextoResultado.Text = resultadoPow;
            }
            catch (Exception) { GenericoExepcion(); }
        }
        private void BotonMenosUno_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                valor1 = double.Parse(TextoResultado.Text);
                string resultadoALaMenosUno = (1 / double.Parse(TextoResultado.Text)).ToString();
                TextoResultado.Text=resultadoALaMenosUno;
            }
            catch (Exception) {GenericoExepcion(); }
        }

        private void BotonResultado_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                if (selectorSuma == 1)
                {
                    resultado = valor1 + double.Parse(TextoResultado.Text);
                    CajaDeTextoV2("+");
                    TextoResultado.Text = resultado.ToString();
                }
                if (selectorResta == 1)
                {
                    resultado = valor1 - double.Parse(TextoResultado.Text);
                    CajaDeTextoV2("-");
                    TextoResultado.Text = resultado.ToString();
                }
                if (selectorMult == 1)
                {
                    resultado = valor1 * double.Parse(TextoResultado.Text);
                    CajaDeTextoV2("×");
                    TextoResultado.Text = resultado.ToString();
                }
                if (selectorDivision == 1)
                {
                    if (double.Parse(TextoResultado.Text) == 0)
                    {
                        TextoResultado.Text = "La división entre 0 no\nes válida";
                    }
                    else
                    {
                        resultado = valor1 / double.Parse(TextoResultado.Text);
                        CajaDeTextoV2("÷");
                        TextoResultado.Text = resultado.ToString();
                    }
                }
                ReinicioTodo();
            }catch (Exception)
            {
                TextoResultado.Text = "Error";
            }

        }
        private void numPostExepcion(string num)
        {
            if (contadorExepcion >= 1)
            {
                TextoResultado.Text = num;
                contadorExepcion = 0;
            }
            else
            {
                TextoResultado.Text += num;
            }
        }
        private void ReinicioTodo()
        {
            contadorDecimal = 0;
            contadorExepcion = 0;
            selectorSuma = 0;
            selectorResta = 0;
            selectorMult = 0;
            selectorDivision = 0;
            valor1 = 0;
        }
        private void CajaDeTexto(string operador)
        {
            NumerosIngresados.Text = valor1 +" "+operador;
        }
        private void CajaDeTextoV2(string operador)
        {
            NumerosIngresados.Text = valor1 + " " + operador+ " "+ TextoResultado.Text+ " = ";
        }
        private void GenericoExepcion()
        {
            TextoResultado.Text = "Primero ingresa un \nnúmero";
            contadorExepcion++;
        }
    }
}
