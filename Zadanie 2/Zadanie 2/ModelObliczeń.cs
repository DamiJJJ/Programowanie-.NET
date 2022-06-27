using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Zadanie_2
{
    class ModelObliczeń : INotifyPropertyChanged
    {
        static readonly Dictionary<string, string> nazwaFunkcji = new Dictionary<string, string>()
        {
            ["x²"] = "kwadrat",
            ["√x"] = "√",
            ["1/x"] = "odwrotność",
            ["n!"] = "silnia",
            ["log"] = "log",
            ["ceil"] = "sufit",
            ["floor"] = "podłoga"
        };
        private string buforIO = "0";
        private double?
            lewyOperand = null,
            prawyOperand = null
            ;
        private string
            operacja = null,
            operacjaJednoargumentowa = null
            ;
        private bool flagaDziałania = false;

        public event PropertyChangedEventHandler PropertyChanged;
        public string BuforIO
        {
            get => buforIO;
            set
            {
                buforIO = value;
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("BuforIO"));
            }
        }
        public string BuforDziałania
        {
            get
            {
                if (operacjaJednoargumentowa != null)
                    return $"{nazwaFunkcji[operacjaJednoargumentowa]}({lewyOperand})";
                if (operacja == "xʸ")
                    return $"{lewyOperand} ^ {prawyOperand}";
                else
                    return $"{lewyOperand} {operacja} {prawyOperand}";
            }
        }

        internal void DopiszCyfrę(string cyfra)
        {
            if (flagaDziałania)
            {
                flagaDziałania = false;
                BuforIO = cyfra;
            }
            else if (BuforIO == "0")
                BuforIO = cyfra;
            else
                BuforIO += cyfra;
        }
        internal void WstawPrzecinek()
        {
            if (flagaDziałania)
            {
                flagaDziałania = false;
                BuforIO = "0,";
            }
            else if (buforIO.Contains(','))
                ;
            else
                BuforIO += ",";
        }
        internal void ZmianaZnaku()
        {
            if (buforIO == "0")
                ;
            else if (buforIO[0] == '-')
                BuforIO = buforIO.Substring(1);
            else
                BuforIO = '-' + buforIO;
            flagaDziałania = false;
        }

        internal void KasujZnak()
        {
            buforIO = buforIO.Substring(0, buforIO.Length - 1);
            if (buforIO == "" || buforIO == "-" || buforIO == "-0")
                BuforIO = "0";
            else
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("BuforIO"));
        }

        internal void ResetujWszystko()
        {
            ZerujIO();
            lewyOperand = default;
            prawyOperand = default;
            operacja = default;
            flagaDziałania = default;
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("BuforDziałania"));
        }
        internal void ZerujIO()
        {
            BuforIO = "0";
        }

        internal void DziałanieJednoargumentowe(string operacja)
        {
            double silnia(double n)
            {
                if (n > 1)
                {
                    return silnia(n - 1) * n;
                }
                else
                {
                    return 1;
                }
            }

            prawyOperand = default;
            operacjaJednoargumentowa = operacja;
            lewyOperand = double.Parse(buforIO);
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("BuforDziałania"));

            if (operacja == "x²")
                lewyOperand = lewyOperand * lewyOperand;

            if (operacja == "√x")
                lewyOperand = Math.Sqrt(Convert.ToDouble(lewyOperand));

            if (operacja == "1/x")
                lewyOperand = 1 / lewyOperand;

            if (operacja == "n!")
                lewyOperand = silnia(Math.Round(Convert.ToDouble(lewyOperand)));

            if (operacja == "log")
                lewyOperand = Math.Log10(Convert.ToDouble(lewyOperand));

            if (operacja == "ceil")
                lewyOperand = Math.Ceiling(Convert.ToDouble(lewyOperand));

            if (operacja == "floor")
                lewyOperand = Math.Floor(Convert.ToDouble(lewyOperand));

            BuforIO = lewyOperand.ToString();
            operacjaJednoargumentowa = default;
        }
        internal void DziałanieDwuargumentowe(string operacja)
        {
            if (lewyOperand == null)
            {
                lewyOperand = double.Parse(buforIO);
                this.operacja = operacja;
                flagaDziałania = true;
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("BuforDziałania"));
            }
            else if (this.operacja == null)
            {
                lewyOperand = double.Parse(buforIO);
                this.operacja = operacja;
                flagaDziałania = true;
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("BuforDziałania"));
            }
            else
            {
                if (!flagaDziałania)
                {
                    prawyOperand = double.Parse(buforIO);
                    flagaDziałania = true;
                    PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("BuforDziałania"));
                    WykonajZbuforowaneDziałanie();
                    this.operacja = operacja;
                }
            }
        }

        internal void WynikProcentowo()
        {
            if (operacja != null)
            {
                if (!flagaDziałania)
                    prawyOperand = double.Parse(buforIO);
                prawyOperand = prawyOperand / 100 * lewyOperand;
                WykonajZbuforowaneDziałanie();
            }
        }
        internal void RównaSię()
        {
            if (operacja != null)
            {
                if (!flagaDziałania)
                    prawyOperand = double.Parse(buforIO);
                WykonajZbuforowaneDziałanie();
            }
        }

        private void WykonajZbuforowaneDziałanie()
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("BuforDziałania"));

            if (operacja == "+")
                lewyOperand = lewyOperand + prawyOperand;
            if (operacja == "-")
                lewyOperand = lewyOperand - prawyOperand;
            if (operacja == "×")
                lewyOperand = lewyOperand * prawyOperand;
            if (operacja == "÷")
                lewyOperand = lewyOperand / prawyOperand;
            if (operacja == "mod")
                lewyOperand = lewyOperand % prawyOperand;
            if (operacja == "xʸ")
                lewyOperand = Math.Pow(Convert.ToDouble(lewyOperand), Convert.ToDouble(prawyOperand));

            BuforIO = lewyOperand.ToString();
            flagaDziałania = true;
        }
    }
}
